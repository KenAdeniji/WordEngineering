/*
	http://www.wiley.com/en-us/C%2B%2B+All-in-One+For+Dummies%2C+4th+Edition-p-9781119601739
	John@JohnMuellerBooks.com
	C++ All-in-One For Dummies, 4th Edition
	John Paul Mueller 
	ISBN: 978-1-119-60173-9
	December 2020
	912 pages	
	2025-09-09T19:06:00 Date created.
		C++ 20
		Spaceship operator <=>
			std::strong_ordering::less		=	-1
			std::strong_ordering::equal		=	0
			std::strong_ordering::greater	=	1
			Wandbox.org is 1 of the online compilers that fully implements this operator.
	2025-09-10T13:23:00 I differed... from your numeric handling of the value of the result.
        Spaceship operator, <=>, is the result type an enum?			
*/
#include <iostream>
#include <cstdlib>

using namespace std;

const int CommandLine_Argument_Index_1st = 1; //2025-09-09T18:50:00
const int CommandLine_Argument_Index_2nd = 2;

int main(int argc, char *argv[])
{
/*
	string firstString = string(argv[CommandLine_Argument_Index_1st]);
	cout << "1st string: " << firstString << endl;

	string secondString = string(argv[CommandLine_Argument_Index_2nd]);
	cout << "2nd string: " << secondString << endl;
*/

	string firstString;
	cout << "1st string: " << endl;
	cin >> firstString;

	string secondString;
	cout << "2nd string: " << endl;
	cin >> secondString;

	std::strong_ordering result = firstString <=> secondString;
	
	string stringComparison = "";
	
	if ( result == std::strong_ordering::less ) { stringComparison = "less"; }
	else if ( result == std::strong_ordering::equal ) { stringComparison = "equal"; }
	else if ( result == std::strong_ordering::greater ) { stringComparison = "greater"; }

	cout << "stringComparison: " << stringComparison << endl;	
}
