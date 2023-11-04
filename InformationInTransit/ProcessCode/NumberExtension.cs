/*
	2023-11-03T08:10:00	http://stackoverflow.com/questions/20156/is-there-an-easy-way-to-create-ordinals-in-c
	2023-11-04T04:31:00 Created.
	2023-11-04T06:05:00
		http://stackoverflow.com/questions/48966570/integer-to-long-ordinal-string-in-c-net
*/
using System;

namespace InformationInTransit.ProcessCode
{
	public static partial class NumberExtension
	{
		public static string AppendSuffix(this int num)
		{
			string number = num.ToString();
			string TH = "th";
			if (number.EndsWith("11")) return number + TH;
			if (number.EndsWith("12")) return number + TH;
			if (number.EndsWith("13")) return number + TH;
			if (number.EndsWith("1")) return number + "st";
			if (number.EndsWith("2")) return number + "nd";
			if (number.EndsWith("3")) return number + "rd";
			return number + "th";
		}
		
		public static string ConvertNumbertoWordsFirst(this long number)
		{
			string words = "";
			words = ConvertNumbertoWords(number);
			words = words.TrimEnd('\\');
			if (words.EndsWith("One"))
			{
				words = words.Remove(words.LastIndexOf("One") + 0).Trim();
				words = words + "First";
			}
			else if (words.EndsWith("Two"))
			{
				words = words.Remove(words.LastIndexOf("Two") + 0).Trim();
				words = words + "Second";
			}
			else if (words.EndsWith("Three"))
			{
				words = words.Remove(words.LastIndexOf("Three") + 0).Trim();
				words = words + "Third";
			}
			else if (words.EndsWith("Five"))
			{
				words = words.Remove(words.LastIndexOf("Five") + 0).Trim();
				words = words + "Fifth";
			}
			else if (words.EndsWith("Eight"))
			{
				words = words.Remove(words.LastIndexOf("Eight") + 0).Trim();
				words = words + "Eighth";
			}
			else if (words.EndsWith("Nine"))
			{
				words = words.Remove(words.LastIndexOf("Nine") + 0).Trim();
				words = words + "Ninth";
			}
			else
			{
				words = words + "th";
			}
			return words;
		}

		public static string ConvertNumbertoWords(long number)
		{
			if (number == 0) return "Zero";
			if (number < 0) return "minus " + ConvertNumbertoWords(Math.Abs(number));
			string words = "";
			if ((number / 100000) > 0)
			{
				words += ConvertNumbertoWords(number / 100000) + " Lakhs ";
				number %= 100000;
			}
			if ((number / 1000) > 0)
			{
				words += ConvertNumbertoWords(number / 1000) + " Thousand ";
				number %= 1000;
			}
			if ((number / 100) > 0)
			{
				words += ConvertNumbertoWords(number / 100) + " Hundred ";
				number %= 100;
			}

			if (number > 0)
			{
				if (words != "") words += "and ";
				var unitsMap = new[]
				{
					"Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "NINETEEN"
				};
			
				var tensMap = new[]
				{
					"Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"
				};
				if (number < 20) words += unitsMap[number];
				else
				{
					words += tensMap[number / 10];
					if ((number % 10) > 0) words += " " + unitsMap[number % 10];
				}
			}
			return words;
		}
	}	
}
