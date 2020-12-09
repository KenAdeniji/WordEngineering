using System;
using System.Management;

namespace InformationInTransit.ProcessLogic
{
	public static partial class ManagementHelper
	{
		public static void Main(string[] argv)
		{
			DumpAllLocalRootNamespacesClasses();
		}
		
		public static void DumpAllLocalRootNamespacesClasses()
		{
			string cimRoot = "root\\";
			ManagementClass nameSpaceClass = new ManagementClass
			(
				new ManagementScope(@"root"),
				new ManagementPath("__namespace"),
				null
			);
			foreach(ManagementObject nameSpace in nameSpaceClass.GetInstances())
			{
				System.Console.WriteLine(cimRoot + nameSpace["Name"].ToString());
				ManagementClass managementClass = new ManagementClass
				(
					cimRoot +
					nameSpace["Name"].ToString()
				);
				EnumerationOptions enumerationOptions = new EnumerationOptions();
				enumerationOptions.EnumerateDeep = true; // set to false if only the root classes are needed
				ManagementObjectCollection managementObjectCollection = managementClass.GetSubclasses(enumerationOptions);
				foreach(ManagementObject managementObject in managementObjectCollection)
				{
					if (managementObject["__SuperClass"] == null)
					{
						System.Console.WriteLine(managementObject["__Class"]);
					}
					else
					{
						System.Console.WriteLine("\t" + managementObject["__Class"]);
					}
				}
			}
		}
		
		public static void ExportedSharedFolders()
		{
			using(ManagementClass exportedShares = new ManagementClass("Win32_Share" ))
			using(ManagementClass computer = new ManagementClass("Win32_computersystem" ))
			{
				string localSystem = null;
				ManagementObjectCollection localComputer = computer.GetInstances();
				foreach(ManagementObject managementObject in localComputer)
				{
					localSystem = managementObject["Name"].ToString();
				}
				ManagementObjectCollection shares = exportedShares.GetInstances();
				foreach(ManagementObject share in shares)
				//dump UNC path
				System.Console.WriteLine(@"UNC path \\{0}\{1}", localSystem, share["Name"]);
			}				
		}
	}
}

