using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using System.Text;
using System.Text.RegularExpressions;

namespace ProCSharp10With.NET6Library
{
	///<summary>
	///	2023-04-14T18:12:00 ... 2023-04-14T20:03:00	Created.
	///	http://google.com/books/edition/Pro_C_10_with_NET_6/bVa2zgEACAAJ?hl=en
	///		Indices and ranges can be used with arrays, strings, Span<T>, ReadOnlySpan<T>.
	///		Added in .NET 6/C# 10 IEnumerable<T>
	///</summary>
	public class HowITryToBeAsIHaveAssociated
	{
		public String Forward(String word)
		{
			StringBuilder sb = new StringBuilder();

			Regex regex = new Regex(@"\s");
			string[] words = regex.Split(word);
			for
			(
				int index = 0, length = words.Length;
				index < length;
				index++
			)
			{
				System.Index idx = index;
				if ( sb.Length > 0 )
				{
					sb.Append(' ');
				}
				sb.Append( sb[idx] );
			}	
			return(sb.ToString());
		}
	}
}
