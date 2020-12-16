#include <iostream>

using namespace std;
//2016-10-03 cl /clr Listing5.3AProgramThatUsesAWhileLoopToIterateThroughAllTheUppercaseLettersOfTheAlphabet.cpp

void main(int argc, char *argv[])
{
	char uppercaseLetter = 'A';
	while (uppercaseLetter <= 'Z')
	{
		cout << uppercaseLetter << " ";
		++uppercaseLetter;
	}		
}
