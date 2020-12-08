#include <iostream>

using namespace std;
//cl /clr SixthFirstnameLastname.cpp
void main(int argc, char *argv[])
{
	cout << "Hello, what's your name?";
	char firstname[25];
	char lastname[25];
	cin >> firstname >> lastname;
	cout << "Welcome to the world of C++, " << firstname << " " << lastname;
}
