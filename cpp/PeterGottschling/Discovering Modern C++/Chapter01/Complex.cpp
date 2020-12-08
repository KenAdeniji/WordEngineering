#include <iostream>
#include <iomanip>
#include <complex>
#include <cmath>

using namespace std;

int main()
{
	std::complex<float> z(1.3, 2.4), z2;
	std::cout 	<< "z: " << z << std::endl;
	z2 = 2.0f * z; //Okay: float * complex<float>
	std::cout 	<< "z2: " << z2 << std::endl;
	return 0;
}
	