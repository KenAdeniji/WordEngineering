#include <iostream>

using namespace std;
//cl /clr Fifth.cpp
void main(int argc, char *argv[])
{
	cout << "Hello, what's your first name?";
	char name[25];
	cin >> name;
	cout << "Welcome to the world of C++, " << name;
}
