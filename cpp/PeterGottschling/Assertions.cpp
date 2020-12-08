// compile with: /GR /EHsc
/*
	2016-01-06	Created.	http://ptgmedia.pearsoncmg.com/images/9780134383583/samplepages/9780134383583.pdf
*/

#include <cassert>
#include <iostream>

using namespace std;

double square_root(double x)
{
	double result = pow(x, .5);
	assert(result >= 0.0);
	return (result);
}

int main(int argc, char* argv[])
{
	double x = 15;
	double result = square_root(x);
	cout << "The square root of " << x << " is " << result << '\n';
	return 0;	
}
