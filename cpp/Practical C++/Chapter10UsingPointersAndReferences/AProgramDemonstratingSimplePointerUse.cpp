#include <iostream>

using namespace std;
//2016-10-03 cl /clr AProgramDemonstratingSimplePointerUse.cpp

void main(int argc, char *argv[])
{
	double variable = 19671015;
	double *pointerMemoryAddress = &variable;
	
	printf
	(
		"Variable address: %p value: %lf\n",
		&variable,
		variable
	);
	
	printf
	(
		"Pointer address: %p value: %lf\n",
		pointerMemoryAddress,
		*pointerMemoryAddress	
	);
}
