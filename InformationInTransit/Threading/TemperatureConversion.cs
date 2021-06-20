using System;
using System.Threading.Tasks;

namespace InformationInTransit.Threading
{
	/*
		2021-06-17T17:18:00 Created.
			https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.parallel?view=net-5.0	
	*/
    public static partial class TemperatureConversion
    {
		public static void Main(String[] argv)
		{
			TestMethod();
		}

		static void TestMethod()
		{
			// Using a named method.
			Parallel.For(0, 100, MethodFromCelsuis);
			
			// Using an anonymous method.
			Parallel.For(32, 212, delegate(int fahrenheit)
			{
				System.Console.WriteLine
				(
					"To Celsuis: {0} | From Fahrenheit: {1} | To Kelvin: {2}",
					( ( fahrenheit - 32 ) * (5.0 / 9.0)),
					fahrenheit,
					( ( fahrenheit - 32 ) * (5.0 / 9.0)) + 273.15
				);
			});

			// Using a lambda expression.
			Parallel.For(273, 373, kelvin =>
			{
				System.Console.WriteLine
				(
					"To Celsuis: {0} | To Fahrenheit: {1} | From Kelvin: {2}",
					kelvin - 273,
					( ( kelvin - 273.15 ) * ( 9.0 / 5.0) ) + 32,
					kelvin
				);
			});			
		}

		static void MethodFromCelsuis(int celsuis)
		{
			System.Console.WriteLine
			(
				"From Celsuis: {0} | To Fahrenheit: {1} | To Kelvin: {2}",
				celsuis,
				((9.0 / 5.0) * celsuis) + 32,
				celsuis + 273.15
			);
		}
    }
}
