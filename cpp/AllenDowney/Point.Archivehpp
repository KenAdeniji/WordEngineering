/*
	2022-12-10T19:34:00 Created.	http://greenteapress.com/thinkcpp/thinkCScpp.pdf
*/

#include <iostream>
#include <string>

using namespace std;

#ifndef Point_HPP
#define Point_HPP
 
class Point
{
	private:
		double	x;
		double	y;
 
	public:
		Point() {
			cout << "Point constructor." << endl;
		}
	
		Point
		(
			double	x,
			double	y
		);

		friend ostream& operator <<(ostream& outputStream, const Point& point);
	 
		void setPoint
		(
			double	x,
			double	y
		);

		double	getX();
		void	setX(double x);
		
		double	getY();
		void	setY(double y);
		
		void reflect();
};
 
#endif
