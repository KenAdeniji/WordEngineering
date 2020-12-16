#include <iostream>
#include <time.h>       // Prototype of time()
#include <stdlib.h>     // Prototypes of srand()
// and rand()

#include <ctime>

/*
	2018-10-29	http://www.lmpt.univ-tours.fr/~volkov/C++.pdf
	2018-10-29	https://stackoverflow.com/questions/36576285/convert-long-int-to-const-time-t
*/
using namespace std;

void main(int argc, char *argv[])
{
/*
	long sec;
	time( &sec );           // Take the number of seconds and
	srand( (unsigned)sec ); // use it to initialize. 
*/
	std::time_t twit;
	time( &twit );          // Take the number of seconds and
	srand( (unsigned)twit ); // use it to initialize. 

	cout << rand() << endl;
}
