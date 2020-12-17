using System;
using System.Linq;

using System.Diagnostics;
using System.ComponentModel;

namespace InformationInTransit.ProcessLogic
{
	static class HelloLinqProcess
	{
		static void Main()
		{
			DisplayProcesses();
		}
		
		static void DisplayProcesses()
		{
			var processes =
			Process.GetProcesses()
			.Where(process => process.WorkingSet64 > 20*1024*1024)
			.OrderByDescending(process => process.WorkingSet64)
			.Select(process => new { process.Id,
					Name=process.ProcessName });
			ObjectDumper.Write(processes);
		}
	}
}
