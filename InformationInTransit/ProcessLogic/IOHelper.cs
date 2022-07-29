using System;
using System.IO;
using System.Linq;

namespace InformationInTransit.ProcessLogic
{
	public static partial class IOHelper
	{
		public static void Main(string[] argv)
		{
			System.Console.WriteLine("Temporary File Path: {0}", RetrieveTemporaryPath());
		}
		
		///<remarks>
		///http://extensionmethod.net/csharp/int64/foldersize
		///</remarks>
		///<example>
		///path = @"D:\INCOMING\Books";
		///var size = new DirectoryInfo(path).FolderSize(true);
		///Console.WriteLine("Size of {0} is {1}", path, size);
		///</example>		
		public static long FolderSize(this DirectoryInfo dir, bool bIncludeSub)
		{
			long totalFolderSize = 0;
	 
			if (!dir.Exists)
			{
				return 0;
			}	
	 
			var files = from f in dir.GetFiles()
						select f;
			
			foreach (var file in files) 
			{
				totalFolderSize += file.Length;
			}	
	 
			if (bIncludeSub)
			{
				var subDirs = from d in dir.GetDirectories()
							  select d;
				foreach (var subDir in subDirs) 
				{
					totalFolderSize += FolderSize(subDir, true);
				}	
			}
	 
			return totalFolderSize;
		}

		///<remarks>
		///http://www.devx.com/dotnet/get-the-path-to-the-temporary-folder-in-the-operating-system
		///</remarks>
		///<example>
		///System.Console.WriteLine("Temporary File Path: {0}", RetrieveTemporaryPath());
		///</example>
		public static string RetrieveTemporaryPath()
		{
			string temporaryFilePath = System.IO.Path.GetTempPath();
			return temporaryFilePath;
		}	
	}	
}
