// compile: cl /GR /EHsc VowelOrConsonant.cpp
/*
	2017-11-17	Created. Steven Holzner.
*/

#include <iostream>
#include <string>

using namespace std;

int main()
{
	char letter;
	cout << "Enter a letter: ";
	cin >> letter;
	
	if ( isalpha(letter) )
	{
		switch( tolower(letter) )
		{
			case 'a':
			case 'e':
			case 'i':
			case 'o':
			case 'u':
				cout << "Vowel" << endl;
				break;
			default:	
				cout << "Consonant" << endl;
				break;
		}
	}	
}
