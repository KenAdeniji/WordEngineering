using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

using InformationInTransit.DataAccess;

/*
2015-06-10 	To most extent, of talent. ToMostExtentOfTalent.cs. Database table Bible..ToMostExtentOfTalent.
2015-06-11	stackoverflow.com/questions/1978821/how-to-reset-a-dictionary
2015-06-11	http://stackoverflow.com/questions/3770757/how-to-get-the-relative-position-of-a-dictionary-element
2015-06-10	Created.	ToMostExtentOfTalent.aspx.cs
2015-09-14	Created.	NotOnlyMeIWillBeAsSome.cs
2015-09-19	Created. 	NotOnlyMeIWillBeAsSome.html
*/
namespace InformationInTransit.ProcessLogic
{
	public static partial class ToMostExtentOfTalent
	{
		public static void Main(string[] argv)
		{
			string adjust = null;
			string verseText = null;
			string[] words = null;
			
			DataTable dataTable = ReadBible();
			int row = 1;
			bool found = false;
			int wordIndexInRecord  = 0;

			DataCommand.DatabaseCommand
			(
				"TRUNCATE TABLE Bible..ToMostExtentOfTalent; DBCC CHECKIDENT('Bible..ToMostExtentOfTalent', RESEED, 1);",
				CommandType.Text,
				DataCommand.ResultType.NonQuery
			);

			Participation participation = null;
			Participation endeavor = null;
			
			SameWordComparer compareWord = new SameWordComparer();
			Dictionary<string, Participation> uniqueWordsInTheBible = new Dictionary<string, Participation>(compareWord);
			Dictionary<string, Participation> uniqueWordsInTheVerse = new Dictionary<string, Participation>(compareWord);

			foreach(DataRow dataRow in dataTable.Rows)
			{
				verseText = (string) dataRow["KingJamesVersion"];
				words = verseText.Split(SplitSeparator);
				
				wordIndexInRecord = 0;
				uniqueWordsInTheVerse.Clear();
				
				foreach(string word in words)
				{
					adjust = word.Trim();
					if (adjust == String.Empty)
					{
						continue;
					}
					adjust = char.ToUpper(adjust[0]) + adjust.Substring(1);
					
					found = uniqueWordsInTheBible.TryGetValue(adjust, out participation);
					if (!found)
					{
						participation = new Participation
						{
							FrequencyOfOccurence = 1
						};
						uniqueWordsInTheBible.Add(adjust, participation);
					}
					else
					{
						++participation.FrequencyOfOccurence;
					}
					
					found = uniqueWordsInTheVerse.TryGetValue(adjust, out endeavor);
					if (!found)
					{
						endeavor = new Participation
						{
							FrequencyOfOccurence = 1
						};
						uniqueWordsInTheVerse.Add(adjust, endeavor);
					}
					else
					{
						++endeavor.FrequencyOfOccurence;
					}
					
					Collection<SqlParameter> sqlParameterCollection = new Collection<SqlParameter>();
					
					SqlParameter bookId = new SqlParameter("@bookId", SqlDbType.Int);
					SqlParameter chapterId = new SqlParameter("@chapterId", SqlDbType.Int);
					SqlParameter verseId = new SqlParameter("@verseId", SqlDbType.Int);

					SqlParameter bibleWord = new SqlParameter("@bibleWord", SqlDbType.VarChar);

					SqlParameter wordIndexInBible = new SqlParameter("@wordIndexInBible", SqlDbType.Int);
					SqlParameter wordIndexInVerse = new SqlParameter("@wordIndexInVerse", SqlDbType.Int);
					SqlParameter wordFrequencyInBible = new SqlParameter("@wordFrequencyInBible", SqlDbType.Int);
					SqlParameter wordFrequencyInVerse = new SqlParameter("@wordFrequencyInVerse", SqlDbType.Int);

					sqlParameterCollection.Add(bookId);
					sqlParameterCollection.Add(chapterId);
					sqlParameterCollection.Add(verseId);

					sqlParameterCollection.Add(bibleWord);
					
					sqlParameterCollection.Add(wordIndexInBible);
					sqlParameterCollection.Add(wordFrequencyInBible);
					
					sqlParameterCollection.Add(wordIndexInVerse);
					sqlParameterCollection.Add(wordFrequencyInVerse);

					bookId.Value = dataRow["bookId"];
					chapterId.Value = dataRow["chapterId"];
					verseId.Value = dataRow["verseId"];
					
					bibleWord.Value = adjust;

					wordIndexInBible.Value = RetrieveDictionaryKeyPosition(uniqueWordsInTheBible, adjust) + 1;
					wordFrequencyInBible.Value = participation.FrequencyOfOccurence;
					
					wordIndexInVerse.Value = ++wordIndexInRecord;
					wordFrequencyInVerse.Value = endeavor.FrequencyOfOccurence;
					
					DataCommand.DatabaseCommand
					(
						"Bible..usp_ToMostExtentOfTalentInsert",
						CommandType.StoredProcedure,
						DataCommand.ResultType.NonQuery,
						sqlParameterCollection
					);
				}
				++row;
			}
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

		public static int RetrieveDictionaryKeyPosition(Dictionary<string, Participation> d, string key)
		{
			for (int i = 0; i < d.Count; ++i)
			{
				if (d.ElementAt(i).Key == key)
					return i;
			}
			return -1;
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
            public int FrequencyOfOccurence { get; set; }
        }	

    }
}
