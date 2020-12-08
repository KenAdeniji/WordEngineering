#include <iostream>

using namespace std;
//2016-10-03 cl /clr Listing4.7UsingEnumerations.cpp

enum WEEKDAYS
{
	Sunday,
	Monday,
	Tuesday,
	Wednesday,
	Thursday,
	Friday,
	Saturday
};
	
void main(int argc, char *argv[])
{
	WEEKDAYS weekday = Monday;
	cout << weekday << '\n';
}
