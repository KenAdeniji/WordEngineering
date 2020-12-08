/*
	2020-04-02	https://github.com/isocpp/CppCoreGuidelines/blob/master/CppCoreGuidelines.md
	2020-04-02	https://en.cppreference.com/w/cpp/language/user_literal
*/

#include <iostream>

using namespace std;

// simple typedef
typedef double Speed;

void change_speed(Speed s);    // better: the meaning of s is specified

void change_speed(Speed s)
{
	cout << s << endl;
}

int main(int argc, char *argv[]) 
{
	change_speed(12);
} 
