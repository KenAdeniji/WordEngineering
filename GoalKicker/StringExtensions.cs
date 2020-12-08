using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

/*
	2018-08-14	https://goalkicker.com/CSharpBook/CSharpNotesForProfessionals.pdf
*/
namespace InformationInTransit.GoalKicker
{
   public static class StringExtensions
   {
	   /// <summary>
	   /// VB Left function
	   /// </summary>
	   /// <param name="stringparam"></param>
	   /// <param name="numchars"></param>
	   /// <returns>Left-most numchars characters</returns>
	   public static string Left( this string stringparam, int numchars )
	   {
		   // Handle possible Null or numeric stringparam being passed
		   stringparam += string.Empty;
		   // Handle possible negative numchars being passed
		   numchars = Math.Abs( numchars );
		   // Validate numchars parameter
		   if (numchars > stringparam.Length)
			   numchars = stringparam.Length; 
           return stringparam.Substring( 0, numchars );
		}

		/// <summary>
		/// VB Right function
		/// </summary>
		/// <param name="stringparam"></param>
		/// <param name="numchars"></param>
		/// <returns>Right-most numchars characters</returns>
		public static string Right( this string stringparam, int numchars )
		{
			// Handle possible Null or numeric stringparam being passed
			stringparam += string.Empty;
            // Handle possible negative numchars being passed
			numchars = Math.Abs( numchars );
            // Validate numchars parameter
			if (numchars > stringparam.Length) 
				numchars = stringparam.Length;
            return stringparam.Substring( stringparam.Length - numchars );
		} 

        /// <summary>
		/// VB Mid function - to end of string
		/// </summary>
		/// <param name="stringparam"></param>
		/// <param name="startIndex">VB-Style startindex, 1st char startindex = 1</param>
		/// <returns>Balance of string beginning at startindex character</returns>
		public static string Mid( this string stringparam, int startindex )
		{ 
			// Handle possible Null or numeric stringparam being passed
			stringparam += string.Empty;
            // Handle possible negative startindex being passed
			startindex = Math.Abs( startindex );
            // Validate numchars parameter
			if (startindex > stringparam.Length)
				startindex = stringparam.Length;
			// C# strings are zero-based, convert passed startindex
			return stringparam.Substring( startindex - 1 );
		}

		/// <summary>
		/// VB Mid function - for number of characters
		/// </summary>
		/// <param name="stringparam"></param>
		/// <param name="startIndex">VB-Style startindex, 1st char startindex = 1</param>
		/// <param name="numchars">number of characters to return</param>
		/// <returns>Balance of string beginning at startindex character</returns>
		public static string Mid( this string stringparam, int startindex, int numchars)
		{ 
			// Handle possible Null or numeric stringparam being passed
			stringparam += string.Empty;
            // Handle possible negative startindex being passed
			startindex = Math.Abs( startindex );
            // Handle possible negative numchars being passed
			numchars = Math.Abs( numchars );
            // Validate numchars parameter
			if (startindex > stringparam.Length)
				startindex = stringparam.Length;
            // C# strings are zero-based, convert passed startindex
			return stringparam.Substring( startindex - 1, numchars );
		}
		
		public const string s = "Foo"; 
		public static readonly string paddedLeft = s.PadLeft(5);        // paddedLeft = "  Foo" (pads with spaces by default) 
		public static readonly string paddedRight = s.PadRight(6, '+'); // paddedRight = "Foo+++"
		
		static StringExtensions()
		{
			string x = "   Hello World!    "; string y = x.Trim(); // "Hello World!"
			string q = "{(Hi!*"; 
			string r = q.Trim( '(', '*', '{' ); // "Hi!"
			
			//String.TrimStart() and String.TrimEnd() 
			string a = "{(Hi*"; 
			string b = a.TrimStart( '{' ); 	// "(Hi*" 
			string c = a.TrimEnd( '*' );   // "{(Hi" 	

			//Convert Decimal Number to Binary,Octal and Hexadecimal Format
			Int32 number = 15;
			Console.WriteLine(Convert.ToString(number, 2));
			
			Console.WriteLine(Convert.ToString(number, 8));
			
			Console.WriteLine(Convert.ToString(number, 16));
			
			String currency = string.Format("{0:c}", 112.236677); // $112.23 - defaults to system
			
			string s = "My String";
			s = s.ToLowerInvariant(); // "my string"
			s = s.ToUpperInvariant(); // "MY STRING"
			/*
			Note that you can choose to specify a speciﬁc Culture when converting to lowercase and uppercase by
			using the String.ToLower(CultureInfo) and String.ToUpper(CultureInfo) methods accordingly.			
			*/
		}	
	}
}
