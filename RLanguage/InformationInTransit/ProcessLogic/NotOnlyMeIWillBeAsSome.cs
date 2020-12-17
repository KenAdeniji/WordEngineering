using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Linq;

using System.Text.RegularExpressions;

using InformationInTransit.DataAccess;

/*
	2015-06-10	Created.	ToMostExtentOfTalent.aspx.cs
	2015-09-14	Created.	NotOnlyMeIWillBeAsSome.cs
	2015-09-19	Created. 	NotOnlyMeIWillBeAsSome.html
	2015-09-14	http://stackoverflow.com/questions/19718347/how-to-count-how-many-times-specific-text-exist-in-the-datatable				
*/
namespace InformationInTransit.ProcessLogic
{
    public class NotOnlyMeIWillBeAsSomeArguments
    {
		[Argument(ArgumentType.AtMostOnce, HelpText="If frequency of occurrence is higher, ignore.")]
        public long OccurrenceLimit = 50;

        [DefaultArgument(ArgumentType.AtMostOnce, HelpText = "Scripture Reference.")]
        public string scriptureReference = null;
    }

    public static partial class NotOnlyMeIWillBeAsSome
	{
		public static void Main(string[] argv)
		{
			String[] 	scriptureReferenceSubset = null;
			DataSet		result = null;
			
			DataSet notOnlyMeIWillBeAsSomeArgumentsDataSet = Process(argv, ref scriptureReferenceSubset, ref result);
			DataTable notOnlyMeIWillBeAsSomeArgumentsDataTable = notOnlyMeIWillBeAsSomeArgumentsDataSet.Tables[0];
		}

		public static DataSet Process(string[] argv, ref String[] scriptureReferenceSubset, ref DataSet result)
		{
            NotOnlyMeIWillBeAsSomeArguments parsedArgs = new NotOnlyMeIWillBeAsSomeArguments();
            bool argumentsParser = Parser.ParseArgumentsWithUsage(argv, parsedArgs);

			scriptureReferenceSubset = null;
			result = null;
            DataSet notOnlyMeIWillBeAsSomeArgumentsDataSet = Parse(parsedArgs, ref scriptureReferenceSubset, ref result);
			return notOnlyMeIWillBeAsSomeArgumentsDataSet;
		}
		
        public static DataSet Parse(NotOnlyMeIWillBeAsSomeArguments parsedArgs, ref String[] scriptureReferenceSubset, ref DataSet result)
		{
            ScriptureReferenceHelper.Process
            (
                parsedArgs.scriptureReference,
                ref scriptureReferenceSubset,
                ref result,
                ScriptureReferenceHelper.BibleQueryFormat,
                "KingJamesVersion"
            );
			DataTable exactDataTable = ReadExact(parsedArgs);
			
			DataSet notOnlyMeIWillBeAsSomeArgumentsDataSet = new DataSet("notOnlyMeIWillBeAsSomeArgumentsDataSet");
			DataTable notOnlyMeIWillBeAsSomeArgumentsDataTable = new DataTable();

			notOnlyMeIWillBeAsSomeArgumentsDataSet.Tables.Add(notOnlyMeIWillBeAsSomeArgumentsDataTable);
			
			notOnlyMeIWillBeAsSomeArgumentsDataTable.Columns.Add("BibleWord", typeof(string));
			foreach(string scriptureReference in scriptureReferenceSubset)
			{
				notOnlyMeIWillBeAsSomeArgumentsDataTable.Columns.Add(scriptureReference, typeof(int));
			}

			HashSet<string> uniqueWords = new HashSet<string>();
			
			string verseText = null;
			List<String> wordsToStat = null;
			
			foreach(DataTable resultDataTable in result.Tables)
			{
				foreach(DataRow resultDataRow in resultDataTable.Rows)
				{
					verseText = (string) resultDataRow["verseText"];
					wordsToStat = ParseSentence(verseText, exactDataTable, uniqueWords);
					foreach(string wordToStat in wordsToStat)
					{
						DataRow notOnlyMeIWillBeAsSomeArgumentsDataRow =
							notOnlyMeIWillBeAsSomeArgumentsDataTable.NewRow();
						notOnlyMeIWillBeAsSomeArgumentsDataRow["BibleWord"] = wordToStat;
						notOnlyMeIWillBeAsSomeArgumentsDataTable.Rows.Add
						(
							notOnlyMeIWillBeAsSomeArgumentsDataRow
						);

						for (int tableIndex = 0; tableIndex < result.Tables.Count; ++tableIndex)
                        {
							string wordToStatAdjusted = wordToStat.Replace("'","''");
							long wordCount = -1;
							
							DataRow[] rows = result.Tables[tableIndex].Select
							(
                                String.Format
								(
									"verseText Like \'%{0}%\'",
									wordToStatAdjusted
								)
							);
							
							wordCount = rows.Length;

                            notOnlyMeIWillBeAsSomeArgumentsDataRow[tableIndex + 1] = wordCount;
                        }
					}	
				}	
			}
			return notOnlyMeIWillBeAsSomeArgumentsDataSet;
		}
		
		public static List<String> ParseSentence
		(
			string sentence,
			DataTable exactDataTable,
			HashSet<string> uniqueWords
		)
		{
			string adjust = null;
			string[] words = sentence.Split(SplitSeparator);
			DataRow foundRow = null;
			List<String> wordsToStatDataTable = new List<String>();
			bool foundUniqueWord = false;
			
			foreach(string word in words)
			{
				adjust = word.Trim();
				if (adjust == String.Empty)
				{
					continue;
				}
				adjust = char.ToUpper(adjust[0]) + adjust.Substring(1);
				foundRow = exactDataTable.Rows.Find(adjust);
				if (foundRow == null) {	//If this word is high occurrence, skip.
					continue;
				}
				foundUniqueWord = uniqueWords.Contains(adjust);
				if (foundUniqueWord) {	//If this word, has been stat, skip.
					continue;
				}
				uniqueWords.Add(adjust);
				wordsToStatDataTable.Add(adjust);
			}
			return wordsToStatDataTable;
		}
		
        public static DataTable ReadExact(NotOnlyMeIWillBeAsSomeArguments parsedArgs)
		{
			string exactSelectStatement = String.Format
			(
				ExactSelectStatementFormat,
				parsedArgs.OccurrenceLimit
			);	
			DataTable dataTable = (DataTable) DataCommand.DatabaseCommand
			(
				exactSelectStatement,
				CommandType.Text,
				DataCommand.ResultType.DataTable
			);
			DataColumn[] primaryKey = new DataColumn[] {dataTable.Columns["BibleWord"]};
			dataTable.PrimaryKey = primaryKey;
			return dataTable;
		}

        public static DataSet NotOnlyMeIWillBeAsSomeSelect()
        {
            DataSet dataSet = (DataSet)DataCommand.DatabaseCommand
            (
                NotOnlyMeIWillBeAsSomeStatement,
                CommandType.Text,
                DataCommand.ResultType.DataSet
            );
            return dataSet;
        }

        public const string ExactSelectStatementFormat = "SELECT * FROM Bible..Exact WHERE Occurrence <= {0}";
        public const string NotOnlyMeIWillBeAsSomeStatement = "SELECT ScriptureReference FROM WordEngineering..NotOnlyMeIWillBeAsSome ORDER BY NotOnlyMeIWillBeAsSomeID DESC";
        public static readonly char[] SplitSeparator = new Char [] {' ', ',', '.', ':', ';', '(', ')', '?', '!'};
	}
}
