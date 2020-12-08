#include <iostream>

using namespace std;
//2016-10-03 cl /clr Listing13.5AProgramThatDemonstratesTheUseOfPointersToMemberFunctions.cpp

struct Box {
	double length;
	double width;
	double height;
	
	double Volume() {
		return length * width * height;
	}
};

// Function pointer types
double (Box::*PFN)() = &Box::Volume; //Direct method to get the address of the function.

typedef double (Box::*PFNTypedef)();

void main(int argc, char *argv[])
{
	Box cube = { 1967.0f, 10.0f, 15.0f };
	
	double volume = cube.length * cube.width * cube.height;
	
	printf
	(
		"length: %lf y: %lf z: %lf volume: %lf\n",
		cube.length,
		cube.width,
		cube.height,
		volume
	);

	printf
	(
		"length: %lf y: %lf z: %lf volume: %lf\n",
		cube.length,
		cube.width,
		cube.height,
		(cube.*PFN)()
	);
	
	PFNTypedef pfnTypeDef = &Box::Volume;
	
	printf
	(
		"length: %lf y: %lf z: %lf volume: %lf\n",
		cube.length,
		cube.width,
		cube.height,
		(cube.*pfnTypeDef)()
	);
}
