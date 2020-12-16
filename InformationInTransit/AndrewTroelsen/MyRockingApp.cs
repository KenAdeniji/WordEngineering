using System;
using System.Windows.Forms;

public static partial class MyRockingApp
{
	static void Main(string[] args)
	{
		// Set up Console UI (CUI)
		Console.Title = "My Rocking App";
		Console.ForegroundColor = ConsoleColor.Yellow;
		Console.BackgroundColor = ConsoleColor.Blue;
		Console.WriteLine("*************************************");
		Console.WriteLine("***** Welcome to My Rocking App *****");
		Console.WriteLine("*************************************");
		Console.BackgroundColor = ConsoleColor.Black;
		// Wait for Enter key to be pressed.
		Console.ReadLine();
		MessageBox.Show("All done!");
	}
}
