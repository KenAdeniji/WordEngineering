using System;
using System.Data;
using System.Linq;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

using System.Data.SqlClient;

using Newtonsoft.Json;

using InformationInTransit.ProcessLogic;

/*
	2020-01-18	https://stackoverflow.com/questions/32399223/count-number-of-occurences-for-each-distict-item-in-a-datacolumn
*/
namespace InformationInTransit.ProcessCode
{
	public static partial class APerhapsCompareHelper
	{
		public static Dictionary<string, Exact.Participation> Query
		(
			String 	scriptureReference,
			String 	bibleVersion,
			String	search
		)
		{
			String[] scriptureReferenceSubset = null;
			DataSet	 scriptureReferenceDataset = null;
			
			ScriptureReferenceHelper.Process
			(
					scriptureReference,
				ref	scriptureReferenceSubset,
				ref scriptureReferenceDataset,
					ScriptureReferenceHelper.ExactQueryFormat,
					bibleVersion
			);
			
			DataTable scriptureReferenceDataTable = scriptureReferenceDataset.CustomMerge();
			
			Dictionary<string, Exact.Participation> uniqueWords = Parser
			(
				scriptureReferenceDataTable,
				search
			);
			
			return uniqueWords;
		}
		
		public static Dictionary<string, Exact.Participation> Parser
		(
			DataTable 	dataTable,
			String		search
		)
		{
			string adjust = null;
			string scriptureReference = null;
			string verseText = null;
			string[] words = null;
			
			Exact.Participation participation = null;
			Exact.SameWordComparer compareWord = new Exact.SameWordComparer();
			Dictionary<string, Exact.Participation> uniqueWords = new Dictionary<string, Exact.Participation>(compareWord);
			bool found = true;
			
			int row = 1;
			foreach(DataRow dataRow in dataTable.Rows)
			{
				verseText = (string) dataRow["verseText"];
				words = verseText.Split(StringHelper.SplitSeparator);
				foreach(string word in words)
				{
					adjust = word.Trim();
					if (adjust == String.Empty)
					{
						continue;
					}
					if (adjust.Contains(search, StringComparison.OrdinalIgnoreCase) == false)
					{
						continue;
					}
					adjust = char.ToUpper(adjust[0]) + adjust.Substring(1);
					scriptureReference = (string) dataRow["scriptureReference"];
					//found = uniqueWords.ContainsKey(adjust);
					found = uniqueWords.TryGetValue(adjust, out participation);
					if (!found)
					{ 
						participation = new Exact.Participation
						{
							FirstOccurrenceScriptureReference = scriptureReference,
							FirstOccurrenceVerseIDSequence = row,
							FrequencyOfOccurrence = 1
						};
						uniqueWords.Add(adjust, participation);
					}
					else
					{
						participation.LastOccurrenceScriptureReference = scriptureReference;
						participation.LastOccurrenceVerseIDSequence = row;
						++participation.FrequencyOfOccurrence;
					}
				}
				++row;
			}
			
			return uniqueWords;
		}

		public static DataTable ToDataTable(Dictionary<String, Exact.Participation> data)
		{
			DataTable table = new DataTable();
			table.Columns.Add("BibleWord");
			table.Columns.Add("FirstOccurrenceScriptureReference");
			table.Columns.Add("LastOccurrenceScriptureReference");
			table.Columns.Add("FrequencyOfOccurrence", System.Type.GetType("System.Int32"));
			foreach(KeyValuePair<string, Exact.Participation> kvp in data)
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
	}	
}
