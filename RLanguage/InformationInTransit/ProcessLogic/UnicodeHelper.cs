using System;
using System.Text;

namespace InformationInTransit.ProcessLogic
{
    class UnicodeHelper
    {
        public static void Main()
        {
			UseUnicode();
        }

		///<remarks>
		/// 2015-02-13	http://csharphelper.com/blog/2015/01/display-unicode-symbols-in-c/
		///</remarks>
		public static String Capture()
		{
			string txt = "fff";
			for (int i = 0x460; i < 0x470; i++)
			{
				txt += (char)i;
			}
			return txt;
		}
		
		///<remarks>
		/// 2015-02-13	https://msdn.microsoft.com/en-us/library/system.text.unicodeencoding%28v=vs.110%29.aspx
		///</remarks>
		public static void UseUnicode() 
		{
			// The encoding.
			UnicodeEncoding unicode = new UnicodeEncoding();

			// Create a string that contains Unicode characters.
			String unicodeString =
				"This Unicode string contains two characters " +
				"with codes outside the traditional ASCII code range, " +
				"Pi (\u03a0) and Sigma (\u03a3).";
			Console.WriteLine("Original string:");
			Console.WriteLine(unicodeString);

			// Encode the string.
			Byte[] encodedBytes = unicode.GetBytes(unicodeString);
			Console.WriteLine();
			Console.WriteLine("Encoded bytes:");
			foreach (Byte b in encodedBytes) {
				Console.Write("[{0}]", b);
			}
			Console.WriteLine();

			// Decode bytes back to string. 
			// Notice Pi and Sigma characters are still present.
			String decodedString = unicode.GetString(encodedBytes);
			Console.WriteLine();
			Console.WriteLine("Decoded bytes:");
			Console.WriteLine(decodedString);
		}
    }
}
