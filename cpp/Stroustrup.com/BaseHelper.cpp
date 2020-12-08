// compile with: /GR /EHsc
/*
	2015-03-06	Created. http://stroustrup.com/Programming
*/

#include <iostream>
#include <string>

using namespace std;

int main()
{
	int eight = 8;
	cout << "Decimal: " << dec << noshowbase << eight << endl;
	cout << "Octal: " << oct << showbase << eight << endl;
	cout << "Hex: " << hex << showbase << eight << endl;	
}
