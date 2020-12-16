// compile with: /GR /EHsc
/*
	2015-03-05	Created.
*/

#include <iostream>
#include <string>

using namespace std;

namespace WordEngineering
{
	const double pi = 3.1415926;
	
	class CircleHelper 
	{
		private:
			double radius;
			
		public:
			double area(double radius)
			{
				  return (pi * radius * radius);
			}

			double area()
			{
				  return area(radius);
			}
			
			double circumference(double radius)
			{
				return (2 * pi * radius);
			}

			double circumference()
			{
				  return circumference(radius);
			}
			
			CircleHelper()
			{
			}

			CircleHelper(double a)
			{
				radius = a;
			}
	} circleHelper;
}

using namespace WordEngineering;

int main()
{
	double area = circleHelper.area(7);
	cout << "Area: " << area << endl;

	double circumference = circleHelper.circumference(7);
	cout << "Circumference: " << circumference << endl;
	
	CircleHelper circle(7);
	cout << "Area: " << circle.area() << endl;
	cout << "Circumference: " << circle.circumference() << endl;
}
