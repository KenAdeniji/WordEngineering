#include <iostream>
#include <string>

using namespace std;
//2016-10-03 cl /clr PreprocessorDirectiveDefineMacro.cpp

void main(int argc, char *argv[])
{
	cout << "__DATE__ macro: " << __DATE__ << std::endl;
	cout << "__FILE__ macro: " << __FILE__ << std::endl;
	cout << "__LINE__ macro: " << __LINE__ << std::endl;
	cout << "__TIME__ macro: " << __TIME__ << std::endl;
	cout << "__TIMESTAMP__ macro: " << __TIMESTAMP__ << std::endl;
}
