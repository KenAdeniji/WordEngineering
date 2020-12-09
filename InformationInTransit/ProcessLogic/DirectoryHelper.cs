using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace InformationInTransit.ProcessLogic
{
    public static partial class DirectoryHelper
    {
        public static void Main()
        {
            DeleteDirectoryInternetExplorerCache();
        }

        public static void DeleteDirectoryInternetExplorerCache()
        {
            DirectoryInfo internetExplorerCache = new DirectoryInfo
            (
                Environment.GetFolderPath
                (
                    Environment.SpecialFolder.InternetCache
                )
            );
            DeleteDirectory(internetExplorerCache);
            System.Console.WriteLine(internetExplorerCache);
        }

        public static void DeleteDirectory(DirectoryInfo directoryInfo)
        {
            try
            {
                foreach (FileInfo fileInfo in directoryInfo.GetFiles())
                {
                    fileInfo.Delete();
                }

                foreach (DirectoryInfo directoryInfoSubdirectoy in directoryInfo.GetDirectories())
                {
                    DeleteDirectory(directoryInfoSubdirectoy);
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}
