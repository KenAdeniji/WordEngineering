using System;
using System.Collections.Generic;
using System.Management;

///<summary>
///	csc WindowsManagmentInterfaceWMIHelper.cs /reference:System.Management.dll
/// </summary>
namespace InformationInTransit.ProcessLogic
{
	public static partial class WindowsManagmentInterfaceWMIHelper
	{
		static void Main(string[] args)
		{
			//InstalledSoftware();

			List<string> boardSerialNumbers = RetrieveBoardSerialNumbers();
			foreach(string boardSerialNumber in boardSerialNumbers)
			{
				System.Console.WriteLine("Board Serial Number: {0}", boardSerialNumber);
			}
			
			List<string> cpuIds = RetrieveCpuIds();
			foreach(string cpuId in cpuIds)
			{
				System.Console.WriteLine("CPU Id: {0}", cpuId);
			}
			
			List<string> processorIds = RetrieveInfo("Win32_Processor", "ProcessorId");
			foreach(string processorId in processorIds)
			{
				System.Console.WriteLine("CPU Id: {0}", processorId);
			}
			
			RetrieveOperatinSystem();
			
			int physicalProcessorsCount;
			int coresCount;
			int logicalProcessorsCount;
			int	addressWidth;
			
			RetrieveProcessorCounts
			(
				out physicalProcessorsCount,
				out coresCount,
				out logicalProcessorsCount,
				out	addressWidth
			);
			
			System.Console.WriteLine
			(
				"Physical Processors: {0} | Cores: {1} | Logical Processors: {2} | Address Width: {3}",
				physicalProcessorsCount,
				coresCount,
				logicalProcessorsCount,
				addressWidth
			);
		}
		
		///<remarks>
		///http://code.msdn.microsoft.com/Get-a-list-of-Installed-9620d03d
		///</remarks>
		public static void InstalledSoftware()
		{
			ManagementObjectCollection managementObjectCollection;   
			ManagementObjectSearcher managementObjectSearcher; 
	 
			managementObjectSearcher = new ManagementObjectSearcher("Select * from Win32_Product"); 
	 
			managementObjectCollection = managementObjectSearcher.Get(); 
			foreach(ManagementObject mo in managementObjectCollection) 
			{ 
				System.Console.WriteLine(mo["Name"].ToString()); 
			} 
		}
	
		///<remarks>
		///	http://csharphelper.com/blog/2014/12/use-wmi-to-get-the-systems-board-serial-numbers-and-cpu-ids-in-c/
		///</remarks>
		///<example>
		///	List<string> boardSerialNumbers = RetrieveBoardSerialNumbers();
		///	foreach(string boardSerialNumber in boardSerialNumbers)
		///	{
		///		System.Console.WriteLine(boardSerialNumber);
		///	}
		///</example>
		public static List<string> RetrieveBoardSerialNumbers()
		{
			List<string> results = new List<string>();

			string query = "SELECT * FROM Win32_BaseBoard";
			ManagementObjectSearcher searcher =
				new ManagementObjectSearcher(query);
			foreach (ManagementObject info in searcher.Get())
			{
				results.Add(
					info.GetPropertyValue("SerialNumber").ToString());
			}

			return results;
		}
	
		///<remarks>
		///	http://csharphelper.com/blog/2014/12/use-wmi-to-get-the-systems-board-serial-numbers-and-cpu-ids-in-c/
		///</remarks>
		///<example>
		///List<string> cpuIds = RetrieveCpuIds();
		///foreach(string cpuId in cpuIds)
		///{
		///	System.Console.WriteLine("CPU Id: {0}", cpuId);
		///}
		///</example>
		public static List<string> RetrieveCpuIds()
		{
			List<string> results = new List<string>();

			string query = "SELECT * FROM Win32_Processor";
			ManagementObjectSearcher searcher =
				new ManagementObjectSearcher(query);
			foreach (ManagementObject info in searcher.Get())
			{
				results.Add(
					info.GetPropertyValue("ProcessorId").ToString());
			}

			return results;
		}

		///<example>
		///List<string> processorIds = RetrieveInfo("Win32_Processor", "ProcessorId");
		///foreach(string processorId in processorIds)
		///{
		///	System.Console.WriteLine("CPU Id: {0}", processorId);
		///}
		///</example>
		public static List<string> RetrieveInfo(string container, string column)
		{
			List<string> results = new List<string>();

			string query = String.Format(SQLStatement, container, column);
			ManagementObjectSearcher searcher =
				new ManagementObjectSearcher(query);
			foreach (ManagementObject info in searcher.Get())
			{
				results.Add(
					info.GetPropertyValue(column).ToString());
			}

			return results;
		}

		///<remarks>
		///http://csharphelper.com/blog/2015/02/use-wmi-get-number-physical-logical-processors-c/
		///</remarks>
		///<example>
		///	int physicalProcessorsCount;
		///	int coresCount;
		///	int logicalProcessorsCount;
		///	
		///	RetrieveProcessorCounts
		///	(
		///		out physicalProcessorsCount,
		///		out coresCount,
		///		out logicalProcessorsCount
		///	);
		///	
		///	System.Console.WriteLine
		///	(
		///		"Physical Processors: {0} | Cores: {1} | Logical Processors: {2}",
		///		physicalProcessorsCount,
		///		coresCount,
		///		logicalProcessorsCount
		///	);
		///</example>
		public static void RetrieveProcessorCounts
		(
			out int physicalProcessorsCount,
			out int coresCount,
			out int logicalProcessorsCount,
			out	int	addressWidth
		)
		{
			string query;
			ManagementObjectSearcher searcher;

			// Get the number of physical processors.
			physicalProcessorsCount = 0;
			query = "SELECT * FROM Win32_ComputerSystem";
			searcher = new ManagementObjectSearcher(query);
			foreach (ManagementObject sys in searcher.Get())
				physicalProcessorsCount =
					int.Parse(sys["NumberOfProcessors"].ToString());

			// Get the number of cores.
			query = "SELECT * FROM Win32_Processor";
			coresCount = 0;
			addressWidth = 0;
			searcher = new ManagementObjectSearcher(query);
			foreach (ManagementObject proc in searcher.Get())
			{
				coresCount += int.Parse(proc["NumberOfCores"].ToString());
				addressWidth = int.Parse(proc["AddressWidth"].ToString());
			}
			
			logicalProcessorsCount = Environment.ProcessorCount;
		}

		///<remarks>
		///	http://csharphelper.com/blog/2014/08/use-wmi-to-get-information-including-the-operating-systems-name-in-c/
		///<remarks>
		public static void RetrieveOperatinSystem()
		{
			// Get the OS information.
			// For more information from this query, see:
			//      http://msdn.microsoft.com/library/aa394239.aspx
			string os_query = "SELECT * FROM Win32_OperatingSystem";
			ManagementObjectSearcher os_searcher =
				new ManagementObjectSearcher(os_query);
			foreach (ManagementObject info in os_searcher.Get())
			{
				String caption = info.Properties["Caption"].Value.ToString().Trim();
				String version = "Version " +
					info.Properties["Version"].Value.ToString() +
					" SP " +
					info.Properties["ServicePackMajorVersion"].Value.ToString()
					+ "." +
					info.Properties["ServicePackMinorVersion"].Value.ToString();
				System.Console.WriteLine
				(
					"Operating System Caption: {0} | Version: {1}",
					caption,
					version
				);
			}
		}
		
		public const string SQLStatement = "SELECT {1} FROM {0}";
	}
}
