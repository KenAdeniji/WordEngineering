//	2016-02-09	http://www.cplusplus.com/doc/tutorial/control/
// range-based for loop. C# foreach.
#include <iostream>
#include <string>
using namespace std;

int main ()
{
	string str = "Hello!";
	int position = 0;
	for (char c : str)
	{
		std::cout << "[" << position++ << "] = " << c << endl;
	}

	int tens[] = {10, 20, 30, 40, 50};
	for (int ten : tens)
	{
		std::cout << ten << endl;
	}
}
