/*
	2016-10-06T07:15:00	2016-10-06T0715www.JesusInTheLamb.comMathHelper.hpp
	2016-10-05 Stephen Prata C++ Primer Plus. Alexander Book Company. Address: 50 2nd Street, San Francisco, CA 94105 Phone:(415) 495-2992.
	2016-10-06 http://stackoverflow.com/questions/5373107/how-to-implement-static-class-member-functions-in-cpp-file
*/

#include <cmath> //or #include "math.h"
#include <iostream>

using namespace std;

#ifndef MathHelper_HPP
#define MathHelper_HPP

namespace InformationInTransit
{
	class MathHelper
	{
		public:
			static double power(double base, double exponenent);
			static double squareRoot(double sqr);
	};
} 
#endif
