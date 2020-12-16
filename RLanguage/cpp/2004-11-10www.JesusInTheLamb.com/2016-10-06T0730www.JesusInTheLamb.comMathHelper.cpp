/*
	2016-10-06T07:30:00	2016-10-06T0730www.JesusInTheLamb.comMathHelper.cpp
	2016-10-05 Stephen Prata C++ Primer Plus. Alexander Book Company. Address: 50 2nd Street, San Francisco, CA 94105 Phone:(415) 495-2992.
	2016-10-06T13:18:00	
		www.cplusplus.com/reference/cmath/pow
		<cmath> pow; function <cmath> <ctgmath> pow. double pow (double base, double exponent); ... double pow (double base , double exponent); float pow (float ...	
*/

#include <cmath>
#include <iostream>

#include "2016-10-06T0715www.JesusInTheLamb.comMathHelper.hpp"

using namespace std;

namespace InformationInTransit
{
	double MathHelper::power(double base, double exponent)
	{
		return pow(base, exponent);
	}

	double MathHelper::squareRoot(double square)
	{
		return sqrt(square);
	}	
}
