using System;
using System.Collections;
using System.Configuration;
using System.Data;

using Microsoft.SqlServer.Server;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

using InformationInTransit.DataAccess;

/*
	2017-09-04	https://stackoverflow.com/questions/8494703/find-a-substring-in-a-case-insensitive-way-c-sharp
	2017-09-05	Five three.	
	2017-09-05	One four five.
	2017-09-06	Ti eyan ba deyan, fifty six; ko jeun, happy.
*/
namespace InformationInTransit.ProcessLogic 
{
	public static partial class ToLiveACompleteLifeIsNotToHaveSpentTheFew
	{
		public static void Main(string[] argv)
		{
			Query();
		}

		[SqlFunction(IsDeterministic = true)]
		public static DataSet Query
		(
			String	bibleVersion			=	"KingJamesVersion",
			String	bibleWord				=	null,
			String	scriptureReference		=	null,
			char[] 	splitSeparator			=	null,
			int[]	wordPositions			=	null
		)
		{
			if (splitSeparator == null)
			{
				splitSeparator = SplitSeparator;
			}

			if (wordPositions == null)
			{
				wordPositions = WordPositions;	
			}
			
			String 			record						= 	null;
			String[]		words						=	null;
			
			int				wordIn						= 	-1;
			int 			wordPositionsLength 		= 	wordPositions.Length;
			StringBuilder	sb;
		
			String[] 		scriptureReferenceSubset 	= 	null;
		
			DataSet 		result 						= 	null;
			
			DataRow 		dataRow						=	null;
		
			ScriptureReferenceHelper.Process
            (
                scriptureReference,
                ref scriptureReferenceSubset,
                ref result,
                ScriptureReferenceHelper.BibleQueryFormat,
                bibleVersion
            );
		
			foreach(DataTable dataTable in result.Tables)
			{
				dataTable.Columns.Add("Concatenate", typeof(String));
				for 
				(
					int rowIndex = 0, rowCount = dataTable.Rows.Count;
					rowIndex < rowCount;
					++rowIndex
				)	
				{
					dataRow = dataTable.Rows[rowIndex];
					record = (String) dataRow["VerseText"];
					words = record.Split(splitSeparator, StringSplitOptions.RemoveEmptyEntries);

					sb = new StringBuilder();
					for
					(	
						int wordPositionsIndex = 0, wordsLength = words.Length, wordPositionCurrent;
						wordPositionsIndex < wordPositionsLength;
						++wordPositionsIndex
					)
					{
						wordPositionCurrent = wordPositions[wordPositionsIndex];
						if (wordPositionCurrent < wordsLength)
						{
							if (!String.IsNullOrEmpty(bibleWord))
							{
								wordIn = bibleWord.IndexOf
								(
									words[wordPositionCurrent],
									StringComparison.CurrentCultureIgnoreCase
								);
								if (wordIn < 0)
								{
									continue;
								}	
							}			
							if (sb.Length > 0)
							{
								sb.Append(' ');
							}
							sb.Append(words[wordPositionCurrent]);	
						}	
					}
					if (sb.Length == 0)
					{
						dataRow.Delete();	
					}
					else
					{		
						dataRow["Concatenate"] = sb.ToString().ToProperCase();
					}	
				}	
				dataTable.AcceptChanges();
			}
	
			return result;
		}
		
		public static readonly char[] SplitSeparator = new Char [] {' ', ',', '.', ':', ';', '(', ')', '?', '!'};
		public static readonly int[] WordPositions = new int[] {4, 5};
	}
}
