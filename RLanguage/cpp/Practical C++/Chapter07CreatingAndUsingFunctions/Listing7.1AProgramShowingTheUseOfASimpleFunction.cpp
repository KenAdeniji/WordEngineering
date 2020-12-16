#include <iostream>

using namespace std;
//2016-10-03 cl /clr Listing7.1AProgramShowingTheUseOfASimpleFunction.cpp

// Global constants
const char *SOURCEFILENAME = "Listing7.1AProgramShowingTheUseOfASimpleFunction.cpp";

// Function prototypes
void About();

void About()
{
	cout << "Source Filename: " << SOURCEFILENAME << "\n";
}
	
void main(int argc, char *argv[])
{
	About();	
}
