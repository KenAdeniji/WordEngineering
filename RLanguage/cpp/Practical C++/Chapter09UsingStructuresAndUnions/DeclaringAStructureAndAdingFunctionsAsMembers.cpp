#include <iostream>

using namespace std;
//2016-10-03 cl /clr DeclaringAStructureAndAdingFunctionsAsMembers.cpp

//Create a Rectangle structure
struct Rectangle {
	double x;
	double y;
	double z;
	
	double Area() { return x * y; };
	double Volume() { return x * y * z; };
};
 	
void main(int argc, char *argv[])
{
	//Declare a variable of type Rectangle
	Rectangle rectangle = { 67.0f, 10.0f, 15.0f };
	
	printf
	(
		"x: %lf y: %lf z: %lf Area: %lf Volume: %lf",
		rectangle.x,
		rectangle.y,
		rectangle.z,
		rectangle.Area(),
		rectangle.Volume()
	);
}
