using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

using System.Text;

using InformationInTransit.DataAccess;

/*
2016-08-09 	PhraseTwoOrMoreWordsThatReOccur.cs 
2016-08-09 	https://msdn.microsoft.com/en-us/library/system.data.datacolumn.expression%28v=vs.110%29.aspx
2016-08-22 	http://stackoverflow.com/questions/4350482/t-sql-string-replace-in-update
				UPDATE [PhraseTwoOrMoreWordsThatReOccur] SET [BiblePhrase] = REPLACE([BiblePhrase], '''''', '''')	
*/
namespace InformationInTransit.ProcessLogic
{
	public static partial class PhraseTwoOrMoreWordsThatReOccur
	{
		public static void Main(string[] argv)
		{
			string adjust = null;
			string scriptureReference = null;
			string KingJamesVersion = null;
			string[] words = null;
			
			Participation participation = null;
			SameWordComparer compareWord = new SameWordComparer();
			Dictionary<string, Participation> uniqueWords = new Dictionary<string, Participation>(compareWord);
			bool found = true;
			
			DataTable dataTable = ReadBible();
			int row = 1;
			
			StringBuilder wordsCombined = null;
			
			foreach(DataRow dataRow in dataTable.Rows)
			{
				KingJamesVersion = ((string) dataRow["KingJamesVersion"]).ToLower();
				words = KingJamesVersion.Split(SplitSeparator, StringSplitOptions.RemoveEmptyEntries);
				scriptureReference = (string) dataRow["scriptureReference"];
						
				for
				(
					int wordIndex = 0, wordsCount = words.Length;
					wordIndex < wordsCount - 1;
					++wordIndex
				)	
				{
					wordsCombined = new StringBuilder(words[wordIndex]);
					
					for
					(
						int phraseIndex = wordIndex + 1;
						phraseIndex < wordsCount;
						++phraseIndex
					)	
					{
						wordsCombined.Append(" " + words[phraseIndex]);

						adjust = wordsCombined.ToString();
						adjust = wordsCombined.ToString().Replace("'", "''");	
						string expression; //"ItemName LIKE '*product*'" 
						expression = "KingJamesVersion LIKE '%" + adjust + "%'";
						DataRow[] foundRows;

						// Use the Select method to find all rows matching the filter.
						foundRows = dataTable.Select(expression);
						
						if (foundRows.Length <= 1)
						{
							break;
						}
						
						//found = uniqueWords.ContainsKey(adjust);
						
						adjust = adjust.Replace("''", "'");
						found = uniqueWords.TryGetValue(adjust, out participation);
						if (!found)
						{
							participation = new Participation
							{
								FirstOccurence = scriptureReference,
								FirstOccurencePosition = row,
								FrequencyOfOccurence = 1
							};
							uniqueWords.Add(adjust, participation);
						}
						else
						{
							participation.LastOccurence = scriptureReference;
							participation.LastOccurencePosition = row;
							++participation.FrequencyOfOccurence;
						}
					}	
				}
				++row;
			}
			
			DataCommand.DatabaseCommand
			(
				"TRUNCATE TABLE Bible..PhraseTwoOrMoreWordsThatReOccur; DBCC CHECKIDENT('Bible..PhraseTwoOrMoreWordsThatReOccur', RESEED, 1);",
				CommandType.Text,
				DataCommand.ResultType.NonQuery
			);
			
			foreach(KeyValuePair<string, Participation> kvp in uniqueWords)
			{
				Collection<SqlParameter> sqlParameterCollection = new Collection<SqlParameter>();
				sqlParameterCollection.Add(new SqlParameter("@biblePhrase", kvp.Key));
				sqlParameterCollection.Add(new SqlParameter("@firstOccurrence", kvp.Value.FirstOccurence));
				
				SqlParameter lastOccurence = new SqlParameter("@lastOccurrence", SqlDbType.VarChar);
				lastOccurence.IsNullable = true;
				lastOccurence.Value = DBNull.Value;
				
				SqlParameter difference = new SqlParameter("@difference", SqlDbType.Int);
				difference.IsNullable = true;
				difference.Value = DBNull.Value;
				
				if (!String.IsNullOrEmpty(kvp.Value.LastOccurence))
				{
					lastOccurence.Value = kvp.Value.LastOccurence;
					difference.Value = kvp.Value.LastOccurencePosition - kvp.Value.FirstOccurencePosition;
				}
				
				sqlParameterCollection.Add(lastOccurence);
				sqlParameterCollection.Add(difference);
					
				sqlParameterCollection.Add(new SqlParameter("@FrequencyOfOccurrence", kvp.Value.FrequencyOfOccurence));
				
				DataCommand.DatabaseCommand
				(
					"Bible..usp_PhraseTwoOrMoreWordsThatReOccurInsert",
					CommandType.StoredProcedure,
					DataCommand.ResultType.NonQuery,
					sqlParameterCollection
				);
			}
		}
		
		public static string EscapeLikeValue(string valueWithoutWildcards)
		{
		  StringBuilder sb = new StringBuilder();
		  for (int i = 0; i < valueWithoutWildcards.Length; i++)
		  {
			char c = valueWithoutWildcards[i];
			if (c == '*' || c == '%' || c == '[' || c == ']')
			  sb.Append("[").Append(c).Append("]");
			else if (c == '\'')
			  sb.Append("''");
			else
			  sb.Append(c);
		  }
		  return sb.ToString();
		}
		
		public static DataTable ReadBible()
		{
			DataTable dataTable = (DataTable) DataCommand.DatabaseCommand
			(
				"SELECT * FROM Bible..Scripture ORDER BY bookId, chapterId, verseId",
				CommandType.Text,
				DataCommand.ResultType.DataTable
			);
			return dataTable;
		}
		
		public static readonly char[] SplitSeparator = new Char [] {' ', ',', '.', ':', ';', '(', ')', '?', '!'};

        class SameWordComparer : EqualityComparer<string>
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

        class Participation
        {
            public string FirstOccurence { get; set; }
            public string LastOccurence { get; set; }
            public int FirstOccurencePosition { get; set; }
            public int? LastOccurencePosition { get; set; }
            public int FrequencyOfOccurence { get; set; }
        }	

    }
}
