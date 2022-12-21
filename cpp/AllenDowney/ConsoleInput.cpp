/*
	2022-12-19T13:17:00 Created.	http://greenteapress.com/thinkcpp/thinkCScpp.pdf
	2022-12-19T13:38:00	https://stackoverflow.com/questions/73840395/why-atoi-function-from-includecstdlib-is-not-working
*/

#include <cstdlib>
#include <iostream>
#include <string>

using namespace std;

void main(int argc, char *argv[])
{
	string name;
	cout << "What is your name? ";
	getline (cin, name); // cin >> name;
	cout << name << endl;
	
	string age;
	cout << "What is your age? ";
	getline (cin, age); // cin >> age;
	cout << stoi(age) << endl;
}
