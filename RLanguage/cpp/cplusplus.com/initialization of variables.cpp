// initialization of variables http://www.cplusplus.com/doc/tutorial/variables/

#include <iostream>
#include <string>

using namespace std;

int main ()
{
	int a=5;               // initial value: 5
	int b = 3;              // initial value: 3. int b(3);
	int c = 2;              // initial value: 2. int c{2};
	int result;            // initial value undetermined

	a = a + b;
	result = a - c;
	cout << "result: " << result << endl;

	int foo = 0;
	auto bar = foo;  // the same as: int bar = foo; 
	cout << "bar: " << bar << endl;
  
	decltype(foo) boo = 53;  // the same as: int boo; 
	cout << "boo: " << boo << endl;

	string mystring;
	mystring = "This is a string";
	cout << "mystring: " << mystring << endl;;

	int intDecimal = 75;		// decimal
	int intOctal = 0113;		// octal
	int intHexadecimal = 0x4b;	// hexadecimal  
	
	cout << "Decimal: " << intDecimal << endl;
	cout << "Octal: " << std::oct << intOctal << endl;
	cout << "Hexadecimal: " << std::hex << intHexadecimal << endl;
	
	return 0;
}
