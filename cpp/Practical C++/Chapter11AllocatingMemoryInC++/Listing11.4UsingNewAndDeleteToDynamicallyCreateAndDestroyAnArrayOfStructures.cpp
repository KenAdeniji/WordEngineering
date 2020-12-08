#include <iostream>
#include <string>

using namespace std;
//2016-10-03 cl /clr Listing11.4UsingNewAndDeleteToDynamicallyCreateAndDestroyAnArrayOfStructures.cpp

struct Month {
	char* Name;
	int Number;
};	

const int MONTH_COUNT = 12;
const char* MONTH_NAMES[] = {
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

//Global pointers for dynamic allocation
Month *memoryPointerMonths = 0;

//Function prototypes
void AllocateMemory();
void MemoryHousekeeping();
void SetMemory();

void AllocateMemory()
{
	//Allocate the objects associated with the pointers
	memoryPointerMonths = new Month[MONTH_COUNT];
	
	if (memoryPointerMonths == 0)
	{	
		cerr << "Error: memory allocation failed.\n";
	}
}

void MemoryHousekeeping()
{
	//Memory housekeeping.
	if (memoryPointerMonths)
	{	
		delete []memoryPointerMonths;
		memoryPointerMonths = 0;
	}	
}

void SetMemory()
{
	for (int index = 0; index < MONTH_COUNT; ++index)
	{
		memoryPointerMonths[index].Name = new char[strlen(MONTH_NAMES[index]) + 1];
		strcpy(memoryPointerMonths[index].Name, MONTH_NAMES[index]);

		memoryPointerMonths[index].Number = index + 1;
		
		printf
		(
			"Month Number: %d Name: %s\n",
			memoryPointerMonths[index].Number,
			memoryPointerMonths[index].Name
		);
	}		
}	

void main(int argc, char *argv[])
{
	AllocateMemory();
	SetMemory();
	MemoryHousekeeping();
}
