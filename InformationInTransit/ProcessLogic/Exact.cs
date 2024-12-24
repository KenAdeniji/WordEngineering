using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Linq;

using InformationInTransit.DataAccess;

/*
2013-09-19 Exact.cs. Unique words. Database table Bible..Exact.
2013-09-20 udf_exactly. udf_inclusive.
2013-10-11 Difference column.
2015-03-16 adjust = char.ToUpper(adjust[0]) + adjust.Substring(1);
2024-12-16T10:24:00 Difference computed column.
*/
namespace InformationInTransit.ProcessLogic
{
	public static partial class Exact
	{
		public static void Main(string[] argv)
		{
			string adjust = null;
			string scriptureReference = null;
			string verseText = null;
			string[] words = null;
			
			Participation participation = null;
			SameWordComparer compareWord = new SameWordComparer();
			Dictionary<string, Participation> uniqueWords = new Dictionary<string, Participation>(compareWord);
			bool found = true;
			
			DataTable dataTable = ReadBible();
			int row = 1;
			
			foreach(DataRow dataRow in dataTable.Rows)
			{
				verseText = (string) dataRow["KingJamesVersion"];
				words = verseText.Split(SplitSeparator);
				foreach(string word in words)
				{
					adjust = word.Trim();
					if (string.IsNullOrEmpty(adjust)) 						
					{
						continue;
					}
					adjust = adjust.Replace("'", "''");
					adjust = char.ToUpper(adjust[0]) + adjust.Substring(1);
					scriptureReference = (string) dataRow["scriptureReference"];
					//found = uniqueWords.ContainsKey(adjust);
					found = uniqueWords.TryGetValue(adjust, out participation);
					if (!found)
					{
						participation = new Participation
						{
							FirstOccurrenceScriptureReference = scriptureReference,
							FirstOccurrenceVerseIDSequence = row,
							LastOccurrenceVerseIDSequence = 1,
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
			
			DataCommand.DatabaseCommand
			(
				"TRUNCATE TABLE Bible..Exact; DBCC CHECKIDENT('Bible..Exact', RESEED, 1);",
				CommandType.Text,
				DataCommand.ResultType.NonQuery
			);
			
			foreach(KeyValuePair<string, Participation> kvp in uniqueWords)
			{
				/*
				Collection<OdbcParameter> odbcParameterCollection = new Collection<OdbcParameter>();

				//Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);

				odbcParameterCollection.Add(new OdbcParameter("@bibleWord", kvp.Key));
		
				odbcParameterCollection.Add(new OdbcParameter("@firstOccurrenceScriptureReference", kvp.Value.FirstOccurrenceScriptureReference));
				
				OdbcParameter lastOccurrenceScriptureReference = new OdbcParameter("@lastOccurrenceScriptureReference", SqlDbType.VarChar);
				lastOccurrenceScriptureReference.IsNullable = true;
				lastOccurrenceScriptureReference.Value = DBNull.Value;

				odbcParameterCollection.Add(lastOccurrenceScriptureReference);

				odbcParameterCollection.Add(new OdbcParameter("@firstOccurrenceVerseIDSequence", kvp.Value.FirstOccurrenceVerseIDSequence));
				
				OdbcParameter lastOccurrenceVerseIDSequence = new OdbcParameter("@lastOccurrenceVerseIDSequence", SqlDbType.Int);
				lastOccurrenceVerseIDSequence.IsNullable = true;
				lastOccurrenceVerseIDSequence.Value = DBNull.Value;
				
				if (!String.IsNullOrEmpty(kvp.Value.FirstOccurrenceScriptureReference))
				{
					lastOccurrenceScriptureReference.Value = kvp.Value.LastOccurrenceScriptureReference;
					lastOccurrenceVerseIDSequence.Value = kvp.Value.LastOccurrenceVerseIDSequence;
				}
								odbcParameterCollection.Add(lastOccurrenceVerseIDSequence);
				
				odbcParameterCollection.Add(new OdbcParameter("@frequencyOfOccurrence", kvp.Value.FrequencyOfOccurrence));
				
				DataCommand.DatabaseCommand
				(
					"Bible..usp_ExactInsert",
					CommandType.StoredProcedure,
					DataCommand.ResultType.NonQuery,
					odbcParameterollection
				);
				*/
				
				String sqlInsert = String.Format
				(
					SQLStatementExactInsert,
					kvp.Key,
					kvp.Value.FirstOccurrenceScriptureReference,
					kvp.Value.LastOccurrenceScriptureReference,
					kvp.Value.FirstOccurrenceVerseIDSequence,
					kvp.Value.LastOccurrenceVerseIDSequence,
					kvp.Value.FrequencyOfOccurrence
				);	

				DataCommand.DatabaseCommand
				(
					sqlInsert,
					CommandType.Text,
					DataCommand.ResultType.NonQuery
				);
		
			}
		}
		
		public static DataTable ReadBible()
		{
			DataTable dataTable = (DataTable) DataCommand.DatabaseCommand
			(
				"SELECT * FROM Bible..Scripture_View ORDER BY bookId, chapterId, verseId",
				CommandType.Text,
				DataCommand.ResultType.DataTable
			);
			return dataTable;
		}
		
		public static readonly char[] SplitSeparator = new Char [] {' ', ',', '.', ':', ';', '(', ')', '?', '!', '"'};

		public const string SQLStatementExactInsert = @"
	INSERT INTO Bible..Exact 
	(
		BibleWord,
		FirstOccurrenceScriptureReference, 
		LastOccurrenceScriptureReference,
		FirstOccurrenceVerseIDSequence,
		LastOccurrenceVerseIDSequence,
		FrequencyOfOccurrence
	)
	VALUES
	(
		'{0}',
		'{1}', 
		'{2}',
		{3},
		{4},
		{5}
	)
		";
		
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
            public int FirstOccurrenceVerseIDSequence { get; set; }
            public int LastOccurrenceVerseIDSequence { get; set; }
            public int FrequencyOfOccurrence { get; set; }
        }	
    }
}
