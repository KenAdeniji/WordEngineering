using System;
using System.IO;

namespace InformationInTransit.ProcessLogic
{
	public class WordsCount
	{
		public static void Main(string[] argv)
		{
			StreamReader reader = null;
			try
			{	
				//Open the file for read only in share mode.
				reader = new StreamReader(argv[SourceFilename]);
				//Read all the content into a single variable.
				string content = reader.ReadToEnd();
				reader.Close();
				//Split the variable into separate array elements.
				string[] wordsSplit = content.Split(WordsSeparator);
				//Print out the length of the array.	
				System.Console.WriteLine("Words count: {0}", wordsSplit.Length);
			}
			catch (Exception ex)
			{
				System.Console.WriteLine(ex.Message);
			}
			finally
			{
				if (reader != null) { reader.Close(); }
			}
		}
		public const int SourceFilename = 0;
		public static readonly char[] WordsSeparator = new char[] { ' ', ',', ';', '.' };
	}
}
