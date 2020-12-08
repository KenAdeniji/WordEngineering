#include <iostream>

/*
	2018-07-06	https://github.com/lpvcpp/cpp_book/blob/master/Discovering%20Modern%20C%2B%2B%20-%20Peter%20Gottschling.pdf
*/

int main()
{
	int first = 3;
	first++; //Post-increment. The increment and decrement operators, ++ and --, require something that is modifiable and addressable, the later technically called Lvalue.
	const int second = 5;
	double modulo = first % second; // \%
	std::cout << modulo << std::endl;
	return 0;
}
	