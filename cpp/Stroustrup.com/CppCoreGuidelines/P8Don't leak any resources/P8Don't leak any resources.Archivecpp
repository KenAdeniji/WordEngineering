/*
	2020-04-03	https://github.com/isocpp/CppCoreGuidelines/blob/master/CppCoreGuidelines.md
	2020-04-03	https://stackoverflow.com/questions/7868936/read-file-line-by-line-using-ifstream-in-c
*/

#include <algorithm>
#include <fstream>
#include <iostream>

#include <sstream>
#include <string>

using namespace std;

void FILEfopen(char* name)
{
    FILE* input = fopen(name, "r");
    // ...
    if (1 == 1) return;   // bad: if something == true, a file handle is leaked
    // ...
    fclose(input);
}

void InputStream(char* name)
{
    ifstream input(name);
    // ...
    if (!input) return;   // OK: no leak
    // ...
	for( std::string line; getline( input, line ); )
	{
		cout << line << endl;
	}
}

void main(int argc, char *argv[]) 
{
	InputStream("P8Don't leak any resources.cpp");
} 
