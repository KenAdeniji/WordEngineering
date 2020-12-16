#include <iostream>

using namespace std;
//2016-10-03 cl /clr Listing5.2UsingAForLoopToGenerateATableOfFahrenheitToCelsuisTemperatureConversions.cpp

void main(int argc, char *argv[])
{
	float celsuis = 0;
	cout << "Fahrenheit" << "\t" << "Celsuis" << '\n';
	for (int fahrenheit = 32; fahrenheit <= 212; ++fahrenheit)
	{
		celsuis = 5.0 / 9.0 * (fahrenheit - 32);
		cout << fahrenheit << "\t\t" << celsuis << '\n';
	}		
}
