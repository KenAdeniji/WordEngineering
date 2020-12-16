#include <iostream>

using namespace std;
//2016-10-03 cl /clr Listing4.6UsingTheSwitchStatementToMakeDecisions.cpp
void main(int argc, char *argv[])
{
	int num;
	
	// Get a number from the user
	cout << "Enter a number from 1 to 7:";
	cin >> num;
	
	// Make a decision based on the number
	switch (num)
	{
		case 1:
			cout << "You chose the number ONE.\n";
			break;
		case 2:
			cout << "You chose the number TWO.\n";
			break;
		case 3:
			cout << "You chose the number THREE.\n";
			break;
		case 4:
			cout << "You chose the number FOUR.\n";
			break;
		case 5:
			cout << "You chose the number FIVE.\n";
			break;
		case 6:
			cout << "You chose the number SIX.\n";
			break;
		case 7:
			cout << "You chose the number SEVEN.\n";
			break;
		default:
			cout << "Your number was not between 1 and 7.\n";
	}	
}
