// compile: cl /GR /EHsc CreatingADynamicArrayWithNew.cpp
/*
	2019-01-25	Created. Stephen Prata.
*/

#include <iostream>
#include <string>

using namespace std;

int main()
{
	int * psome = new int [10]; // get a block of 10 ints
	delete [] psome; // free a dynamic array
	
	const int BOOK_SIZE = 5;
	
	string * pentateuch	= new string [BOOK_SIZE]
	/* =
	{
		"Genesis",
		"Exodus",
		"Leviticus",
		"Numbers",
		"Deuteronomy"
	}
	*/
	;
	pentateuch[0] = "Genesis";
	pentateuch[1] = "Exodus";
	pentateuch[2] = "Leviticus";
	pentateuch[3] = "Numbers";
	pentateuch[4] = "Deuteronomy";
	
	for 
	(
		int index = 0;
		index < BOOK_SIZE;
		++index
	)
	{
		cout << pentateuch[index] << endl;
	}	
	delete [] pentateuch;
}
