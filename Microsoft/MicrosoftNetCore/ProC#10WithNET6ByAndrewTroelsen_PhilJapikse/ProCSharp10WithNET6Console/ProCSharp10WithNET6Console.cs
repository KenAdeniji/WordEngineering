using ProCSharp10WithNET6Library;

namespace ProCSharp10WithNET6Console;

public static class ProCSharp10WithNET6Console
{
	// See https://aka.ms/new-console-template for more information
	public static void Main(String[] argv)
	{
		foreach(string word in argv)
		{
			System.Console.WriteLine
			(
				"Forward: {0} Backward: {1}",
				HowITryToBeAsIHaveAssociated.Forward( word ),
				HowITryToBeAsIHaveAssociated.Backward( word )
			);
		}	
	}	
}	
