#include <iostream>

using namespace std;
//2016-10-03 cl /clr Listing4.1UsingTheRelationalOperatorsToCompareTwoIntegerValuesInBooleanExpresions.cpp
void main(int argc, char *argv[])
{
	int num1 = 5;
	int num2 = 10;
	
	printf
	(
		"num1: %i num2: %i num1 == num2 = %s\n",
		num1,
		num2,
		num1 == num2 ? "true" : "false"
	);
	
	printf
	(
		"num1: %i num2: %i num1 <= num2 = %s\n",
		num1,
		num2,
		num1 <= num2 ? "true" : "false"
	);

	printf
	(
		"num1: %i num2: %i num1 < num2 = %s\n",
		num1,
		num2,
		num1 < num2 ? "true" : "false"
	);
	
	printf
	(
		"num1: %i num2: %i num1 >= num2 = %s\n",
		num1,
		num2,
		num1 >= num2 ? "true" : "false"
	);

	printf
	(
		"num1: %i num2: %i num1 > num2 = %s\n",
		num1,
		num2,
		num1 > num2 ? "true" : "false"
	);

	printf
	(
		"num1: %i num2: %i num1 != num2 = %s\n",
		num1,
		num2,
		num1 != num2 ? "true" : "false"
	);
	
}
