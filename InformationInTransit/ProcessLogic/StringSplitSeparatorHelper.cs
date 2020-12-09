using System;
using System.Globalization;
using System.Text;

namespace InformationInTransit.ProcessLogic
{
    /*
		2017-04-21	StringSplitSeparatorHelper.cs
		2017-04-21	https://msdn.microsoft.com/en-us/library/system.globalization.unicodecategory(v=vs.110).aspx
		2017-04-21	http://www.alanzucconi.com/2015/07/26/enum-flags-and-bitwise-operators/
		2017-04-21	https://www.dotnetperls.com/tochararray
		2017-04-21	stackoverflow.com/questions/1324009/net-c-sharp-convert-char-to-string
	*/
	public static partial class StringSplitSeparatorHelper
    {
        public static void Main()
        {
			char[] splitCharacters;
			splitCharacters = Combine
			(
				UnicodeCategoryType.ClosePunctuation 
				| UnicodeCategoryType.DashPunctuation
				| UnicodeCategoryType.DecimalDigitNumber
			);
			//splitCharacters = Combine(UnicodeCategoryType.None);
			System.Console.WriteLine(splitCharacters.Length);
			System.Console.WriteLine(new string(splitCharacters));
        }

		public static char[] Combine(UnicodeCategoryType split)
		{
			StringBuilder sb = new StringBuilder();
			if (HasFlag(split, UnicodeCategoryType.ClosePunctuation))
			{
				sb.Append("(){}[]");
			}
			if (HasFlag(split, UnicodeCategoryType.Control))
			{
				sb.Append((char) 0x007F);
				for (int code = 0x0000; code <= 0x001F; ++code)
				{
					
					sb.Append((char)code);
				}
				for (int code = 0x0080; code <= 0x009F; ++code)
				{
					
					sb.Append((char)code);
				}
			}
			if (HasFlag(split, UnicodeCategoryType.DashPunctuation))	
			{
				sb.Append('-');
			}
			if (HasFlag(split, UnicodeCategoryType.DecimalDigitNumber))		
			{
				sb.Append("0123456789");
			}
			return (sb.ToString().ToCharArray());
		}

		// Works with "None" as well
		public static bool HasFlag(UnicodeCategoryType a, UnicodeCategoryType b)
		{
			return (a & b) == b;
		}		
		
		[Flags] 
		public enum UnicodeCategoryType
		{
			// Decimal    				// Binary
			None = 0,					// 000000
			ClosePunctuation = 1,    	// 000001
			Control = 2,				// 000010
			DashPunctuation = 4, 		// 001000
			DecimalDigitNumber = 8
		}		
    }
}
