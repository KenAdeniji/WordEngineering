#include <algorithm>
#include <iostream>
#include <string >
#include <vector>

using namespace std;

#define pi 3.14286 

//2016-02-30 Sams Teach Yourself C++ In One Hour a Day by Siddharta Rao

inline double GetPi() 
{
	return 22.0 / 7;
}

void DisplayNumbers(vector<int> &array)
{
	for_each(array.begin(), array.end(), \
	[] (int element) { cout << element << "  "; });
	cout << endl;
}	

/*
	http://stackoverflow.com/questions/10274162/how-to-find-2d-array-size-in-c
*/
int main()
{
	cout << "Size of bool: " << sizeof(bool) << " bytes(s). " << endl;
	
	auto flag = true;
	const double PI = 22.0 / 7;
	
	cout << "PI: " << PI << endl;
	
	enum CardinalDirections
	{
		North = 25,
		South,
		East,
		West
	};

	cout << "North: " << North << endl;

	CardinalDirections windDirection = South;	
	
	cout << "windDirection: " << windDirection << endl;
	
	cout << "pi: " << pi << endl;
	
	int threeRowsThreeColumns[3][3] =
	{
		{301, 206, 2011},
		{909, 103, 206},
		{203, 456, 396}
	};

	for
	(
		int row = 0, rowsCount = sizeof(threeRowsThreeColumns)/sizeof(threeRowsThreeColumns[0]);
		row < rowsCount;
		++row
	)
	{
		for
		(
			int column = 0, columnsCount = sizeof(threeRowsThreeColumns[row])/sizeof(int);
			column < columnsCount;
			++column
		)
		{
			cout << "threeRowsThreeColumns[" << row << "][" << column << "]:" << 
				threeRowsThreeColumns[row][column] << endl;
		}	
	}	
	
	vector<int> dynamicNumbers(3);
	dynamicNumbers.push_back(1);
	cout << "dynamicNumbers.size(): " << dynamicNumbers.size() << endl;
	cout << "dynamicNumbers[3]: " << dynamicNumbers[3] << endl;
	
	char Buffer[20] = {'\0'};
	cout << "Enter a line of text: " << endl;
	string lineEntered;
	getline(cin, lineEntered);
	if (lineEntered.length() < 20)
	{
		strcpy(Buffer, lineEntered.c_str());
		cout << "Buffer: " << Buffer << endl;
	}

	int lessThanFive = 1;
	JumpToPoint:
		cout << "lessThanFive; " << lessThanFive << endl;
		++lessThanFive;
		if (lessThanFive < 5)
		{
			goto JumpToPoint;
		}	
	
	vector<int> myNumbers;
	myNumbers.push_back(501);
	myNumbers.push_back(-2);
	myNumbers.push_back(102);
	
	DisplayNumbers(myNumbers);
	
	sort(myNumbers.begin(), myNumbers.end(), \
		[](int number1, int number2) { 
			return(number2, number1);	} );	
	
	DisplayNumbers(myNumbers);
}

