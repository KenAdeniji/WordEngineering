#include <iostream>

using namespace std;
//2016-10-03 cl /clr Listing11.3AProgramThatDemonstratesDynamicallyAllocatingACharacterArray.cpp

//Global pointers for dynamic allocation
char *memoryPointerCharArray = 0;

void main(int argc, char *argv[])
{
	char stringEntered[128];
	
	cout << "Please type a string: ";
	cin >> stringEntered;

	memoryPointerCharArray = new char[strlen(stringEntered) + 1];
	strcpy(memoryPointerCharArray, stringEntered);
	
	printf
	(
		"String entered: %s character array %s\n",
		stringEntered,
		memoryPointerCharArray
	);	
	
	delete [] memoryPointerCharArray;
	*memoryPointerCharArray = 0;
}
