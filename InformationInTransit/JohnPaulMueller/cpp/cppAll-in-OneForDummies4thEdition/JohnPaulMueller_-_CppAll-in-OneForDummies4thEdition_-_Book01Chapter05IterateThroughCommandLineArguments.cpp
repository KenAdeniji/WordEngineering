/*
	http://www.wiley.com/en-us/C%2B%2B+All-in-One+For+Dummies%2C+4th+Edition-p-9781119601739
	John@JohnMuellerBooks.com
	C++ All-in-One For Dummies, 4th Edition
	John Paul Mueller 
	ISBN: 978-1-119-60173-9
	December 2020
	912 pages	
	2025-09-10T19:45:00 Date created.
	
http://stackoverflow.com/questions/8572991/how-to-write-the-range-based-for-loop-with-argv

The vector solution proposed copies the array (the pointers only, not the strings1 - but still). Unnessary. The argv_range solution is what I would have tried, too, if I absolutely wanted to enforce a range based loop. But that produces a lot of extra code (admitted, only once, if you write it to a header file and keep it, but still).

The classic loop appears so easy to me that I allow myself just to post it, I don't consider it worth to have all this effort just to have a range based loop...

for (char** a = argv; *a; ++a)
{
    // use *a, or if you don't like:
    char* arg = *a;
    // use arg...
}

Or, if you won't ever need the argv array afterwards any more:

for (++argv; *argv; ++argv)
{
    // use *argv, or if you don't like:
    char* a = *argv;
    // use a...
}

There is a little difference, you might have noticed: In the first variant, I iterate over all the values, in the second, I leave out the first one (which normally is the program name we are not interested in in many cases). The other way round, for each:

for (char** a = argv + 1; *a; ++a);
for (; *argv; ++argv);

Note that all these variants profit from the fact that the strings array itself is null-pointer-terminated as well, just as any of the strings is null-character-terminated, thus the simple checks for *a or *argv.

1This applies only, if using std::vector<char*>; if using std::vector<std::string>, as actually proposed, even the strings themselves are copied!
Share
Improve this answer
Follow
edited Sep 8, 2022 at 22:40
answered Mar 15, 2016 at 13:19
Aconcagua's user avatar
Aconcagua
25.6k44 gold badges3737 silver badges65	
*/
#include <iostream>

using namespace std;

int main(int argc, char *argv[])
{
	for (auto a = argv + 1; *a; ++a) //for (char** a = argv + 1; *a; ++a) //c++ 11 auto keyword. Letting C++ determine the type. C++ auto versus (VS) C# dynamic
	{
		// use *a, or if you don't like:
		// auto arg = *a; //char* a = *argv;
		// use arg...
		cout << *a << endl;	
	}	
}
