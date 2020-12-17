using System;

class ProcessingCommandLineArguments
{
	public static void Main(string[] args)
	{
		Console.WriteLine("***** Command line args *****");
		for(int i = 0; i < args.Length; i++)
		{	
			Console.WriteLine("Arg: {0} ", args[i]);
		}

		string[] theArgs = Environment.GetCommandLineArgs();
		Console.WriteLine("Path to this app is: {0}", theArgs[0]);		
	}
}
