// compile with: /GR /EHsc
/*
	2016-01-05	Created.	http://ptgmedia.pearsoncmg.com/images/9780134383583/samplepages/9780134383583.pdf
	2016-01-05				https://msdn.microsoft.com/en-us/library/0352zzhd.aspx
*/

#include <complex>
#include <iostream>
#include <string>

using namespace std;

int main()
{
	complex <float> z(1.3, 2.4), z2;
	cout << "z: " << z << endl;
	z2= 2.0f *z; // Okay:   float * complex<float>
	cout << "z2: " << z2 << endl;
}
