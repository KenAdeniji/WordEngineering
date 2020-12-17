using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InformationInTransit.ProcessLogic
{
    public class PathSample : IPath
    {
        public string FilePath
        {
            get
            {
                return @"C:\WordEngineering\IIS\WordEngineering\Web.config";
            }
        }

        public static void Main(string[] argv)
        {
            PathSample pathSample = new PathSample();
            foreach (string component in pathSample.FullPathComponents())
            {
                System.Console.WriteLine(component);
            }
        }
    }
}
