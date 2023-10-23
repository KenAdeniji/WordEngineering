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
using System.Text;
using System.Text.RegularExpressions;

using System.Globalization;
using System.Threading;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessCode;
using InformationInTransit.ProcessLogic;

namespace InformationInTransit.WhatWillInvolveLifeAsOurPart
{
	/*
		2023-10-22T21:34:00 Created.
		2023-10-22T21:37:00	The scalar value must identify the entity...of the result set.
			public const string WordExists = @"
				SELECT TOP 1 'Actor' WordExists
				FROM WhatWillInvolveLifeAsOurPartHelper..Actor
				WHERE Named = '{0}'
				
			";
		2023-10-22T21:46:00	WordType could be an actor, place.
	*/
	public class WhatWillInvolveLifeAsOurPartHelper
	{
		public static DataTable Query
		(
			string 	scriptureReference,
			string 	bibleVersion
		)
		{
			String[] scriptureReferenceSubset = null;
			DataSet dataSet = null;
			String verseText;
			String[] verseTexts;
			
			ScriptureReferenceHelper.Process
			(
					scriptureReference,
				ref	scriptureReferenceSubset,
				ref dataSet,
					ScriptureReferenceHelper.ExactQueryFormat,
					bibleVersion
			);
			
			DataTable workDataTable = null;
			DataTable resultDataTable = new DataTable();

			resultDataTable.Columns.Add("BibleWord", typeof(string));
			resultDataTable.Columns.Add("WordType", typeof(string));			
			resultDataTable.Columns.Add("FirstOccurrenceScriptureReference", typeof(string));
			resultDataTable.Columns.Add("LastOccurrenceScriptureReference", typeof(string));
			resultDataTable.Columns.Add("Occurrences", typeof(long));

			resultDataTable.PrimaryKey = new DataColumn[] 
			{ 
				resultDataTable.Columns["BibleWord"]
			};
			
			DataRow workDataRow = null;
			DataRow resultDataRow = null;

			String workScriptureReference = null;

			Object scalarResult = null;
			String wordType = null;

			for
			(
				int	
					workDataTableIndex = 0,
					workDataTablesCount = dataSet.Tables.Count;
				workDataTableIndex < workDataTablesCount;
				++workDataTableIndex
			)
			{
				workDataTable = dataSet.Tables[workDataTableIndex];
				for
				(
					int 
						workDataRowsIndex = 0,
						workDataTableRowsCount = workDataTable.Rows.Count
					;
					workDataRowsIndex < workDataTableRowsCount;
					++workDataRowsIndex
				)
				{
					workDataRow = workDataTable.Rows[workDataRowsIndex];
					verseText = workDataRow["VerseText"].ToString().ToLower();
					workScriptureReference = workDataRow["ScriptureReference"].ToString();
					
					verseTexts = StringHelper.SplitWords(verseText);
					
					foreach(String verseWord in verseTexts)
					{
						scalarResult = DataCommand.DatabaseCommand
						(
							String.Format
							(
								WordExists,
								verseWord
							),
							System.Data.CommandType.Text,
							DataCommand.ResultType.Scalar
						);
				
						if
						(
							scalarResult == null || scalarResult == DBNull.Value
						)
						{
							continue;
						}
						
						wordType = (String) scalarResult;
						
						resultDataRow = resultDataTable.Rows.Find
						(
							new Object[] 
							{
								verseWord
							}
						);
												
						if ( resultDataRow == null )
						{
							resultDataRow = resultDataTable.NewRow(); 
							resultDataRow["BibleWord"] = verseWord;
							resultDataRow["WordType"] = wordType;
							resultDataRow["FirstOccurrenceScriptureReference"] = workScriptureReference;
							resultDataRow["Occurrences"] = 1;
							resultDataTable.Rows.Add(resultDataRow);		
						}
						else
						{	
							resultDataRow["Occurrences"] = (long) resultDataRow["Occurrences"] + 1;
							resultDataRow["LastOccurrenceScriptureReference"] = workScriptureReference;
						}						
					}	
				}
			}
			resultDataTable.AcceptChanges();
			return resultDataTable;
		}	
		
		public const string WordExists = @"
			SELECT TOP 1 'Actor' WordExists
			FROM WhatWillInvolveLifeAsOurPart..Actor
			WHERE Named = '{0}'
		";
	}
}
