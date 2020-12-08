// compile with: /GR /EHsc
/*
	2016-01-06	Created.	http://ptgmedia.pearsoncmg.com/images/9780134383583/samplepages/9780134383583.pdf
*/

#include <iostream>

using namespace std;

int main()
{
	char *source = "Good", *target = "Good";
	while (*target++= *source++);
	for (; *source; target++, source++)
		*target = *source;
	*target = *source;
	cout << "Source: " << source << " Target: " << target << endl; 
}
