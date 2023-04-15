using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using System.Text;

namespace ProCSharp10WithNET6Library;

///<summary>
///	2023-04-14T18:12:00 ... 2023-04-15T06:19:00	Created.
///	http://google.com/books/edition/Pro_C_10_with_NET_6/bVa2zgEACAAJ?hl=en
///		Indices and ranges can be used with arrays, strings, Span<T>, ReadOnlySpan<T>.
///		Added in .NET 6/C# 10 IEnumerable<T>
///</summary>
public class HowITryToBeAsIHaveAssociated
{
	public static String Backward(String word)
	{
		StringBuilder sb = new StringBuilder();

		string[] words = word.Split
		(
			Separators,
			StringSplitOptions.RemoveEmptyEntries
		);
		
		for
		(
			int index = 1, length = words.Length;
			index <= length;
			index++
		)
		{
			System.Index idx = ^index;
			if ( sb.Length > 0 )
			{
				sb.Append(' ');
			}
			sb.Append( words[idx] );
		}	
		return(sb.ToString());
	}

	public static String Forward(String word)
	{
		StringBuilder sb = new StringBuilder();

		string[] words = word.Split
		(
			Separators,
			StringSplitOptions.RemoveEmptyEntries
		);
		
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
			sb.Append( words[idx] );
		}	
		return(sb.ToString());
	}
	
	public static readonly char[] Separators = new char[] { ',', ';', '.', '?' };
}
