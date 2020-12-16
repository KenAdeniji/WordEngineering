/*
	2016-10-06T07:38:00 2016-10-06T0738www.JesusInTheLamb.comMathMain.cpp
	2016-10-05 Stephen Prata C++ Primer Plus. Alexander Book Company. Address: 50 2nd Street, San Francisco, CA 94105 Phone:(415) 495-2992.
*/

#include <iostream>

#include "2016-10-06T0715www.JesusInTheLamb.comMathHelper.hpp"

using namespace std;
using namespace InformationInTransit;

void stub(int argc, char *argv[]);

void stub(int argc, char *argv[])
{
	for(int index = 1; index < argc; index++)
	{
		double currentValue = strtod(argv[index], NULL);
	
		cout 
			<< 	"value = " << currentValue
			<<	" sqrt = " << MathHelper::squareRoot(currentValue)
			<<	" power(base, 2) = " << MathHelper::power(currentValue, 2)
			<< 	endl;
	}
}
	
void main(int argc, char *argv[])
{
	stub(argc, argv);
}
