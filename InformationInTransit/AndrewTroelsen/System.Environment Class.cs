using System;

class SystemEnvironmentClass
{
	public static void Main(string[] args)
	{
		// OS running this app?
		Console.WriteLine("Current OS: {0} ", Environment.OSVersion);
		// Directory containing this app?
		Console.WriteLine("Current Directory: {0} ", Environment.CurrentDirectory);
		// List the drives on this machine.
		string[] drives = Environment.GetLogicalDrives();
		for(int i = 0; i < drives.Length; i++)
		Console.WriteLine("Drive {0}  : {1} ",  i, drives[i]);
		// Which version of the .NET platform is running this app?
		Console.WriteLine("Executing version of .NET: {0} ", Environment.Version);
	}
}
