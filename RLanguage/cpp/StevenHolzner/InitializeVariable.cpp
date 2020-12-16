// compile: cl /GR /EHsc InitializeVariable.cpp
/*
	2017-11-16	Created. Steven Holzner.
*/

#include <iostream>
#include <string>

using namespace std;

int main()
{
	const double pi = { 22.0 / 7.0 };
	cout << "PI: " << pi << endl;
	cout << "Size of the double variable type: " << sizeof (double) << " bytes. " << endl;
	cout << "Size of the pi variable: " << sizeof pi << " bytes. " << endl;
	
	//enum class Day {Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday};
	enum Day {Monday = 1, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday};
	Day restDay {Day::Sunday};
	cout << "Rest day: " << restDay << endl;	
}
