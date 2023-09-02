using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

using System.Data.SqlClient;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessCode;
using InformationInTransit.ProcessLogic;

namespace InformationInTransit.ProcessCode
{
	/*
		2023-08-31 15:42:41.387	What are His intent as favor?
		2023-09-02T03:36:00 ... 2023-09-02T03:55:00 Created.
		2023-09-02T03:55:00		Code complete.
	*/
	public class WhatAreHisIntentAsFavor
	{
		public static DataTable Query
		(
			String 	word,
			String	bibleVersion
		)
		{
			String[] words = word.Split
			(
				ScriptureReferenceHelper.SubsetSeparator,
				StringSplitOptions.RemoveEmptyEntries 
			);
			DataTable resultTable = (DataTable) DataCommand.DatabaseCommand
			(
				String.Format
				(
					QueryStatement,
					bibleVersion
				),	
				CommandType.Text,
				DataCommand.ResultType.DataTable
			);
			decimal rankImportance;
			String[] verseTextWord;
			int verseTextWordLength = 0;
			SoundexUtility soundexUtility = new SoundexUtility();
			foreach(DataRow dataRow in resultTable.Rows)
			{
				rankImportance = 0;
				foreach(String wordCurrent in words)
				{
					verseTextWord = dataRow["verseText"].ToString().Split
					(
						ScriptureReferenceHelper.SubsetSeparator,
						StringSplitOptions.RemoveEmptyEntries 
					);
					verseTextWordLength = verseTextWord.Length;
					foreach(String verseTextWords in verseTextWord)
					{
						rankImportance +=
							soundexUtility.Compare
							(
								wordCurrent,
								verseTextWords
							);
					}	
				}
				dataRow["Rank"] =
					rankImportance /
					verseTextWordLength
					;
			}	

			Dictionary<string, string> dictionarySort = new Dictionary<string, string>();
			dictionarySort.Add("Rank", "desc");
			dictionarySort.Add("VerseIDSequence", "asc");
			
			resultTable.DefaultView.RowFilter = "Rank > 0";
			
			resultTable.DefaultView.Sort = 
                  String.Join(",", dictionarySort.Select(x => x.Key + " " + x.Value).ToArray());
			resultTable = resultTable.DefaultView.ToTable();
			
			return resultTable;
		}
		
        public const string QueryStatement = 
		@"
			SELECT
				0.0 Rank,
				{0} VerseText,
				ScriptureReference,
				VerseIDSequence
			FROM 	Bible..Scripture_View
			WHERE	{0} IS NOT NULL
			AND		TRIM({0}) <> ''
			ORDER BY VerseIDSequence ASC
		";
	}
}
