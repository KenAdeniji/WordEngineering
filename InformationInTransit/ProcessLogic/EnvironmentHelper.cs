#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualBasic.Devices;	
#endregion

namespace InformationInTransit.ProcessLogic
{
	/*
		2017-04-20	Created.	apress.com/us/book/9781484213339
		2017-04-20	https://msdn.microsoft.com/en-us/library/system.environment.exit.aspx
		2017-07-21	https://stackoverflow.com/questions/577634/how-to-get-the-friendly-os-version-name
	*/
    #region EnvironmentHelper definition
    public static partial class EnvironmentHelper
    {
        #region Methods
		public static void Main(string[] argv)
		{
			Stub();
		}

		public static void Stub()
		{
			var versionID = new ComputerInfo().OSVersion;//6.1.7601.65536
			var versionName = new ComputerInfo().OSFullName;//Microsoft Windows 7 Ultimate
			var verionPlatform = new ComputerInfo().OSPlatform;//WinNT

			System.Console.WriteLine("Application Name: {0}", System.Environment.GetCommandLineArgs()[0]);
			System.Console.WriteLine("Is64BitOperatingSystem: {0}", System.Environment.Is64BitOperatingSystem);
			System.Console.WriteLine("Machine Name: {0}", System.Environment.MachineName);
			System.Console.WriteLine("NewLine: {0}", System.Environment.NewLine);
			System.Console.WriteLine(".NET Version: {0}", System.Environment.Version);
			System.Console.WriteLine("Operating System (OS) Version: {0}", System.Environment.OSVersion);
			System.Console.WriteLine("Operating System (OS) Version: {0}", new ComputerInfo().OSVersion);
			System.Console.WriteLine("Operating System (OS) FullName: {0}", new ComputerInfo().OSFullName);
			System.Console.WriteLine("Operating System (OS) Platform: {0}", new ComputerInfo().OSPlatform);
			System.Console.WriteLine("Processor count: {0}", System.Environment.ProcessorCount);			
			System.Console.WriteLine("System Directory: {0}", System.Environment.SystemDirectory);
			System.Console.WriteLine("User Name: {0}", System.Environment.UserName);
			//System.Environment.Exit(0);
		}	
        #endregion
    }
    #endregion
}
