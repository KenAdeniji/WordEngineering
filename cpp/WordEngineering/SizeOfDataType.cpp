#include <iostream>

using namespace std;

/*
	2018-10-08	Created.
*/

void SizeOfDataType();

void main(int argc, char *argv[])
{
	SizeOfDataType();
}

void SizeOfDataType()
{
	cout << "The size of a bool: " << sizeof(bool) << " bytes " << endl;
	cout << "The size of a char: " << sizeof(char) << " bytes " << endl;
	cout << "The size of a double: " << sizeof(double) << " bytes " << endl;
	cout << "The size of a float: " << sizeof(float) << " bytes " << endl;
	cout << "The size of an integer: " << sizeof(int) << " bytes " << endl;
	cout << "The size of a long double: " << sizeof(long double) << " bytes " << endl;
	cout << "The size of a long integer: " << sizeof(long) << " bytes " << endl;
	cout << "The size of a short integer: " << sizeof(short) << " bytes " << endl;
}
