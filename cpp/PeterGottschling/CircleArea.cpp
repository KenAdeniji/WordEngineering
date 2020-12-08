// compile with: /GR /EHsc
/*
	2016-01-05	Created.	http://ptgmedia.pearsoncmg.com/images/9780134383583/samplepages/9780134383583.pdf
*/

#include <iostream>
#include <math.h>

using namespace std;

int main()
{
	const float radius1 = 3.5, radius2 = 7.3, PI = 22.0f / 7.0f;

	float area1 = PI * pow(radius1, 2);
	std::cout << "A circle of radius " << radius1 <<
		" has area " << area1 << "." << std::endl;
	std::cout << "The average of " << radius1 <<
		" and " << radius2 << " is " << (radius1 + radius2) / 2.0f << "." << std::endl;
}
