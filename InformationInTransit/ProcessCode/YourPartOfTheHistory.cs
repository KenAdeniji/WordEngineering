using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

using InformationInTransit.DataAccess;

/*
	2019-12-17 Created.
*/
namespace InformationInTransit.ProcessLogic
{
	public static partial class YourPartOfTheHistory
	{
		public static Dictionary<string, Participation> Query
		(
			String	scriptureReference,
			//String[]	scriptureReferenceSubset,
			ref DataSet	dataSet,
			//String	ScriptureReferenceHelper.ExactQueryFormat,
			String	bibleVersion
		)
		{
			string								adjust						= 	null;
			//string								scriptureReference 			= 	null;
			string 								verseText					= 	null;
			string[]							words						= 	null;
			
			Participation						participation 				= 	null;
			SameWordComparer 					compareWord 				= 	new SameWordComparer();
			Dictionary<string, Participation> 	uniqueWords 				= 	new Dictionary<string, Participation>(compareWord);
			bool 								found						= 	true;

			String[] 							scriptureReferenceSubset	=	null;
			//DataSet 							dataSet						= 	null;

			ScriptureReferenceHelper.Process
            (
                scriptureReference,
                ref scriptureReferenceSubset,
                ref dataSet,
                ScriptureReferenceHelper.ExactQueryFormat,
                bibleVersion
            );

			foreach(DataTable dataTable in dataSet.Tables)
			{
				foreach(DataRow dataRow in dataTable.Rows)
				{
					verseText = (string) dataRow["verseText"];
					words = verseText.Split(SplitSeparator);
					foreach(string word in words)
					{
						adjust = word.Trim();
						if (adjust == String.Empty)
						{
							continue;
						}
						adjust = char.ToUpper(adjust[0]) + adjust.Substring(1);
						scriptureReference = (string) dataRow["scriptureReference"];
						//found = uniqueWords.ContainsKey(adjust);
						found = uniqueWords.TryGetValue(adjust, out participation);
						if (!found)
						{
							participation = new Participation
							{
								FirstOccurrenceScriptureReference = scriptureReference,
								FrequencyOfOccurrence = 1
							};
							uniqueWords.Add(adjust, participation);
						}
						else
						{
							participation.LastOccurrenceScriptureReference = scriptureReference;
							++participation.FrequencyOfOccurrence;
						}
					}
				}
			}
			return uniqueWords;
		}
		
		public static DataTable ToDataTable(Dictionary<String, InformationInTransit.ProcessLogic.YourPartOfTheHistory.Participation> data)
		{
			DataTable table = new DataTable();
			table.Columns.Add("BibleWord");
			table.Columns.Add("FirstOccurrenceScriptureReference");
			table.Columns.Add("LastOccurrenceScriptureReference");
			table.Columns.Add("FrequencyOfOccurrence", System.Type.GetType("System.Int32"));
			foreach(KeyValuePair<string, InformationInTransit.ProcessLogic.YourPartOfTheHistory.Participation> kvp in data)
			{
				DataRow row = table.NewRow();
				row["BibleWord"] = kvp.Key;
				row["FirstOccurrenceScriptureReference"] = kvp.Value.FirstOccurrenceScriptureReference;
				row["LastOccurrenceScriptureReference"] = kvp.Value.LastOccurrenceScriptureReference;
				row["FrequencyOfOccurrence"] = kvp.Value.FrequencyOfOccurrence;
				table.Rows.Add(row);
			}
			return table;
		}
		
		public static readonly char[] SplitSeparator = new Char [] {' ', ',', '.', ':', ';', '(', ')', '?', '!'};

        public class SameWordComparer : EqualityComparer<string>
        {
            public override bool Equals(string s1, string s2)
            {
                return s1.Equals(s2, StringComparison.CurrentCultureIgnoreCase);
            }

            public override int GetHashCode(string s)
            {
                return base.GetHashCode();
            }
        }

        public class Participation
        {
            public string FirstOccurrenceScriptureReference { get; set; }
            public string LastOccurrenceScriptureReference { get; set; }
            public int FrequencyOfOccurrence { get; set; }
        }	

    }
}
