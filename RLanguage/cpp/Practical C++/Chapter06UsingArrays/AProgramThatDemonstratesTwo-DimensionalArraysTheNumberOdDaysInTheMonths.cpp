#include <iostream>

using namespace std;
//2016-10-03 cl /clr AProgramThatDemonstratesTwo-DimensionalArraysTheNumberOdDaysInTheMonths.cpp

const int TwoDimensionalArrayColumnsSize = 2;
const int TwoDimensionalArrayRowsSize = 12;

void main(int argc, char *argv[])
{
	
	int twoDimensionalArray[TwoDimensionalArrayRowsSize][TwoDimensionalArrayColumnsSize] =
	{
		{ 1, 31 },
		{ 2, 28 },
		{ 3, 31 },
		{ 4, 30 },
		{ 5, 31 },
		{ 6, 30 },
		{ 7, 31 },
		{ 8, 31 },
		{ 9, 30 },
		{ 10, 31 },
		{ 11, 30 },
		{ 12, 31 }
	};
	
	char* monthNames[] = {
		"January",
		"February",
		"March",
		"April",
		"May",
		"June",
		"July",
		"August",
		"September",
		"October",
		"November",
		"December"
	};
	
	for 
	(
		int rowIndex = 0, rowsSize = (sizeof(twoDimensionalArray)/sizeof(*twoDimensionalArray));
		rowIndex < rowsSize;
		++rowIndex
	)
	{
		printf
		(
			"Index: [%i] Month Name: %s: Month ID: %i Probable Number of Days: %i\n",
			rowIndex,
			monthNames[rowIndex],
			twoDimensionalArray[rowIndex][0],
			twoDimensionalArray[rowIndex][1]
		);
	}	
}
