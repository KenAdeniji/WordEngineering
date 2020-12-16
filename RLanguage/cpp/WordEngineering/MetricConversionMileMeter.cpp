#include <iostream>

using namespace std;

/*
	2018-10-08	Created.
*/

void Menu();
void Conversion(char *, char *, long double);

void main(int argc, char *argv[])
{
	Menu();
}

void Menu()
{
	int choice = 1;
	const long double MileToMeter = 1609L;
	do
	{
		cout << "Menu" << endl;
		cout << "1 Mile to Meter." << endl;
		cout << "2 Meter to Mile." << endl;
		cout << "0 Exit." << endl;
		cin >> choice;
		switch(choice)
		{
			case 1: Conversion("Mile", "Meter", MileToMeter); break;
			case 2: Conversion("Meter", "Mile", 1.0L / MileToMeter); break;
		}	
	}
	while (choice >= 1);	
}

void Conversion(char* fromUnit, char *toUnit, long double multiplier)
{
	double entry;
	cout << fromUnit << " ";
	cin >> entry;
	cout << entry * multiplier << ' ' << toUnit << endl;
}
