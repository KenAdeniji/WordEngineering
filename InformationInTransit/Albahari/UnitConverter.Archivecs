using System;

public class UnitConverter
{
	public int Ratio { get; set; }
	
	public UnitConverter(int ratio)
	{
		this.Ratio = ratio;
	}
	
	public int Convert(int unit)
	{
		return unit * Ratio;
	}
}	

public class UnitConverterStub
{
	public static void Main()
	{
		UnitConverter feetToInches = new UnitConverter(12);
		UnitConverter milesToFeet = new UnitConverter(5280);
		
		System.Console.WriteLine(feetToInches.Convert(30));
		System.Console.WriteLine(feetToInches.Convert(100));
	}	
}	

