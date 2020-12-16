/*
	2020-04-01	https://github.com/isocpp/CppCoreGuidelines/blob/master/CppCoreGuidelines.md
	2020-04-01	https://stackoverflow.com/questions/4268886/initialize-a-vector-array-of-strings
	2020-04-01	https://stackoverflow.com/questions/19018337/understanding-find-and-vectors-c
*/

#include <algorithm>
#include <iostream>
#include <string>
#include <vector>

using namespace std;

void f(vector<string>& v);

void f(vector<string>& v)
{
    string val;
    cin >> val;
    std::vector<string>::iterator p = find(begin(v), end(v), val);
	cout<< *p << endl;
}

int main(int argc, char *argv[]) 
{
	std::vector<std::string> v = { "Genesis", "Exodus", "Leviticus", "Numbers", "Deuteronomy" };
	f(v);
} 
