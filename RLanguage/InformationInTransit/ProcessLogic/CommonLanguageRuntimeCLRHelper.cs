#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.InteropServices;
#endregion

namespace InformationInTransit.ProcessLogic
{
    #region CommonLanguageRuntimeCLRHelper definition
    public static partial class CommonLanguageRuntimeCLRHelper
    {
        public static void Main(string[] argv)
        {
            GetRuntimeDirectory();
            GetSystemVersion();
        }

        /// <summary>
        /// RuntimeEnvironment.GetRuntimeDirectory() gets .NET installation directory. 
        /// </summary>
        public static string GetRuntimeDirectory()
        {
            string runtimeDirectory = RuntimeEnvironment.GetRuntimeDirectory();
            System.Console.WriteLine("RuntimeDirectory: {0}", runtimeDirectory);
            return runtimeDirectory;
        }

        /// <summary>
        /// RuntimeEnvironment.GetSystemVersion() gets the version of the CLR that is running the current process.
        /// </summary>
        public static string GetSystemVersion()
        {
            string clrVersion = RuntimeEnvironment.GetSystemVersion();
            System.Console.WriteLine("CLR Version: {0}", clrVersion);
            return clrVersion;
        }
    }
    #endregion
}
