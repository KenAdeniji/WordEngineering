// compile with: /GR /EHsc
/*
	2015-03-05	Created. http://stroustrup.com/Programming
	2015-03-05	http://en.wikipedia.org/wiki/Square
	2015-03-05	http://stackoverflow.com/questions/10282787/calling-the-base-class-constructor-in-the-derived-class-constructor
*/

#include <iostream>
#include <string>

#include "RectangleHelper.h"

using namespace std;

namespace WordEngineering
{
	class SquareHelper : public RectangleHelper
	{
		public:
			SquareHelper()
			{
			}

			SquareHelper(double length) : RectangleHelper(length, length)
			{
			}

			double area(double length)
			{
				return RectangleHelper::area(length, length);
			}

			double area()
			{
				  return area(length);
			}
			
			double perimeter(double length)
			{
				return RectangleHelper::perimeter(length, length);
			}

			double perimeter()
			{
				  return perimeter(length);
			}
	} squareHelper;
}
