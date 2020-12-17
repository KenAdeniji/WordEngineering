using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.InteropServices;

namespace InformationInTransit.ProcessLogic
{
    public static partial class RuntimeEnvironmentHelper
    {
        public static void Main(string[] argv)
        {
            System.Console.WriteLine(RetrieveRuntimeDirectory());
        }

        public static string RetrieveRuntimeDirectory()
        {
            string currentRunTimeFolder = RuntimeEnvironment.GetRuntimeDirectory();
            return currentRunTimeFolder;
        }
    }
}
