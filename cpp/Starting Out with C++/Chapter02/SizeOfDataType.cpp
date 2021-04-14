/*
	2021-04-12T16:47:00	Created.
		cl /GR /EHsc SizeOfDataType.cpp
*/

#include <iostream>

using namespace std;

int main()
{
	long double longDouble;
	cout << "The size of an integer is " << sizeof(int) << " bytes." << endl;
	cout << "The size of a long is " << sizeof(long) << " bytes." << endl;	
	cout << "The size of a long double is " << sizeof(longDouble) << " bytes." << endl;	
}
