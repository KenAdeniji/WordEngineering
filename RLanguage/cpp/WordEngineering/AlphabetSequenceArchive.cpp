#include <ctype.h>
#include <iostream>

using namespace std;

/*
	2018-10-08	Created.
*/

void AlphabetSequence(int, char *argv[]);

void main(int argc, char *argv[])
{
	AlphabetSequence(argc, argv);
}

void AlphabetSequence(int argc, char *argv[])
{
	int sum = 0;
	char concatenate[8000] = "";
	for 
	(
		int index = 1;
		index < argc;
		index++
	)
	{
		int alphabetSequenceIndex = 0;
		for 
		(
			int position = 0, length = strlen(argv[index]), currentLetter, location;
			position < length;
			position++
		)
		{
			location = 0;
			currentLetter = tolower(argv[index][position]);	
			if (islower(currentLetter))
			{
				location = currentLetter - 'a' + 1;
				alphabetSequenceIndex += location;
			}	
		}
		cout << argv[index] << ' ' << alphabetSequenceIndex << endl;
		sum += alphabetSequenceIndex;
		strcat(concatenate, argv[index]); 
	}
	cout << concatenate << ' ' << sum << endl;	
}
