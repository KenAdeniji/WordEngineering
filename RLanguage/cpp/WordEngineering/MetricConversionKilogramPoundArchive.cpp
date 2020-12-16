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
	const long double KilogramToPound = 2.21L;
	do
	{
		cout << "Menu" << endl;
		cout << "1 Kilogram to Pound." << endl;
		cout << "2 Pound to Kilogram." << endl;
		cout << "0 Exit." << endl;
		cin >> choice;
		switch(choice)
		{
			case 1: Conversion("Kilogram", "Pound", KilogramToPound); break;
			case 2: Conversion("Pound", "Kilogram", 1.0L / KilogramToPound); break;
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
