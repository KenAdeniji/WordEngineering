#include <iostream>

using namespace std;
//2016-10-04 cl /clr QuePrentice-HallIndiaPracticalC++RobMcGregorOperatorOverloadingMultiply.cpp

struct ThreeDimensionalPoint
{
	double x;
	double y;
	double z;
};

// Function prototypes
ThreeDimensionalPoint operator*(const ThreeDimensionalPoint& pointFirst, ThreeDimensionalPoint& pointSecond);
ThreeDimensionalPoint Multiply(const ThreeDimensionalPoint& pointFirst, ThreeDimensionalPoint& pointSecond);

ThreeDimensionalPoint operator*(const ThreeDimensionalPoint& pointFirst, ThreeDimensionalPoint& pointSecond) 
{
	ThreeDimensionalPoint pointMultiply;
	pointMultiply.x = pointFirst.x * pointSecond.x;
	pointMultiply.y = pointFirst.y * pointSecond.y;
	pointMultiply.z = pointFirst.z * pointSecond.z;
	return pointMultiply;
}	

ThreeDimensionalPoint Multiply(const ThreeDimensionalPoint& pointFirst, ThreeDimensionalPoint& pointSecond) 
{
	ThreeDimensionalPoint pointMultiply;
	pointMultiply.x = pointFirst.x * pointSecond.x;
	pointMultiply.y = pointFirst.y * pointSecond.y;
	pointMultiply.z = pointFirst.z * pointSecond.z;
	return pointMultiply;
}	

void main(int argc, char *argv[])
{
	ThreeDimensionalPoint pointFirst = {1967.0f, 10.0f, 15.0f};
	ThreeDimensionalPoint pointSecond = {2016.0f, 10.0f, 4.0f};
	
	ThreeDimensionalPoint pointMultiplyMethod = Multiply(pointFirst, pointSecond);
	
	printf
	(
		"pointFirst.x: %lf pointFirst.y: %lf pointFirst.z: %lf pointMultiply: %lf\n",
		pointFirst.x,
		pointFirst.y,
		pointFirst.z,
		pointFirst.x * pointFirst.y * pointFirst.z
	);

	printf
	(
		"pointSecond.x: %lf pointSecond.y: %lf pointSecond.z: %lf pointMultiply: %lf\n",
		pointSecond.x,
		pointSecond.y,
		pointSecond.z,
		pointSecond.x * pointSecond.y * pointSecond.z
	);

	printf
	(
		"pointMultiplyMethod.x: %lf pointMultiplyMethod.y: %lf pointMultiplyMethod.z: %lf pointMultiplyMethod: %lf\n",
		pointMultiplyMethod.x,
		pointMultiplyMethod.y,
		pointMultiplyMethod.z,
		pointMultiplyMethod.x * pointMultiplyMethod.y * pointMultiplyMethod.z
	);
	
	ThreeDimensionalPoint pointMultiplyOperator = pointFirst * pointSecond;

	printf
	(
		"pointMultiplyOperator.x: %lf pointMultiplyOperator.y: %lf pointMultiplyOperator.z: %lf pointMultiplyOperator: %lf\n",
		pointMultiplyOperator.x,
		pointMultiplyOperator.y,
		pointMultiplyOperator.z,
		pointMultiplyOperator.x * pointMultiplyOperator.y * pointMultiplyOperator.z
	);
}
