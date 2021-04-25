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
2014-02-21 WordEntrance.cs. Unique words. Database table Generative..WordEntrance. File created, work begun.
*/
namespace InformationInTransit.ProcessLogic
{
	public static partial class WordEntrance
	{
		public static void Main(string[] argv)
		{
			string adjust = null;
			DateTime dated = DateTime.Now;
			string wordSaid = null;
			string[] words = null;
			
			Participation participation = null;
			SameWordComparer compareWord = new SameWordComparer();
			Dictionary<string, Participation> uniqueWords = new Dictionary<string, Participation>(compareWord);
			bool found = true;
			
			DataTable dataTable = ReadBible();
			int row = 1;
			foreach(DataRow dataRow in dataTable.Rows)
			{
				/*
				object dataWord = (object) dataRow["Word"];
				if (dataWord == System.DBNull.Value || dataWord == null)
				{
					continue;
				}
				
				object dataDated = (object) dataRow["Dated"];
				if (dataDated == System.DBNull.Value || dataDated == null)
				{
					continue;
				}
				*/
				
				wordSaid = (string) dataRow["Word"];
				words = wordSaid.Split(SplitSeparator);
				foreach(string word in words)
				{
					adjust = word.Trim();
					if (adjust == String.Empty)
					{
						continue;
					}	
					dated = (DateTime) dataRow["Dated"];
					//found = uniqueWords.ContainsKey(adjust);
					found = uniqueWords.TryGetValue(adjust, out participation);
					if (!found)
					{
						participation = new Participation
						{
							FirstOccurrence = dated,
							FirstOccurrencePosition = row,
							FrequencyOfOccurrence = 1
						};
						uniqueWords.Add(adjust, participation);
					}
					else
					{
						participation.LastOccurrence = dated;
						participation.LastOccurrencePosition = row;
						++participation.FrequencyOfOccurrence;
					}
				}
				++row;
			}
			
			DataCommand.DatabaseCommand
			(
				"TRUNCATE TABLE Generative..WordEntrance; DBCC CHECKIDENT('Generative..WordEntrance', RESEED, 1);",
				CommandType.Text,
				DataCommand.ResultType.NonQuery
			);
			
			foreach(KeyValuePair<string, Participation> kvp in uniqueWords)
			{
				Collection<OdbcParameter> odbcParameterCollection = new Collection<OdbcParameter>();
				odbcParameterCollection.Add(new OdbcParameter("@Word", kvp.Key));
				odbcParameterCollection.Add(new OdbcParameter("@firstOccurrence", kvp.Value.FirstOccurrence));
				
				OdbcParameter lastOccurrence = new OdbcParameter("@lastOccurrence", SqlDbType.VarChar);
				lastOccurrence.IsNullable = true;
				lastOccurrence.Value = DBNull.Value;
				
				OdbcParameter difference = new OdbcParameter("@difference", SqlDbType.Int);
				difference.IsNullable = true;
				difference.Value = DBNull.Value;
				
				if (kvp.Value.LastOccurrence != null)
				{
					lastOccurrence.Value = kvp.Value.LastOccurrence;
					difference.Value = kvp.Value.LastOccurrencePosition - kvp.Value.FirstOccurrencePosition;
				}
				
				odbcParameterCollection.Add(lastOccurrence);
				odbcParameterCollection.Add(difference);
					
				odbcParameterCollection.Add(new OdbcParameter("@FrequencyOfOccurrence", kvp.Value.FrequencyOfOccurrence));
				
				DataCommand.DatabaseCommand
				(
					"Generative..usp_WordEntranceInsert",
					CommandType.StoredProcedure,
					DataCommand.ResultType.NonQuery,
					odbcParameterCollection
				);
			}
		}
		
		public static DataTable ReadBible()
		{
			DataTable dataTable = (DataTable) DataCommand.DatabaseCommand
			(
				"SELECT Dated, Word FROM WordEngineering..HisWord ORDER BY Dated",
				CommandType.Text,
				DataCommand.ResultType.DataTable
			);
			return dataTable;
		}
		
		public static readonly char[] SplitSeparator = new Char [] {' ', ',', '.', ':', ';', '(', ')', '?', '!'};

        class Participation
        {
            public DateTime FirstOccurrence { get; set; }
            public DateTime LastOccurrence { get; set; }
            public int FirstOccurrencePosition { get; set; }
            public int? LastOccurrencePosition { get; set; }
            public int FrequencyOfOccurrence { get; set; }
        }

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
    }
}
