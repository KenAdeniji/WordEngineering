#include <iostream>

using namespace std;
//2016-10-03 cl /clr Listing5.1AProgramThatUsesAForLoopToIterateThroughAllTheUppercaseLettersOfTheAlphabet.cpp

void main(int argc, char *argv[])
{
	//List all uppercase letters of the alphabet.
	for (char uppercaseLetter = 'A'; uppercaseLetter <= 'Z'; ++uppercaseLetter)
	{
		cout << uppercaseLetter << ' ';
	}		
}
