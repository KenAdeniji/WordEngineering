#include <iostream>
#include <string>

using namespace std;
//2016-10-03 cl /clr Listing9.2DeclaringAndInitializingADataStructureSimultaneously.cpp

//Create a ThreeDimensionalPoint structure
struct ThreeDimensionalPoint {
	double x;
	double y;
	double z;
};
 	
void main(int argc, char *argv[])
{
	//Declare a variable of type ThreeDimensionalPoint
	ThreeDimensionalPoint threeDimensionalPoint = { 67.0f, 10.0f, 15.0f };
	
	printf
	(
		"x: %lf y: %lf z: %lf",
		threeDimensionalPoint.x,
		threeDimensionalPoint.y,
		threeDimensionalPoint.z
	);
}
