#include <string>

#include "..\..\IfEntiretyBeTheSame\cpp\IfEntiretyBeTheSame.hpp"

using namespace std;

// BibleBook member function
static char* copyStringIntoCharPointerUsingStdStrCopy(const string src)
{
    char* output = new char[src.size() + 1];
    std::strcpy(output, src.c_str());
    //std::cout << output;
    //delete output;
	return output;
}
