using System;
using System.Data;
using System.Linq;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

using System.Text;

using System.Data.SqlClient;

using Newtonsoft.Json;

using InformationInTransit.ProcessLogic;

namespace InformationInTransit.ProcessCode
{
	/*
		2020-03-30	Created.
		2020-03-30	The neglectity of desire. Urine. When you are alone, what do you do? Query based on word length? Specify the scripture reference, and a set of word lengths?
		2020-03-30	https://stackoverflow.com/questions/1297231/convert-string-to-int-in-one-line-of-code-using-linq
		2020-03-31	Genesis 1:18	rule over
		2020-03-31	Revelation 22:20	come Lord
	*/
	public static partial class TheNeglectityOfDesireHelper
	{
		public static void Main(string[] argv)
		{
			StringBuilder sb = new StringBuilder();
			List <TheNeglectityOfDesireHelper.Participation> resultSet = TheNeglectityOfDesireHelper.Query
			(
				argv[0],
				argv[1],
				argv[2],
				argv[3],
				ref sb
			);
			ObjectDumper.Write(resultSet);
		}	
		
		public static List <TheNeglectityOfDesireHelper.Participation> Query
		(
			String 	bibleVersion,
			String 	scriptureReference,
			String	wordsLengthsText,
			String	phrase,
			ref StringBuilder sb
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
			
			sb = new StringBuilder();
			
			List <TheNeglectityOfDesireHelper.Participation> wordsFound = Parser
			(
				scriptureReferenceDataTable,
				wordsLengthsText,
				phrase,
				ref sb
			);
			
			return wordsFound;
		}
		
		public static List <TheNeglectityOfDesireHelper.Participation> Parser
		(
			DataTable 	dataTable,
			String		wordsLengthsText,
			String		phrase,
			ref StringBuilder	sb
		)
		{
			string adjust = null;
			string scriptureReference = null;
			string verseText = null;
			string[] words = null;
			
			sb = new StringBuilder();
			
			List <TheNeglectityOfDesireHelper.Participation> wordsFound = new List<TheNeglectityOfDesireHelper.Participation>();

			StringBuilder 	wordsCombined;
			
			int[] lengths = Array.ConvertAll
			(
				wordsLengthsText.Split(StringHelper.SplitSeparator, StringSplitOptions.RemoveEmptyEntries), 
				int.Parse
			);
			
			int	lengthsIndex = 0;
			int	lengthsLength = lengths.Count();
			int currentWordLength = 0;
			
			foreach(DataRow dataRow in dataTable.Rows)
			{
				scriptureReference = (string) dataRow["scriptureReference"];
				verseText = (string) dataRow["verseText"];
				words = verseText.Split(StringHelper.SplitSeparator, StringSplitOptions.RemoveEmptyEntries);
				wordsCombined = new StringBuilder();

				lengthsIndex = 0;

				foreach(string word in words)
				{
					adjust = word.Trim();
					if (adjust == String.Empty)
					{
						continue;
					}
					currentWordLength = adjust.Length;
					if (currentWordLength != lengths[lengthsIndex])
					{
						lengthsIndex = 0;
						wordsCombined = new StringBuilder();
						continue;
					}
					if (wordsCombined.Length > 0)
					{
						wordsCombined.Append(" ");
					}
					wordsCombined.Append(adjust);
					if ((lengthsIndex + 1) == lengthsLength)
					{
						if 
						(
							wordsCombined.ToString().IndexOf(phrase, StringComparison.OrdinalIgnoreCase) > -1
						)	
						{
							wordsFound.Add
							(
								new TheNeglectityOfDesireHelper.Participation
								{
									ScriptureReference = scriptureReference,
									WordsFound = wordsCombined.ToString()
								}
							);
							lengthsIndex = 0;
							wordsCombined = new StringBuilder();
							continue;
						}	
					}
					++lengthsIndex;
				}
			}
			
			return wordsFound;
		}
	
        public class Participation
        {
            public string ScriptureReference { get; set; }
            public string WordsFound { get; set; }
        }	
	}	
}
