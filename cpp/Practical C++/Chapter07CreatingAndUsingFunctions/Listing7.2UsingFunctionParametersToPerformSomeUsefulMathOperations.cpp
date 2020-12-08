#include <iostream>

using namespace std;
//2016-10-03 cl /clr Listing7.2UsingFunctionParametersToPerformSomeUsefulMathOperations.cpp

// Function prototypes
inline double Square(const double num);

inline double Square(const double num)
{
	return pow(num, 2);
}
	
void main(int argc, char *argv[])
{
	double argumentValue = 0;
	for (int index = 1; index < argc; ++index)
	{
		argumentValue = atof(argv[index]);
		printf
		(
			"Argument[%i]: %lf Square: %lf\n",
			index,
			argumentValue,
			Square(argumentValue)
		);	
	}
}
