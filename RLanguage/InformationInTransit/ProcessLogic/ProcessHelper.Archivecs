using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Diagnostics;
using System.ComponentModel;

namespace InformationInTransit.ProcessLogic
{
    public static partial class ProcessHelper
    {
        public static void Main(string[] argv)
        {
            //ServiceCommand(argv[0], argv[1]);
            //System.Console.WriteLine( IsProcessRunning("Notepad") );
			Running();
        }

        /// <summary>
        /// http://codekeep.net/snippets/2c610f90-f8f1-4b21-a3ac-288865ae73c5.aspx
        /// 2014-04-04 Dave Donaldson
        /// </summary>
        /// <param name="name">The process name, with no extension, for example, Notepad.</param>
        public static bool IsProcessRunning(string name)
        {
            try
            {
                Process[] localProcesses = Process.GetProcessesByName(name);
                if (localProcesses.Length < 1)
                {
                    return false;
                }
                return true;
            }
            catch (InvalidOperationException ex)
            {
                throw;
            }
        }

		//2018-11-03	apress.com/us/book/9781484213339
		public static List<String> Running()
		{
			List<String> runningProcesses =
				(from proc in Process.GetProcesses(".") orderby proc.Id select proc.ProcessName).ToList();
			return runningProcesses;	
		}
		
        /// <summary>
        /// http://codekeep.net/snippets/b767b96a-ac85-49e9-8a72-5caadc365461.aspx
        /// 2014-04-04 Dave Donaldson
        /// </summary>
        /// <param name="command">Start</param>
        /// <param name="displayName">Telephony</param>
        public static bool ServiceCommand(string command, string displayName)
        {
            string netProcessArguments = String.Format
            (
                NetProcessArguments,
                command,
                displayName
            );
            
            try
            {
                Process p = Process.Start(NetProcessName, netProcessArguments);
                p.EnableRaisingEvents = true;
                p.WaitForExit();

                if (p.ExitCode == 0)
                {
                    return true;
                }
                return false;
            }
            // If the service can't be found, the runtime throws a Win32Exception
            catch (Win32Exception ex)
            {
                throw;
            }
        }

        public const string NetProcessName = "Net.exe";
        public const string NetProcessArguments = "{0} \"{1}\" ";
    }
}
