using System;
using System.IO;
using System.Text;

/*
	2024-07-23	http://convert-me.com
	Created: 2024-07-29T06:19:00...2024-07-29T06:47:00
	http://stackoverflow.com/questions/18757097/writing-data-into-csv-file-in-c-sharp
*/
public class ConversionTableTemperatureCommaSeparatedValueCSV
{
	public static void Main(string[] argv)
	{
		CSVWriter();
	}	
	
	public static void CSVWriter()
	{
		StringBuilder sb = new StringBuilder
		(
			"Celsuis,Fahrenheit,Kelvin" + System.Environment.NewLine
		);
		double celsuis, fahrenheit, kelvin;
		for (celsuis = 0; celsuis <= 100; ++celsuis)
		{
			fahrenheit = (celsuis * 9.0 / 5.0) + 32;
			kelvin = fahrenheit + 100;
			sb.AppendFormat
			(
				"{0},{1},{2}",
				celsuis,
				fahrenheit,
				kelvin
			);
			sb.Append(System.Environment.NewLine);
		}		
		File.WriteAllText
		(
			ConversionTableTemperatureFileName,
			sb.ToString()
		);
	}

	public const String ConversionTableTemperatureFileName = "ConversionTableTemperature.csv";
}	