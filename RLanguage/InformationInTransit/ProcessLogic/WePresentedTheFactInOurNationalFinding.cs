/*
		2014-01-30 Created.
		We presented the fact, in our national finding.
		28 106       33  30    23 54  86       63
28      + or -
106    	134 -78
33		167 101 -45 -111
30		197 137 131 71 -15 -75 -81 -141
23	    220 174 160 114 154 108 94 48 8 -38 -52 -98 -58 -104 -118 -164
54      274 166      
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections;

namespace InformationInTransit.ProcessLogic
{
    public static partial class WePresentedTheFactInOurNationalFinding
    {
        public static void Main(string[] argv)
		{
			foreach(string argc in argv)
			{
				Answer(argc);
			}	
		}
		
		public static StringBuilder Answer(string sentence)
        {
			StringBuilder sb = new StringBuilder();
			
			string[] mixup = sentence.Split(WordSplit);
			int alphabetSequenceIndex = -1;
			List<string> words = new List<string>();
			
			foreach(string mix in mixup)
			{
				alphabetSequenceIndex = InformationInTransit.ProcessLogic.AlphabetSequence.Id(mix);
				if (alphabetSequenceIndex <= 0)
				{
					continue;
				}
				words.Add(mix);	
			}
			
			string word;
			int wordsCount = words.Count;

			if (wordsCount < 2)
			{
				return sb;
			}	
			
			int alphabetSequenceIndexCurrent = InformationInTransit.ProcessLogic.AlphabetSequence.Id(words[0]);
			int alphabetSequenceIndexNext = InformationInTransit.ProcessLogic.AlphabetSequence.Id(words[1]);
			
			int plus = -1;
			int minus = -1;
			
			List<int> finalList = new List<int>();
			List<int> intermediateList = new List<int>();
			
			for (int wordIndex = 2; wordIndex <= wordsCount; ++wordIndex)
			{
				for(int listIndex = 0, listCount = finalList.Count; listIndex <= listCount; ++listIndex)
				{
					plus = alphabetSequenceIndexCurrent + alphabetSequenceIndexNext;
					minus = alphabetSequenceIndexCurrent - alphabetSequenceIndexNext;
					
					intermediateList.Add(plus);
					intermediateList.Add(minus);

					sb.AppendFormat
					(
						PlusMinusFormat,
						plus,
						minus
					);	

					System.Console.WriteLine
					(
						"wordIndex: {0} | wordsCount: {1} | listIndex: {2} | listCount: {3} | alphabetSequenceIndexCurrent: {4} | alphabetSequenceIndexNext: {5} | sb: {6} | intermediateList.Count: {7} | finalList.Count: {8}",
						wordIndex,
						wordsCount,
						listIndex,
						listCount,
						alphabetSequenceIndexCurrent,
						alphabetSequenceIndexNext,
						sb,
						intermediateList.Count,
						finalList.Count
					);
					
					if (listIndex + 1 < listCount)
					{
						sb.Append(", ");
					}
					else if (listCount > 0)
					{
						//listIndex = 0;
						alphabetSequenceIndexCurrent = finalList[0];
					}
				}

				word = words[wordIndex];
				alphabetSequenceIndexNext = InformationInTransit.ProcessLogic.AlphabetSequence.Id(word);
			
				sb.Append(';');
				finalList.AddRange(intermediateList);
				intermediateList = new List<int>();
			}
			
			System.Console.WriteLine(sb);
			
			return sb;
		}
		
		public static readonly char[] WordSplit = new char [] { ' ', ',', ';', '.' };
		public const string PlusMinusFormat = "{0}, {1}";
    }
}

/*
index: 2 | wordsCount: 4 | listIndex: 0 | listCount: 0 | alphabetSequenceIndexCurrent: 28 | alphabetSequenceIndexNext: 106 | sb: 134, -78
index: 3 | wordsCount: 4 | listIndex: 0 | listCount: 2 | alphabetSequenceIndexCurrent: 134 | alphabetSequenceIndexNext: 33 | sb: 134, -78;167, 101
index: 3 | wordsCount: 4 | listIndex: 1 | listCount: 2 | alphabetSequenceIndexCurrent: -78 | alphabetSequenceIndexNext: 33 | sb: 134, -78;167, 101, -45, -111
*/
