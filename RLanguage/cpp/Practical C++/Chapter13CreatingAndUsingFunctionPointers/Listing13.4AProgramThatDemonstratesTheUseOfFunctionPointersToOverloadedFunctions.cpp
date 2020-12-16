#include <iostream>

using namespace std;
//2016-10-03 cl /clr Listing13.4AProgramThatDemonstratesTheUseOfFunctionPointersToOverloadedFunctions.cpp

// Prototypes
double Multiply(double x, double y, double z);
float Multiply(float x, float y, float z);
int Multiply(int x, int y, int z);
long Multiply(long x, long y, long z);

// Function pointer types
typedef double (*PFN_MultiplyDouble) (double x, double y, double z);
typedef float (*PFN_MultiplyFloat) (float x, float y, float z);
typedef int (*PFN_MultiplyInt) (int x, int y, int z);
typedef long (*PFN_MultiplyLong) (long x, long y, long z);

void main(int argc, char *argv[])
{
	//Declare and initialize the function pointers
	PFN_MultiplyDouble pfnMultiplyDouble = Multiply;
	PFN_MultiplyFloat pfnMultiplyFloat = Multiply;
	PFN_MultiplyInt pfnMultiplyInt = Multiply;
	PFN_MultiplyLong pfnMultiplyLong = Multiply;
	
	//Call the functions via the pointers
	pfnMultiplyDouble(1967.0f, 10.0f, 15.0f);
	pfnMultiplyFloat(1967.0f, 10.0f, 15.0f);
	pfnMultiplyInt(1967, 10, 15);
	pfnMultiplyLong(1967l, 10l, 15l);
}

double Multiply(double x, double y, double z)
{
	double multiply = x * y * z;
	printf
	(
		"x: %lf y: %lf z: %lf multipy: %lf\n",
		x,
		y,
		z,
		multiply
	);
	return multiply;
}	

float Multiply(float x, float y, float z)
{
	float multiply = x * y * z;
	printf
	(
		"x: %f y: %f z: %f multipy: %f\n",
		x,
		y,
		z,
		multiply
	);
	return multiply;
}	

int Multiply(int x, int y, int z)
{
	int multiply = x * y * z;
	printf
	(
		"x: %i y: %i z: %i multipy: %i\n",
		x,
		y,
		z,
		multiply
	);
	return multiply;
}	

long Multiply(long x, long y, long z)
{
	long multiply = x * y * z;
	printf
	(
		"x: %ld y: %ld z: %ld multipy: %ld\n",
		x,
		y,
		z,
		multiply
	);
	return multiply;
}	
