#include <iostream>

int main()
{   
	long double doubleNonQualified = 0.3333333333333333333;
	long double longDoubleAccuracy = 0.3333333333333333333l;
	std::cout 	<< "doubleNonQualified: " << doubleNonQualified << std::endl;
	std::cout 	<< "longDoubleAccuracy: " << longDoubleAccuracy << std::endl;
	return 0;
}
	