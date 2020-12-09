using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;

/*
	2018-03-16	HeActedHisWillOut.cs created.
	2018-03-17	https://www.dotnetperls.com/list-contains
*/
namespace InformationInTransit.ProcessCode
{
	public static partial class HeActedHisWillOut
	{
		public static void Main(string[] argv)
		{
			String[] 	scriptureReferenceSubset	= null;
			DataSet 	result 						= null;
			DataSet		statisticsSet 			= null;
		
			Query
			(
					argv[0],
					argv[1],
				ref	scriptureReferenceSubset,
				ref	result,
				ref	statisticsSet
			);
			
			DataTableHelper.DumpDataTable(statisticsSet.Tables[0]);
		}
		
		public static void Query
		(
				string		scriptureReference,
				string		bibleVersion,
			ref String[] 	scriptureReferenceSubset,
			ref DataSet 	result,
			ref DataSet		statisticsSet
		)
		{
			ScriptureReferenceHelper.Process
            (
					scriptureReference,
                ref scriptureReferenceSubset,
                ref result,
					ScriptureReferenceHelper.BibleQueryFormat,
					bibleVersion
            );

			string adjust = null;
			string scriptureReferenceCurrent = null;
			string verseText = null;
			string[] words = null;
			
			int bookID;
			int chapterID;
			int	verseID;
			
			Participation participation = null;
			SameWordComparer compareWord = new SameWordComparer();
			Dictionary<string, Participation> uniqueWords = new Dictionary<string, Participation>(compareWord);
			
			bool	contains = true;
			bool	found	 = true;

			List<String> scriptureReferenceList = new List<String>();
			
			foreach(DataTable dataTable in result.Tables)
			{
				foreach(DataRow dataRow in dataTable.Rows)
				{
					bookID		=	(int) dataRow["bookId"];
					chapterID	=	(int) dataRow["chapterId"];
					verseID		=	(int) dataRow["verseId"];
					
					scriptureReferenceCurrent = ScriptureReferenceHelper.ScriptureReference.Syntax
					(
						bookID,
						chapterID,
						verseID
					);

					contains = scriptureReferenceList.Contains(scriptureReferenceCurrent);
					
					if ( contains )
					{
						continue;
					}
					
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
						//found = uniqueWords.ContainsKey(adjust);
						found = uniqueWords.TryGetValue(adjust, out participation);
						if (!found)
						{
							participation = new Participation
							{
								BibleWord = adjust,
								ScriptureReferenceFirstOccurrence = scriptureReferenceCurrent,
								FrequencyOfOccurrence = 1
							};
							uniqueWords.Add(adjust, participation);
						}
						else
						{
							participation.ScriptureReferenceLastOccurrence = scriptureReferenceCurrent;
							++participation.FrequencyOfOccurrence;
						}
					}
				}
			}
			
			DataTable statisticsTable = new DataTable();
			statisticsTable = DictionaryToDataTable.ConvertTo<Participation>(uniqueWords, "DemoTable");
		
			statisticsSet = new DataSet();
			statisticsSet.Tables.Add(statisticsTable);
		}
	
		public static readonly char[] SplitSeparator = new Char [] {' ', ',', '.', ':', ';', '(', ')', '?', '!', '`', '"'};

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
			public string BibleWord { get; set; }
			public string ScriptureReferenceFirstOccurrence { get; set; }
            public string ScriptureReferenceLastOccurrence { get; set; }
            public int FrequencyOfOccurrence { get; set; }
        }	
    }
}
