/*
	2021-04-12T15:36:00	Created.
		cl /GR /EHsc EmployeePay.cpp
*/

#include <iostream>

using namespace std;

int main()
{
	float hours, rate, pay;
	cout << "How many hours did you work? ";
	cin >> hours;
	cout << "How much do you get paid per hour? ";
	cin >> rate;
	pay = hours * rate;
	cout << "You have earned: " << pay << endl;
}
