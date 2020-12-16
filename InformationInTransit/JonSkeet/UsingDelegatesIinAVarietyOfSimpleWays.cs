using System;

/*
	2018-09-11	Created.	http://it.guldstadsgymnasiet.se/c%23/C%23%20in%20Depth,%203d%20Edition.pdf
*/
namespace InformationInTransit.JonSkeet
{
	delegate void StringProcessor(string input);
	//Declares compatible instance method
	public class SimpleDelegateUseInstance
	{
		public string Name {get; set;}
		public void Say(string message)
		{
			System.Console.WriteLine("{0} says: {1}", Name, message);
		}	
	}
	//Declares compatible static method
	public class SimpleDelegateUseStatic
	{
		public static void Note(string note)
		{
			System.Console.WriteLine("({0})", note);
		}
	}
	public class UsingDelegatesIinAVarietyOfSimpleWays
	{
		public static void Main()
		{
			SimpleDelegateUseInstance jon = new SimpleDelegateUseInstance{Name = "Jon"};
			SimpleDelegateUseInstance tom = new SimpleDelegateUseInstance{Name = "Tom"};
			StringProcessor jonsVoice, tomsVoice, background;
			jonsVoice = new StringProcessor(jon.Say);
			tomsVoice = new StringProcessor(tom.Say);
			background = new StringProcessor(SimpleDelegateUseStatic.Note);
			jonsVoice("Hello, son.");
			tomsVoice.Invoke("Hello, Daddy!.");
			background("An airplane flies past.");
		}	
	}	
}
