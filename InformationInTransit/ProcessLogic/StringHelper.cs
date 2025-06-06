﻿#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;

using InformationInTransit.ProcessCode;
#endregion

/*
	2017-03-05	Created MakeQueryClause() method.
	2019-02-26	devx.com/tips/dot-net/c-sharp/left-right-and-mid-string-functions-for-c-170220112507.html
	2020-02-23	ContainLogic().
*/
namespace InformationInTransit.ProcessLogic
{
    #region StringHelper definition
    public static partial class StringHelper
    {
        #region Methods
        public static void Main(String[] argv)
        {
            //string sentence = String.Join(" ", argv);
            //System.Console.WriteLine(WordCount(sentence));

			string whereClause = MakeQueryClause
			(
				"who",
				"Matthew, Mark, Luke, John",
				"And",
				"Or"
			);
			System.Console.WriteLine(whereClause);
			
			System.Console.WriteLine("Microsoft.CSharp".Left(5));
			System.Console.WriteLine("Microsoft.CSharp".Right(6));
			System.Console.WriteLine("Microsoft.CSharp".Mid(5, 4));
        }

        public static string CapitalizeFirstLetterOfAllTheWords(this string sentence)
        {
            string capitalized = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(sentence);
            return capitalized;
            /*
             *  TextInfo UsaTextInfo = new CultureInfo("en-US", false).TextInfo;
             *  string capitalized = UsaTextInfo.ToTitleCase("asp.net simply rocks!!!");
            */ 
        }

		
		public static StringBuilder CombineLogic(string columnName, string columnValue, string logic)
		{
			String[] columnValues = columnValue.Split(SplitSeparator, StringSplitOptions.RemoveEmptyEntries);
			StringBuilder sb = new StringBuilder();
			foreach(String columnCurrent in columnValues)
			{
				if (sb.Length != 0)
				{
					sb.Append(logic);
				}	
				sb.AppendFormat
				(
					" {0} LIKE '%[^a-z]{1}[^a-z]%' ",
					columnName,
					columnCurrent
				);	
			}
			return sb;	
		}

		public static StringBuilder ContainLogic
		(
			string 	columnName,
			string 	columnValue,
			string 	logic,
			bool	wholeWords
		)
		{
			String[] columnValues = LogicHelper.ValueSeparator(logic, columnValue);
			columnValue.Split(SplitSeparator, StringSplitOptions.RemoveEmptyEntries);
			StringBuilder sb = new StringBuilder();
			foreach(String columnValueCurrent in columnValues)
			{
				if (sb.Length != 0)
				{
					sb.Append(logic);
				}	
				sb.AppendFormat
				(
					wholeWords ? WholeWordsWildCardSearchQueryFormat : NotWholeWordsWildCardSearchQueryFormat,
					columnName,
					columnValueCurrent
				);
				EventLog.WriteEntry("Application", sb.ToString(), EventLogEntryType.Information);
			}
			return sb;	
		}
		
        public static Boolean Contains(this String str, String value, StringComparison options)
        {
            return str.IndexOf(value, options) >= 0;
        }

		//2017-04-06 Created.
		public static string HTMLContent(this String str)
		{
			int firstGreaterThan = -1;
			int lastLessThan = -1;

			string htmlContent = null;
			firstGreaterThan = str.IndexOf('>');
			
			if (firstGreaterThan > -1)
			{	
				lastLessThan = str.IndexOf('<', firstGreaterThan);
				if (lastLessThan > -1)
				{	
					htmlContent = str.Substring
					(
						firstGreaterThan + 1,
						lastLessThan - firstGreaterThan - 2
					).Trim();
				}	
			}	
			
			return htmlContent;
		}
		
		///<example>
		///Type type = ("Taiwan").GetType();
		///bool isString = type.IsString();
		///</example>
		///<example>
		///http://extensionmethod.net/csharp/type/isstring
		///</example>
		public static bool IsString(this Type type)
		{
			return type.Equals(typeof(string));
		}

		// 2018-03-04 https://social.msdn.microsoft.com/Forums/en-US/4be305bf-0b0a-4f6b-9ad5-309efa9188b8/count-the-number-of-characters-in-a-string?forum=csharplanguage
		public static int LetterCount(string st)
		{
			int count = 0;
			foreach(char c in st) {
			  if(char.IsLetter(c)) {
				count++;
			  }
			}
			return count;
		}

		public static string Left(this string param, int length)
		{
			return param.Substring(0, length);
		}
		
		public static string MakeQueryClause
		(
			string	columnName,
			string	columnValue,
			string	combinationLogicPreceeding,
			string	combinationLogicJoin
		)
		{
			columnValue = columnValue.Trim();
			if (columnValue == "") { return ""; }
			string[] currentValues = columnValue.Split(SplitSeparator, StringSplitOptions.RemoveEmptyEntries);
			StringBuilder sb = new StringBuilder(" " + combinationLogicPreceeding + " (");
			bool contained = false;
			foreach(string currentValue in currentValues)
			{
				if (contained) 
				{
					sb.Append(" " + combinationLogicJoin + " ");
				}	
				contained = true;
				sb.AppendFormat
				(
					WholeWordsWildCardSearchQueryFormat,
					columnName,
					currentValue.Trim()
				);
			}
			return sb.Append(")").ToString();
		}

