// compile with: /GR /EHsc
/*
	2015-03-05	Created. http://stroustrup.com/Programming
*/

#include <iostream>
#include <string>

using namespace std;

namespace WordEngineering
{
	class RectangleHelper 
	{
		protected:
			double length;
			double width;
			
		public:
			double area(double length, double width)
			{
				  return (length * width);
			}

			double area()
			{
				  return area(length, width);
			}
			
			double perimeter(double length, double width)
			{
				return (length + width) * 2;
			}

			double perimeter()
			{
				  return perimeter(length, width);
			}
			
			RectangleHelper()
			{
			}

			RectangleHelper(double a, double b)
			{
				length = a;
				width = b;
			}
	} rectangleHelper;
}
