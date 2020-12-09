using System;
using System.Globalization;

public static partial class GlobalizationHelper
{
	public static void Main(string[] argv)
	{
		System.Console.WriteLine(CustomFormatCurrencyWithoutTheDecimalPlace((decimal)132.79));
	}

	public static string CustomFormatCurrencyWithoutTheDecimalPlace(decimal input)
	{
		System.Globalization.NumberFormatInfo nfi = new System.Globalization.NumberFormatInfo();
		nfi.CurrencyDecimalDigits = 0;
		nfi.CurrencySymbol = "$";
		string whole = String.Format(nfi, "{0:C}", input);
		return whole;
	} 
}
