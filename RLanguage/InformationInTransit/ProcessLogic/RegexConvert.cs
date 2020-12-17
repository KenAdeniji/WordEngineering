///<summary>
///	2016-08-07	http://stackoverflow.com/questions/3210393/how-do-i-remove-all-non-alphanumeric-characters-from-a-string-except-dash
///</summary>

using System;
using System.Text.RegularExpressions;

namespace InformationInTransit.ProcessLogic
{
	public static partial class RegexConvert
	{
		public static String ToAlphaNumericOnly(this string input)
		{
			Regex rgx = new Regex("[^a-zA-Z0-9]");
			return rgx.Replace(input, "");
		}

		public static String ToAlphaOnly(this string input)
		{
			Regex rgx = new Regex("[^a-zA-Z]");
			return rgx.Replace(input, "");
		}

		public static String ToNumericOnly(this string input)
		{
			Regex rgx = new Regex("[^0-9]");
			return rgx.Replace(input, "");
		}
	}
}
