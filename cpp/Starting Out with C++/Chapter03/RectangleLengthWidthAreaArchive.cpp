/*
	2021-04-12T17:06:00	Created.
		cl /GR /EHsc RectangleLengthWidthArea.cpp
*/

#include <iostream>

using namespace std;

void main(void)
{
	long double length, width, area;
	cout << "What is the length of the rectangle? ";
	cin >> length;
	cout << "What is the width of the rectangle? ";
	cin >> width;
	area = length * width;
	cout << "The area of the rectangle is: " << area;
}