		public static string Mid(this string param, int startIndex, int length)
		{
			return param.Substring(startIndex, length);
		}
		
        /*
        public static string Reverse(this string s)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = s.Length - 1; i >= 0; i--)
            {
                sb.Append(s[i]);
            }
            return sb.ToString();
        }
        */

		//2018-03-20 https://stackoverflow.com/questions/8809354/replace-first-occurrence-of-pattern-in-a-string
		public static string ReplaceFirst(this string text, string search, string replace)
		{
		  int pos = text.IndexOf(search, StringComparison.CurrentCultureIgnoreCase);
		  if (pos < 0)
		  {
			return text;
		  }
		  return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
		}
		
		public static string Reverse(this string s)
        {
            char[] c = s.ToCharArray();
            Array.Reverse(c);
            return new string(c);
        }

		public static string Right(this string param, int length)
		{
			return param.Substring(param.Length - length, length);
		}
		

		//2020-12-29T22:59:00	https://stackoverflow.com/questions/23292776/counting-the-occurrences-of-every-duplicate-words-in-a-string-using-dictionary-i/23292870	
		public static string[] SplitWords(string s)
		{
			 return Regex.Split(s, @"\W+");
		}

		//2018-04-24	https://stackoverflow.com/questions/17678798/remove-words-in-string-from-words-in-array-with-c-sharp?utm_medium=organic&utm_source=google_rich_qa&utm_campaign=google_rich_qa
		//2018-04-24	https://www.dotnetperls.com/distinct
		public static string StringWordsRemove(string stringToClean, string[] wordsToRemove)
		{
			//return string.Join(" ", stringToClean.Split(' ').Except(wordsToRemove));
			// Define how to tokenize the input string, i.e. space only or punctuations also
			/*
			return string.Join
			(
				" ",
				(
					(
						stringToClean
						.Split(new[] { ' ', ',', '.', '?', '!', ':' }, StringSplitOptions.RemoveEmptyEntries)
						.Except(wordsToRemove)
					)	
				).Distinct()
			);
			*/
			stringToClean = CapitalizeFirstLetterOfAllTheWords(stringToClean);
			string[] wordsToClean = stringToClean.Split
			(
				new[] { ' ', ',', '.', '?', '!', ':' }, StringSplitOptions.RemoveEmptyEntries
			);
			var exceptWords = wordsToClean.Except(wordsToRemove);
			var distinctWords = exceptWords.Distinct();
			var wordsJoined = string.Join(" ", distinctWords);
			return wordsJoined;
		}
		
        public static string StripNumberFormat(string value)
        {
            string number = value.Trim().Replace("%", "").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol, "");
            if (number.Length == 0)
            {
                number = "0";
            }
            return number;
        }

        public static string ToPlural(this string singular)
        {
            // Multiple currentValues in the form A of B : Apply the plural to the first currentValue only (A)
            int index = singular.LastIndexOf(" of ");
            if (index > 0) return (singular.Substring(0, index)) + singular.Remove(0, index).ToPlural();

            // single Word rules
            // sibilant ending rule
            if (singular.EndsWith("sh")) return singular + "es";
            if (singular.EndsWith("ch")) return singular + "es";
            if (singular.EndsWith("us")) return singular + "es";
            if (singular.EndsWith("ss")) return singular + "es";
            //-ies rule
            if (singular.EndsWith("y")) return singular.Remove(singular.Length - 1, 1) + "ies";
            // -oes rule
            if (singular.EndsWith("o")) return singular.Remove(singular.Length - 1, 1) + "oes";
            // -s suffix rule
            return singular + "s";
        }

		///<remarks>
		///http://extensionmethod.net/csharp/string/topropercase
		///</remarks>
		public static string ToProperCase(this string text)
		{
			System.Globalization.CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
			System.Globalization.TextInfo textInfo = cultureInfo.TextInfo;
			return textInfo.ToTitleCase(text);
		}
		
        public static int WordCount(this string input)
        {
            var count = 0;
            // Exclude whitespaces, Tabs and line breaks
            Regex regex = new Regex(@"[^\s]+");
            MatchCollection matches = regex.Matches(input);
            count = matches.Count;
            return count;
        }
        #endregion
		
		public static readonly char[] SplitSeparator = new Char [] {' ', ',', '.', ':', ';', '(', ')', '?', '!'};
		public const string NotWholeWordsWildCardSearchQueryFormat = " ( {0} LIKE '%{1}%' ) ";
		public const string WholeWordsWildCardSearchQueryFormat = " ( {0} LIKE '%[^a-z]{1}[^a-z]%' ) ";
    }
    #endregion
}
