/*
	2022-12-18T20:18:00 Created.	http://greenteapress.com/thinkcpp/thinkCScpp.pdf
	2016-10-05T06:55:00 http://stackoverflow.com/questions/12248703/creating-an-instance-of-class
*/

#include <iostream>

#include "Point.hpp"

using namespace std;

double distance(Point p1, Point p2);
void stub();

double distance(Point p1, Point p2)
{
	double dx = p2.getX() - p1.getX();
	double dy = p2.getY() - p1.getY();
	return sqrt(dx*dx + dy*dy);
}

void stub()
{
	Point* point1 = new Point(3.5, 4);
	point1->setX(3);
	Point* point2 = new Point(0, 0);
	cout	<< "point1 " << *point1
			<< " point2 " << *point2
			<< " distance=" << distance(*point1, *point2) 
			<< endl;
	point1->reflect();
	cout	<< "point1 " << *point1
			<< " point2 " << *point2
			<< " distance=" << distance(*point1, *point2) 
			<< endl;
	delete point1;
	delete point2;
}

void main(int argc, char *argv[])
{
	stub();
}

