#include <iostream>

using namespace std;
//2016-10-03 cl /clr Listing5.5AProgramThatUsesADoLoopToIterateThroughAllTheUppercaseLettersOfTheAlphabet.cpp

void main(int argc, char *argv[])
{
	char uppercaseLetter = 'A';
	do
	{
		cout << uppercaseLetter << " ";
		++uppercaseLetter;
	}		
	while (uppercaseLetter <= 'Z');
}
