using System;
using System.Diagnostics.Contracts;

public class ContractTest
{
	private int percentage;
	
	public static void Main(string[] argv)
	{
		ContractTest contractTest = new ContractTest();
		contractTest.Percentage = 110;
	}
	
	public int Percentage
	{
		get { return percentage; }
		set
		{
			Contract.Requires((value >= 0) && (value <= 100));
			percentage = value;
		}
	}
}
