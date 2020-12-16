// compile: cl /GR /EHsc InitializeVariable.cpp
/*
	2017-11-16	Created. Steven Holzner.
*/

#include <iostream>
#include <string>

using namespace std;

namespace WordEngineering
{
	const double pi = { 22.0 / 7.0 };
}	

using namespace WordEngineering;

int main()
{
	cout << "PI: " << pi << endl;
	cout << "Size of the double variable type: " << sizeof (double) << " bytes. " << endl;
	cout << "Size of the pi variable: " << sizeof pi << " bytes. " << endl;
}
