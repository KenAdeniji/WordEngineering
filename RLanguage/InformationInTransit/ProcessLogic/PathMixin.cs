using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace InformationInTransit.ProcessLogic
{
    public static partial class PathMixin
    {
        public static bool Exists(this IPath srcPath)
        {
            bool fileExists = File.Exists(srcPath.FilePath);
            bool dirExists = Directory.Exists(srcPath.FilePath);
            return fileExists || dirExists;
        }

        public static IEnumerable<string> FullPathComponents(this IPath srcPath)
        {
            string fullPath = Path.GetFullPath(srcPath.FilePath);
            string[] components = fullPath.Split
            (
                Path.VolumeSeparatorChar,
                Path.PathSeparator,
                Path.DirectorySeparatorChar
            );

            foreach (string s in components)
            {
                if (String.IsNullOrEmpty(s) == false)
                {
                    yield return s;
                }
            }
        }

        public static bool IsDirectory(this IPath srcPath)
        {
            return Directory.Exists(srcPath.FilePath);
        }

        public static bool IsFile(this IPath srcPath)
        {
            return File.Exists(srcPath.FilePath);
        }
    }
}
