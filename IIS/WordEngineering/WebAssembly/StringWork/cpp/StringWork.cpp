/*
	2020-01-21	Created.
	2020-01-21	http://stackoverflow.com/questions/5689003/how-to-implode-a-vector-of-strings-into-a-string-the-elegant-way
	2020-01-21	http://www.cplusplus.com/reference/string/string/find
*/

#include <algorithm>
#include <iostream>
#include <regex>
#include <sstream>
#include <vector>

#include <emscripten.h> // note we added the emscripten header

using namespace std;

extern "C" {
	char* getResultSet(string);
}

char* getResultSet(string);

bool CompareInputAscending(const string& left, const string& right)
{
	return left < right;
}

bool CompareInputDescending(const string& left, const string& right)
{
	return left > right;
}

string join(const vector<string>& vec, const char* delim)
{
    stringstream res;
    copy(vec.begin(), vec.end(), ostream_iterator<string>(res, delim));
    return res.str();
}

char* EMSCRIPTEN_KEEPALIVE getResultSet(string dataSet)
{
    string delimiter = " .,:;!?";
	std::regex words_regex("[^\\s.,:;!?]+");
    auto words_begin = std::sregex_iterator(dataSet.begin(), dataSet.end(), words_regex);
    auto words_end = std::sregex_iterator();

	std::vector<std::string> tokens;
    for (std::sregex_iterator i = words_begin; i != words_end; ++i)
	{	
        //std::cout << (*i).str() << '\n';
		string current = (*i).str();
		int position = delimiter.find(current);
		
		if (position > -1)
		{
			continue;
		}
		
		//tokens.push_back( (*i).str() + " length: " + to_string(position) + " current: " + current);
		tokens.push_back( current );
	}
	
	std::vector<std::string> ascendingOrder = tokens;
	std::sort(ascendingOrder.begin(), ascendingOrder.end(), CompareInputAscending);

	std::vector<std::string> descendingOrder = tokens;
	std::sort(descendingOrder.begin(), descendingOrder.end(), CompareInputDescending);
	
	string ascendingOrderJoined = join(ascendingOrder, ",");
	string descendingOrderJoined = join(descendingOrder, ",");
	
	string json = 	"{\"ascendingOrder\":\"" + ascendingOrderJoined + "\"," +
					" \"descendingOrder\":\"" + descendingOrderJoined + "\"}";

	json = 	" ascendingOrder: " + ascendingOrderJoined 
			+	
			" descendingOrder: " + descendingOrderJoined
			;

	char* output = new char[json.size() + 1];
    std::strcpy(output, json.c_str());
	return output;
}
	
int main(int argc, char *argv[])
{
	return 1;
}
