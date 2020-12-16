// compile with: /GR /EHsc
/*
	2015-03-10	Created.
*/

#include <iostream>
#include <string>

#include "Composer.h"

using namespace std;

using namespace WordEngineering;

int main()
{
	composer.dataEntry();
	composer.writeFile();
	composer.readFile();
}
