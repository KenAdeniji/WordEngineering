#include <iostream>
#include <stdlib.h>
#include <time.h>

/*
	http://stackoverflow.com/questions/322938/recommended-way-to-initialize-srand
*/
using namespace std;

void main(void)
{
	time_t now;
	tm* local;
	time(&now); 
	local=localtime(&now);
	srand(now);
	cout << rand() << endl;
}
