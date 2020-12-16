// compile with: /GR /EHsc
/*
	2015-03-04	Created. http://stroustrup.com/Programming
	2015-03-04	http://www.informit.com/articles/article.aspx?p=2216986&seqNum=7
	2015-03-04	http://www.cplusplus.com/doc/tutorial/namespaces/
	2015-03-04	http://en.wikipedia.org/wiki/Rectangle
	2015-03-04	http://www.cplusplus.com/doc/tutorial/classes/
*/

#include <iostream>
#include <string>

#include "RectangleHelper.h"

using namespace std;

using namespace WordEngineering;

int main()
{
	double area = rectangleHelper.area(7, 5);
	cout << "Area: " << area << endl;

	double perimeter = rectangleHelper.perimeter(7, 5);
	cout << "Perimeter: " << perimeter << endl;
	
	RectangleHelper rectangle(7, 5);
	cout << "Area: " << rectangle.area() << endl;
	cout << "Perimeter: " << rectangle.perimeter() << endl;
}
