#include <iostream>

using namespace std;
//2016-10-03 cl /clr char.cpp
void main(int argc, char *argv[])
{
	char ch1[] = "GUITAR";
	char ch2[] = {'G', 'U', 'I', 'T', 'A', 'R', '\0'};
	char ch3[] = {0x47, 0x55, 0x49, 0x54, 0x41, 0x52, 0x00};
	 
	cout << "ch1: " << ch1 << '\n';
	cout << "ch2: " << ch2 << '\n';
	cout << "ch3: " << ch3 << '\n';
	
	bool needToSave = false;
	float myFloat = 42.0F;
	double myDouble = 42.0;
	long double myLongDouble = 42.0L;
	
	const double PI = 3.14159;
	const int HOURS_IN_DAY = 24;
}
