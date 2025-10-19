/*
	2025-09-15T08:34:04	http://nostarch.com/c-type-system
	2025-09-15T08:34:04	http://www.google.com/books/edition/The_C_Type_System/T2y1EAAAQBAJ?hl=en
	2025-09-17T06:02:00	Source file created.
	hotweird@hotmail.com
		commandlinearguments.codeplex.com
*/	
using System;

using InformationInTransit.ProcessLogic;

class SteveLove_TheCSharpTypeSystem_Projectile_Arguments
{
	[Argument(ArgumentType.AtMostOnce, HelpText="angle")]
	public string angle;
	[Argument(ArgumentType.AtMostOnce, HelpText="speed")]
	public int speed;
	[Argument(ArgumentType.AtMostOnce, HelpText="elapsedTime")]
	public int elapsedTime;
}

public static partial class SteveLove_TheCSharpTypeSystem_Projectile
{
	public static void Main(string[] argv)
	{
		SteveLove_TheCSharpTypeSystem_Projectile_Arguments parsedArgs = new SteveLove_TheCSharpTypeSystem_Projectile_Arguments();
		if (Parser.ParseArgumentsWithUsage(argv, parsedArgs))
		{
			//var result = Displacement(angle:.523, speed:65, elapsedTime:4);
			var result = Displacement
			(
				angle:Convert.ToDouble(parsedArgs.angle), 
				speed:parsedArgs.speed, 
				elapsedTime:parsedArgs.elapsedTime
			);
			System.Console.WriteLine(result);
		}
	}
	
	public static (double, double) Displacement
	(
		double angle,
		double speed,
		double elapsedTime
	)
	{
		var x = speed * elapsedTime * Math.Cos(angle);
		var y = speed * elapsedTime * Math.Sin(angle) - 0.5 * Gravity.Earth * Math.Pow(elapsedTime, 2);
		return(x, y);
	}	
}	

public static partial class Gravity
{
	public const double Earth = 9.81;
}
	
