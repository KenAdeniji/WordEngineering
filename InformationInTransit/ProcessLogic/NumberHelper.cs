/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Globalization;
using System.Numerics;

using System.Runtime.InteropServices;

namespace InformationInTransit.ProcessLogic
{
    public static partial class NumberHelper
    {
		[DllImport("Shlwapi.dll", CharSet = CharSet.Auto)]
		public static extern Int32 StrFormatByteSize(
			long fileSize,
			[MarshalAs(UnmanagedType.LPTStr)] StringBuilder buffer,
			int bufferSize);
	
		public static void Main(string[] argv)
        {
            Int64 int64;
            bool convert = Int64.TryParse(argv[0], out int64);
            string word = ConvertNumberToWord(int64);
            System.Console.WriteLine(word);
			System.Console.WriteLine(int64.IsPrime());
			BigInteger bigInteger = int64;
			System.Console.WriteLine(bigInteger.MetricSizeBytes());
        }

        public static string ConvertNumberToWord(long numberVal)
        {
            string[] powers = new string[] { "thousand ", "million ", "billion " };
            string[] ones = new string[] {"one", "two", "three", "four", 
                "five", "six", "seven", "eight", "nine", "ten",
                "eleven", "twelve", "thirteen", "fourteen", "fifteen",
                "sixteen", "seventeen", "eighteen", "nineteen"};
            string[] tens = new string[] {"twenty", "thirty", "forty", 
                "fifty", "sixty", "seventy", "eighty", "ninety"};
            string wordValue = "";
            if (numberVal == 0) return "zero";
            if (numberVal < 0)
            {
                wordValue = "negative ";
                numberVal = -numberVal;
            }
            long[] partStack = new long[] { 0, 0, 0, 0 };
            int partNdx = 0;
            while (numberVal > 0)
            {
                partStack[partNdx++] = numberVal % 1000;
                numberVal /= 1000;
            }
            for (int i = 3; i >= 0; i--)
            {
                long part = partStack[i];
                if (part >= 100)
                {
                    wordValue += ones[part / 100 - 1] + " hundred ";
                    part %= 100;
                }
                if (part >= 20)
                {
                    if ((part % 10) != 0) wordValue += tens[part / 10 - 2] +
                    " " + ones[part % 10 - 1] + " ";
                    else wordValue += tens[part / 10 - 2] + " ";
                }
                else if (part > 0) wordValue += ones[part - 1] + " ";
                if (part != 0 && i > 0) wordValue += powers[i - 1];
            }
            return wordValue;
        }

		///<remarks>
		///http://extensionmethod.net/csharp/string/isnumeric-2
		///</remarks>
		public static bool IsNumeric(this string theValue)
		{
           long retNum;
           return long.TryParse(theValue, System.Globalization.NumberStyles.Integer, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
		}
	   
		///<remarks>
		///http://extensionmethod.net/csharp/int32/isprime
		///</remarks>
		public static bool IsPrime(this Int64 number) {
			if ((number % 2) == 0) {
				return number == 2;
			}
			Int64 sqrt = (Int64)Math.Sqrt(number);
			for (Int64 t = 3; t <= sqrt; t += 2) {
				if (number % t == 0) {
					return false;
				}
			}
			return number != 1;
		}

		///<remarks>
		///	https://developer.mozilla.org/en-US/docs/Using_files_from_web_applications
		///</remarks>
		public static string MetricSizeBytes(this BigInteger bytes)
        {
			int multiple = 0;
			double approximation = (Double) (bytes / 1024);
			for 
			(
				;
				approximation > 1;
				++multiple, approximation /= 1024
			)
			{
			
			}
			string 	metricSizeBytes = approximation.ToFixed(3) + MetricBytes[multiple] +
					String.Format( BytesFormat, bytes);
            return metricSizeBytes;
        }

		private static string ThreeNonZeroDigits(double value)
		{
			if (value >= 100)
			{
				// No digits after the decimal.
				return value.ToString("0,0");
			}
			else if (value >= 10)
			{
				// One digit after the decimal.
				return value.ToString("0.0");
			}
			else
			{
				// Two digits after the decimal.
				return value.ToString("0.00");
			}
		}

		// Return a file size created by the StrFormatByteSize API function.
		public static string ToFileSizeApi(this long file_size)
		{
			StringBuilder sb = new StringBuilder(20);
			StrFormatByteSize(file_size, sb, 20);
			return sb.ToString();
		}

		// Return a string describing the value as a file size.
		// For example, 1.23 MB.
		///<remarks>
		///	http://csharphelper.com/blog/2014/07/format-file-sizes-in-kb-mb-gb-and-so-forth-in-c/
		///</remarks>
		public static string ToFileSize(this double value)
		{
			string[] suffixes = { "bytes", "KB", "MB", "GB",
				"TB", "PB", "EB", "ZB", "YB"};
			for (int i = 0; i < suffixes.Length; i++)
			{
				if (value <= (Math.Pow(1024, i + 1)))
				{
					return ThreeNonZeroDigits(value /
						Math.Pow(1024, i)) +
						" " + suffixes[i];
				}
			}

			return ThreeNonZeroDigits(value /
				Math.Pow(1024, suffixes.Length - 1)) + 
				" " + suffixes[suffixes.Length - 1];
		}
		
		///<remarks>
		///	stackoverflow.com/questions/6938667/tofixed-function-in-c-sharp
		///</remarks>
		public static string ToFixed(this double number, uint decimals)
        {
            return number.ToString("N" + decimals);
        }
		
		///<remarks>
		///	2015-02-18 http://csharphelper.com/blog/2014/11/convert-an-integer-into-an-ordinal-in-c/
		///</remarks>
		public static string ToOrdinal(this int value)
		{
			// Start with the most common extension.
			string extension = "th";

			// Examine the last 2 digits.
			int last_digits = value % 100;

			// If the last digits are 11, 12, or 13, use th. Otherwise:
			if (last_digits < 11 || last_digits > 13)
			{
				// Check the last digit.
				switch (last_digits % 10)
				{
					case 1:
						extension = "st";
						break;
					case 2:
						extension = "nd";
						break;
					case 3:
						extension = "rd";
						break;
				}
			}

			return extension;
		}
		
		///<remarks>
		///http://extensionmethod.net/csharp/decimal/touistring
		///</remarks>
		public static string ToUIString(this decimal value)
        {
             return value.ToString(CultureInfo.CurrentUICulture);
        }
		
		public const string BytesFormat = " ({0} bytes)";
		public static readonly string[] MetricBytes = {
			"KB",
			"MB",
			"GB",
			"TB",
			"PB",
			"EB",
			"ZB",
			"YB"
		};
	}
}
*/