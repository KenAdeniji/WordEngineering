#region Using directives
using System;
using System.IO;

using System.Collections.Generic;
using System.Linq;
using System.Reflection; 	
using System.Text.RegularExpressions;
using System.Threading;
#endregion

namespace InformationInTransit.ProcessLogic
{
    #region FileHelper definition
    public static partial class FileHelper
    {
        #region Methods
        public static void Main(string[] argv)
        {
            ReadFiles(@"c:\", 10);
			SearchOption searchOption = System.IO.SearchOption.TopDirectoryOnly; //AllDirectories
			
			string[] findFiles = FindFiles(@"E:\WordEngineering\IIS\WordEngineering\WordUnion", "*.aspx, *.html", searchOption);
			
			//string[] findFiles = FindFiles(@"", "", searchOption);
			
			foreach(string file in findFiles)
			{
				System.Console.WriteLine(file);
			}	
        }

		public static void FileWrite(string path, string contents)
		{
            // Create a file to write to.
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine(contents);
            }
		}
		
		public static string CurrentAssemblyDirectory()
		{
			string codeBase = Assembly.GetExecutingAssembly().CodeBase;
			UriBuilder uri = new UriBuilder(codeBase);
			string path = Uri.UnescapeDataString(uri.Path);
			return Path.GetDirectoryName(path);
		}
		
        public static bool FileExists(string filePath)
        {
            return File.Exists(filePath);
        }

		/*
			2016-11-17	http://stackoverflow.com/questions/163162/can-you-call-directory-getfiles-with-multiple-filters
			2016-11-17	https://msdn.microsoft.com/en-us/library/ms143316(v=vs.110).aspx
			
			SearchOption searchOption = System.IO.SearchOption.TopDirectoryOnly; //AllDirectories
			string[] findFiles = FindFiles(@"E:\WordEngineering\IIS\WordEngineering\WordUnion", ".aspx, *.html", searchOption);
		*/
		public static string[] FindFiles(string directory, string filters, SearchOption searchOption)
		{
			if (String.IsNullOrEmpty(directory))
			{
				directory = CurrentAssemblyDirectory();
			}		

			if (!Directory.Exists(directory)) return new string[] { };

			var include = (from filter in filters.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries) where !string.IsNullOrEmpty(filter.Trim()) select filter.Trim());
			var exclude = (from filter in include where filter.Contains(@"!") select filter);

			include = include.Except(exclude);

			if (include.Count() == 0) include = new string[] { "*" };

			var rxfilters = from filter in exclude select string.Format("^{0}$", filter.Replace("!", "").Replace(".", @"\.").Replace("*", ".*").Replace("?", "."));
			Regex regex = new Regex(string.Join("|", rxfilters.ToArray()));

			List<Thread> workers = new List<Thread>();
			List<string> files = new List<string>();

			foreach (string filter in include)
			{
				Thread worker = new Thread(
					new ThreadStart(
						delegate
						{
							string[] allfiles = Directory.GetFiles(directory, filter, searchOption);
							if (exclude.Count() > 0)
							{
								lock (files)
									files.AddRange(allfiles.Where(p => !regex.Match(p).Success));
							}
							else
							{
								lock (files)
									files.AddRange(allfiles);
							}
						}
					));

				workers.Add(worker);

				worker.Start();
			}

			foreach (Thread worker in workers)
			{
				worker.Join();
			}

			return files.ToArray();
		}		
		
        /// <example>ReadFiles(@"c:\", 10);</example>
        public static string[] ReadFiles(string directory, int maxFiles)
        {
            return Directory.GetFiles(directory)
                .Take(maxFiles).ToArray();
        }

        public static bool IsImageFile(string filePath)
        {
            return
            (
                Array.IndexOf(ImageFileExtensions, new FileInfo(filePath).Extension)
                >
                -1
            );
        }
        #endregion

        #region Constants and Statics
        public static readonly string[] ImageFileExtensions = new string[]
        {
            ".bid",
            ".bmp",
            ".emf",
            ".gif",
            ".jpeg",
            ".jpg",
            ".png",
            ".tga",
            ".tif",
            ".tiff",
            ".wmf"
        };
        #endregion
    }
    #endregion
}
