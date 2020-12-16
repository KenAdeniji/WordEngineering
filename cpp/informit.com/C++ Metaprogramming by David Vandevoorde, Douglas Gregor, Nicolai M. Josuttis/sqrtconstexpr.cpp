/*
	2018-05-31	Created.	http://www.informit.com/articles/article.aspx?p=2832416
*/
#include <iostream>

#include "sqrtconstexpr.hpp"

using namespace std;

namespace WordEngineering
{
	void main()
	{
		long long l = 53478;
		std::cout << sqrt(l) << '\n';            //prints 231 (evaluated at run time)
	}	
}
