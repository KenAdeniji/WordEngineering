#include <iostream>

/*
	2018-07-06	https://github.com/lpvcpp/cpp_book/blob/master/Discovering%20Modern%20C%2B%2B%20-%20Peter%20Gottschling.pdf
*/

int main()
{
	int outerVariable = 4701;	
	{
		int innerVariable = 2013'03'26;
		std::cout << "innerVariable: " << innerVariable << std::endl;
	}	
	std::cout << "outerVariable: " << outerVariable << std::endl;
	return 0;
}
	