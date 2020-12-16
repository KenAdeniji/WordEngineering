#include <iostream>

using namespace std;
//2016-10-03 cl /clr Listing4.2UsingTheAndOperatorToCreateComplexBooleanExpressions.cpp
void main(int argc, char *argv[])
{
	int x = 10;
	int y = 20;
	
	char ch1 = 'A';
	char ch2 = 'Z';
	
	printf
	(
		"x = %i y = %i ((x < y) && (ch1 == ch2)) = %s\n",
		x,
		y,
		((x < y) && (ch1 == ch2)) ? "true" : "false"
	);

	printf
	(
		"x = %i y = %i ((x < ch1) && (ch1 != ch2)) = %s\n",
		x,
		y,
		((x < ch1) && (ch1 != ch2)) ? "true" : "false"
	);

	printf
	(
		"x = %i y = %i ((x != y) && (ch1 != ch2)) = %s\n",
		x,
		y,
		((x != y) && (ch1 != ch2)) ? "true" : "false"
	);

	printf
	(
		"x = %i y = %i ((x < y) && (ch1 == ch2) && (x < ch1) && (y > ch2)) = %s\n",
		x,
		y,
		((x < y) && (ch1 == ch2) && (x < ch1) && (y > ch2)) ? "true" : "false"
	);	
}
