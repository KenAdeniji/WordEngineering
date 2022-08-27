using System;
using System.Data;
using System.Linq;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

using System.Data.SqlClient;

using System.Text;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;

/*
	2022-08-23T22:43:00	You see lovement.
	2020-08-24	Created.	
	2020-08-24T09:14:00	http://stackoverflow.com/questions/3575029/c-sharp-liststring-to-string-with-delimiter
	2022-08-25			Albertsons Lucky, Charter Square,
						car parking lot North West shopping cart station.
						Please note that the amount of words is not extensible.
						A possible solution is to use a table variable,
						or determine WordID instead of BibleWood.
*/
namespace InformationInTransit.ProcessCode
{
	public static partial class YouSeeLovement
	{
		public static String Query
		(
			String 	bibleVersion,
			String	bibleWord,
			String 	scriptureReference
		)
		{
			String[] scriptureReferenceSubset = null;
			DataSet	 scriptureReferenceDataset = null;
			
			ScriptureReferenceHelper.Process
			(
					scriptureReference,
				ref	scriptureReferenceSubset,
				ref scriptureReferenceDataset,
					ScriptureReferenceHelper.BibleQueryFormat,
					bibleVersion
			);
			
			DataTable scriptureReferenceDataTable = scriptureReferenceDataset.CustomMerge();
			
			String uniqueWords = Parser
			(
				scriptureReferenceDataTable,
				bibleWord
			);

			return uniqueWords;
		}
		
		public static String Parser
		(
			DataTable 	dataTable,
			String		bibleWord
		)
		{
			string adjust = null;
			string scriptureReference = null;
			string verseText = null;
			string[] verseTextWords = null;

			StringBuilder wordList = new StringBuilder();
			
			bibleWord = bibleWord.ToLower();
			
			foreach(DataRow dataRow in dataTable.Rows)
			{
				verseText = ((string) dataRow["verseText"]).ToLower();
				verseTextWords = verseText.Split(StringHelper.SplitSeparator, StringSplitOptions.RemoveEmptyEntries);
				foreach(string verseTextWord in verseTextWords)
				{
					if ( bibleWord != "" && bibleWord.IndexOf(verseTextWord) <= -1)
					{
						continue;
					}
					if ( wordList.ToString().IndexOf(verseTextWord) > -1)
					{
						continue;
					}
					if ( wordList.Length > 0 )
					{
						wordList.Append(", ");
					}		

					wordList.Append("'" + verseTextWord + "'");	
				}
			}
			return wordList.ToString();
		}
	}	
}
