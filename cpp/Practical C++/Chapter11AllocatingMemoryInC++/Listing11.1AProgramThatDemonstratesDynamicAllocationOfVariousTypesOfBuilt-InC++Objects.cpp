#include <iostream>

using namespace std;
//2016-10-03 cl /clr Listing11.1AProgramThatDemonstratesDynamicAllocationOfVariousTypesOfBuilt-InC++Objects.cpp

//Global pointers for dynamic allocation
double *memoryPointerDouble = 0;

//Function prototypes
void AllocateMemory();
void MemoryHousekeeping();
void SetMemory();

void AllocateMemory()
{
	//Allocate the objects associated with the pointers
	memoryPointerDouble = new double;
}

void MemoryHousekeeping()
{
	//Memory housekeeping.
	if (memoryPointerDouble)
	{	
		delete memoryPointerDouble;
		memoryPointerDouble = 0;
	}	
}

void SetMemory()
{
	*memoryPointerDouble = 19671015.0f;
}	

void main(int argc, char *argv[])
{
	AllocateMemory();
	SetMemory();
	cout << "*memoryPointerDouble: " << *memoryPointerDouble << '\n';
	MemoryHousekeeping();
}
