using System;
using System.IO;

namespace InformationInTransit.ProcessLogic
{
	public class FindReplace
	{
		public static void Main(string[] argv)
		{
			StreamReader reader = null;
			StreamWriter writer = null;
			try
			{	
				reader = new StreamReader(argv[SourceFilename]);
				string content = reader.ReadToEnd();
				reader.Close();
				string replace = content.Replace(argv[Find], argv[Replace]);
				writer = new StreamWriter(argv[DestinationFilename]);
				writer.Write(replace);
				writer.Close();
			}
			catch (Exception ex)
			{
				System.Console.WriteLine(ex.Message);
			}
			finally
			{
				if (reader != null) { reader.Close(); }
				if (writer != null) { writer.Close(); }
			}
		}
		public const int SourceFilename = 0;
		public const int DestinationFilename = 1;
		public const int Find = 2;
		public const int Replace = 3;
	}
}


