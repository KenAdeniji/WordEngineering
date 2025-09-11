/*
	http://www.wiley.com/en-us/C%2B%2B+All-in-One+For+Dummies%2C+4th+Edition-p-9781119601739
	John@JohnMuellerBooks.com
	C++ All-in-One For Dummies, 4th Edition
	John Paul Mueller 
	ISBN: 978-1-119-60173-9
	December 2020
	912 pages	
	2025-09-10T21:45:00 Date created.
	http://en.cppreference.com/w/cpp/numeric
	cout << "pi: " << std::numbers::pi << endl; //C++ 20
*/
#include <iostream>
#include <math.h>
#include <numbers>

using namespace std;

int main(int argc, char *argv[])
{
	cout << "pi: " << std::numbers::pi << endl;
}
