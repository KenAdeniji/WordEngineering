/*
	2021-04-12T17:30:00	Created.
		cl /GR /EHsc CircleRadiusArea.cpp
*/

#include <iostream>
#include <cmath>

using namespace std;

void main(void)
{
	double area, radius;
	const double pi = 22.0 / 7.0;
	cout << "What is the radius of the circle? ";
	cin >> radius;
	area = pi * pow(radius, 2);
	cout << "Area " << area << endl;
}
