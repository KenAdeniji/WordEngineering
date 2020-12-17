#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Globalization;
using System.Text.RegularExpressions;
#endregion

/*
	2017-10-18	Created.
	2017-10-18	http://stackoverflow.com/questions/1359948/why-doesnt-stringbuilder-have-indexof-method
	2017-10-18	https://stackoverflow.com/questions/25274894/c-sharp-string-substring-equivalent-for-stringbuilder
*/
namespace InformationInTransit.ProcessLogic
{
    public static partial class StringBuilderHelper
    {
		public static int IndexOf(this StringBuilder sb, string value, int startIndex, bool ignoreCase)
		{            
			int index;
			int length = value.Length;
			int maxSearchLength = (sb.Length - length) + 1;

			if (ignoreCase)
			{
				for (int i = startIndex; i < maxSearchLength; ++i)
				{
					if (Char.ToLower(sb[i]) == Char.ToLower(value[0]))
					{
						index = 1;
						while ((index < length) && (Char.ToLower(sb[i + index]) == Char.ToLower(value[index])))
							++index;

						if (index == length)
							return i;
					}
				}

				return -1;
			}

			for (int i = startIndex; i < maxSearchLength; ++i)
			{
				if (sb[i] == value[0])
				{
					index = 1;
					while ((index < length) && (sb[i + index] == value[index]))
						++index;

					if (index == length)
						return i;
				}
			}

			return -1;
		}
		
		public static StringBuilder SubString(this StringBuilder input, int index, int length)
		{
			StringBuilder subString = new StringBuilder();
			if (index + length - 1 >= input.Length || index < 0) 
			{
				throw new ArgumentOutOfRangeException("Index out of range!"); 
			}
			int endIndex = index + length;
			for (int i = index; i < endIndex; i++)
			{
				subString.Append(input[i]);
			}
			return subString;
		}		
	}
}
