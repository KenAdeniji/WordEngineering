/*
	2020-04-02	https://github.com/isocpp/CppCoreGuidelines/blob/master/CppCoreGuidelines.md
	2020-04-02	http://www.cplusplus.com/reference/algorithm/for_each/
*/

#include <algorithm>
#include <iostream>
#include <string>
#include <vector>

using namespace std;

void forLoop(vector<string>& v);

void forLoop(vector<string>& v)
{
	for_each(v.begin(), v.end(), [](string x) { cout << x << endl; });
}

int main(int argc, char *argv[]) 
{
	std::vector<std::string> v = { "Genesis", "Exodus", "Leviticus", "Numbers", "Deuteronomy" };
	forLoop(v);
} 
