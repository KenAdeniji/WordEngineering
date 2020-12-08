/*
	2020-04-02	https://github.com/isocpp/CppCoreGuidelines/blob/master/CppCoreGuidelines.md
	2020-04-02	https://stackoverflow.com/questions/564877/point-and-line-class-in-c
*/

#include <iostream>

using namespace std;

class Point
{
    private:
        int x, y;
    public:
        Point()
		{
			x = 0;
			y = 0;
		}	
        Point(int x, int y)
		{
			this->x = x;
			this->y = y;
		}	
};

class Line
{
    private:
        Point p1;
        Point p2;
    public:
        Line(const Point &p1, const Point &p2)
        {
            this->p1 = p1;
            this->p2 = p2;
        }

        void setPoints(const Point &p1, const Point &p2)
        {
            this->p1 = p1;
            this->p2 = p2;
        }
};

void main(int argc, char *argv[]) 
{
	Point startPoint = Point(4, 2);
	Point endPoint = Point(6, 9);
	Line line = Line(startPoint, endPoint);
} 
