/*
	http://www.wiley.com/en-us/C%2B%2B+All-in-One+For+Dummies%2C+4th+Edition-p-9781119601739
	C++ All-in-One For Dummies, 4th Edition
	John Paul Mueller 
	ISBN: 978-1-119-60173-9
	December 2020
	912 pages	
	2025-09-09T18:04:00 They will like the Bible... their own way.
	2025-09-09T18:46:00	http://stackoverflow.com/questions/33029252/converting-char-array-to-integer
	2025-09-09T18:50:00	http://stackoverflow.com/questions/9702053/how-to-declare-a-global-variable-in-c
	2025-09-09T18:57:00...2025-09-09T19:05:00	
						c++ operator iterate + - / * substitution
						http://en.cppreference.com/w/cpp/language/operators.html
*/
#include <iostream>

using namespace std;

const int CommandLine_Argument_Index_1st = 1; //2025-09-09T18:50:00
const int CommandLine_Argument_Index_2nd = 2;

const int NULL_Character = '\0';
const int Newline_Character = '\n';
const int Carriage_Return_Character = '\r';
const int Tab_Character = '\t';
const int Double_Quote_Character = '"';
const int Single_Quote_Character = '\'';
const int Backslash_Character = '\\';

int main(int argc, char *argv[])
{
	int firstNumber = atoi(argv[CommandLine_Argument_Index_1st]);
	cout << "1st integer: " << firstNumber << endl;

	int secondNumber = atoi(argv[CommandLine_Argument_Index_2nd]);
	cout << "2nd integer: " << secondNumber << endl;
	
	cout << firstNumber << " + " << secondNumber << " = " << firstNumber + secondNumber << endl;
	cout << firstNumber << " - " << secondNumber << " = " << firstNumber - secondNumber << endl;
	cout << firstNumber << " * " << secondNumber << " = " << firstNumber * secondNumber << endl;
	cout << firstNumber << " / " << secondNumber << " = " << firstNumber / secondNumber << endl;
	cout << firstNumber << " % " << secondNumber << " = " << firstNumber % secondNumber << endl;
}
