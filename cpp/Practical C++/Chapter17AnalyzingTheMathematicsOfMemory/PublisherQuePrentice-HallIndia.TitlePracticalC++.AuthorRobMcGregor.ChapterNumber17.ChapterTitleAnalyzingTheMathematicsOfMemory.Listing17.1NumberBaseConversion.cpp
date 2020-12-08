/*
	2016-10-04 	cl /clr PublisherQuePrentice-HallIndia.TitlePracticalC++.AuthorRobMcGregor.ChapterNumber17.ChapterTitleAnalyzingTheMathematicsOfMemory.Listing17.1NumberBaseConversion.cpp
	2016-10-04	https://msdn.microsoft.com/en-us/library/k9dcesdd.aspx
	2016-10-04	http://stackoverflow.com/questions/8376384/how-do-i-convert-a-char-array-to-integer-double-long-type
*/

#include <stdlib.h>

#include <algorithm>
#include <cstdlib>
#include <iostream>
#include <string>

using namespace std;

// Global variables
const int BASE_TO_CONVERT_FROM = 10;

// Function Declarations
string ConvertFromBase10(const long& numberToConvert, const int& newBase);

string ConvertFromBase10(const long& numberToConvert, const int& newBase)
{
	char	currentCharacter;
	long	remainder = 0;
	long	quotient = numberToConvert;
	string	numberConvertedTo;
	
	while (quotient > 0)
	{
		remainder = quotient % newBase;
		quotient /= newBase;
		
		//Convert the remainder to a character and add it to the result string.
		itoa(remainder, &currentCharacter, BASE_TO_CONVERT_FROM);
		numberConvertedTo += currentCharacter;
	}

	std::reverse(numberConvertedTo.begin(), numberConvertedTo.end());
	return	numberConvertedTo;
};
	
void main(int argc, char *argv[])
{
	if (argc < 3)
	{
		cerr << "Please enter the number to convert, and the base to convert to.\n";
		exit(EXIT_FAILURE);
	}
	
	long numberToConvert = std::stol(argv[1]);
	int newBase = std::stol(argv[2]);
	
	string numberConvertedTo = ConvertFromBase10(numberToConvert, newBase);
	cout << numberConvertedTo;
}
