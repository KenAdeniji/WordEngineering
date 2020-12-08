// compile with: /GR /EHsc
/*
	2016-01-06	Created.	http://ptgmedia.pearsoncmg.com/images/9780134383583/samplepages/9780134383583.pdf
*/

#include <iostream>

using namespace std;

int main(int argc, char* argv[])
{
	for( int i = 0; i < argc; ++i )
		cout << "Argument[" << i << "]: " << argv[i] << '\n';
	return 0;	
}
