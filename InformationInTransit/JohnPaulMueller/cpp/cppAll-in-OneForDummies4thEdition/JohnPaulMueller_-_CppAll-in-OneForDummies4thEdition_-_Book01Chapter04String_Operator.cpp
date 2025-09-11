/*
	http://www.wiley.com/en-us/C%2B%2B+All-in-One+For+Dummies%2C+4th+Edition-p-9781119601739
	C++ All-in-One For Dummies, 4th Edition
	John Paul Mueller 
	ISBN: 978-1-119-60173-9
	December 2020
	912 pages	
	2025-09-09T19:47:00 Date created.
*/
#include <iostream>

using namespace std;

const int CommandLine_Argument_Index_1st = 1; //2025-09-09T18:50:00
const int CommandLine_Argument_Index_2nd = 2;

int main(int argc, char *argv[])
{
	string firstString = string(argv[CommandLine_Argument_Index_1st]);
	cout << "1st string: " << firstString << endl;

	string secondString = string(argv[CommandLine_Argument_Index_2nd]);
	cout << "2nd string: " << secondString << endl;
	
	cout << firstString << " + " << secondString << " = " << firstString + secondString << endl;
	
	cout << firstString << " == " << secondString << " = " << ( ( argv[CommandLine_Argument_Index_1st] == argv[CommandLine_Argument_Index_2nd] ) ? "equal" : "not equal" ) << " (string address reference comparison.)" << endl;
	
	//2025-09-09T20:02:00
	cout << firstString << " == " << secondString << " = " << ( ( firstString == secondString ) ? "equal" : "not equal" ) << " (string content comparison.)" << endl;
	
	cout << firstString << " == " << secondString << " = " << ( ( _stricmp(argv[CommandLine_Argument_Index_1st], argv[CommandLine_Argument_Index_2nd] ) == 0 ) ? "equal" : "not equal" ) << " (string content comparison... ignore case.)" << endl;
}
