#include <iostream>

using namespace std;
//2016-10-03 cl /clr Listing3.1SomeExamplesOfUnaryOperatorUsage.cpp
void main(int argc, char *argv[])
{
	// new operator
	int* pInt = new int;	//allocate an int
	
	// Indirection operator (*)
	*pInt = 5;
	int i = *pInt; // i == 5
	
	// delete operator
	delete pInt; // deallocate the int
	
	// Address-of operator (&)
	pInt = &i; // get the address of i
	
	// Unary plus operator (+)
	char c = 'A';
	int z = 'z'; //promote from char to int
	
	// Unary negation operator (-)
	i = -i; // negate i, i == -5
	
	// Logical NOT operator (!)
	i = !i; // i == 0
	i = !i; // i == 1
	
	// Prefix increment operator (++)
	++i; // i == 2
	
	// Prefix decrement operator (--)
	--i; // i == 1
	
	// sizeof operator
	i = sizeof(short); // i == 2 (32-bit OS)
	i = sizeof(int); // i == 4 (32-bit OS)
}
