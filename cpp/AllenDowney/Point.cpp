/*
	2022-12-10T19:52:00 Created.	http://greenteapress.com/thinkcpp/thinkCScpp.pdf
	2016-10-04	http://stackoverflow.com/questions/1549930/c-equivalent-of-java-tostring
	2022-12-19T09:24:00 distance method.
*/

#include <cassert>
#include <cmath>
#include <string>

#include "Point.hpp"

using namespace std;

// Point constructor
Point::Point
(
	double	x,
	double	y
)
{
	SetPoint(x, y);
}

// Point operator overloading

ostream& operator <<(ostream& outputStream, const Point& point)
{
	outputStream
		<< "x=" << point.x
		<< " y=" << point.y
		;
		
	return outputStream;
}		
 
// Point member function
void Point::SetPoint
(
	double	x,
	double	y
)
{
	assert(x >= 0 || y >= 0);
	this->x = x;
	this->y = y;
}

double Point::getX()
{ 
	return x;
}

double Point::getY()
{
	return y;
}
	
void Point::setX
(
	double	x
)
{
	assert(x > 0);
	this->x = x;
}

void Point::setY
(
	double y
)
{
	assert(y > 0);
	this->y = y;
}
