#include <iostream>

using namespace std;
//2016-10-03 cl /clr Listing4.5UsingAnIfStatementToMakeADecisionBasedOnUserInput.cpp
void main(int argc, char *argv[])
{
	int num;
	
	// Get a number from the user
	cout << "Enter a number from 1 to 7:";
	cin >> num;
	
	// Make a decision based on the number
	if (1 == num) {
		cout << "You chose the number ONE.\n";
	}
	else if (2 == num) {
		cout << "You chose the number TWO.\n";
	}
	else if (3 == num) {
		cout << "You chose the number THREE.\n";
	}
	else if (4 == num) {
		cout << "You chose the number FOUR.\n";
	}
	else if (5 == num) {
		cout << "You chose the number FIVE.\n";
	}
	else if (6 == num) {
		cout << "You chose the number SIX.\n";
	}
	else if (7 == num) {
		cout << "You chose the number SEVEN.\n";
	}
	else {
		cout << "Your number was not between 1 and 7.\n";
	}	
}
