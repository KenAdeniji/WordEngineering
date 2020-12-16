using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Text;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;

namespace InformationInTransit.ProcessLogic
{
	/*
		2015-11-15	GetAPage.
		2015-12-12	WordToNumberHelper.cs Created.
		2015-12-14	http://stackoverflow.com/questions/11278081/convert-words-string-to-int
	*/
	public static partial class WordToNumberHelper
	{
		public static void Main(string[] argv)
		{
			if (argv.Length > 0)
			{
				int number = 0;	
				string scriptureReference = RetrieveScriptureReference
				(
						argv[0],
					ref	number
				);	
				System.Console.WriteLine
				(
					"Word: {0} | Number: {1} | Scripture Reference: {2}",
					argv[0],
					number,
					scriptureReference
				);
			}		
		}

		static int ParseEnglish(string number) {
			string[] words = number.ToLower().Split(new char[] {' ', '-', ','}, StringSplitOptions.RemoveEmptyEntries);
			string[] ones = {"one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};
			string[] teens = {"eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"};
			string[] tens = {"ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"};
			Dictionary<string, int> modifiers = new Dictionary<string, int>() {
				{"billion", 1000000000},
				{"million", 1000000},
				{"thousand", 1000},
				{"hundred", 100}
			};

			if(number == "eleventy billion")
				return int.MaxValue; // 110,000,000,000 is out of range for an int!

			int result = 0;
			int currentResult = 0;
			int lastModifier = 1;

			foreach(string word in words) {
				if(modifiers.ContainsKey(word)) {
					lastModifier *= modifiers[word];
				} else {
					int n;

					if(lastModifier > 1) {
						result += currentResult * lastModifier;
						lastModifier = 1;
						currentResult = 0;
					}

					if((n = Array.IndexOf(ones, word) + 1) > 0) {
						currentResult += n;
					} else if((n = Array.IndexOf(teens, word) + 1) > 0) {
						currentResult += n + 10;
					} else if((n = Array.IndexOf(tens, word) + 1) > 0) {
						currentResult += n * 10;
					} else if(word != "and") {
						//throw new ApplicationException("Unrecognized word: " + word);
					}
				}
			}

			return result + currentResult * lastModifier;
		}

		public static string RetrieveScriptureReference
		(
				string word,
			ref	int number
		)
		{
			number = ParseEnglish(word);
			String cmdText = String.Format(NumberSignQueryFormat, number);

			String scriptureReference = (String) DataCommand.DatabaseCommand
			(
				cmdText,
				CommandType.Text,
				DataCommand.ResultType.Scalar
			);
			
			return scriptureReference;
		}
		
		public const string NumberSignQueryFormat = "SELECT TOP 1 ScriptureReference FROM WordEngineering..NumberSign WHERE Number = {0};";
	}
}
