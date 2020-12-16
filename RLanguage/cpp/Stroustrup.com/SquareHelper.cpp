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

#include "SquareHelper.h"

using namespace std;

using namespace WordEngineering;

int main()
{
	double area = squareHelper.area(7);
	cout << "Area: " << area << endl;

	double perimeter = squareHelper.perimeter(7);
	cout << "Perimeter: " << perimeter << endl;
	
	SquareHelper square(7);
	cout << "Area: " << square.area() << endl;
	cout << "Perimeter: " << square.perimeter() << endl;
}
