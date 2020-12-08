#include <iostream>
#include <string>

using namespace std;
//2016-10-03 cl /clr TheC++PreprocessorDirectiveDefine.cpp

#define HelloWorld \
	"Hello world"
#define PI 3.14159

void main(int argc, char *argv[])
{
	cout << "PI: " << PI << '\n';
	cout << HelloWorld << '\n';
}
