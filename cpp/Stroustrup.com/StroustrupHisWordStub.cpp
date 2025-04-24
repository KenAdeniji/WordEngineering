/*
	2022-12-18T20:18:00 Created.	http://greenteapress.com/thinkcpp/thinkCScpp.pdf
	2016-10-05T06:55:00 http://stackoverflow.com/questions/12248703/creating-an-instance-of-class
	2025-04-20T17:24:00	http://stroustrup.com/tour3-12-Cont.pdf
*/

#include <iostream>
#include <vector>

#include "StroustrupHisWord.hpp"

using namespace std;

void stub();
void print_hisWords_iterate(const vector<StroustrupHisWord>&);
void print_hisWords_subscripting(const vector<StroustrupHisWord>&);

void print_hisWords_iterate(const vector<StroustrupHisWord>& hisWords)
{
	for (const auto& x : hisWords)
	{	
		cout << x << endl;
	}	
}

void print_hisWords_subscripting(const vector<StroustrupHisWord>& hisWords)
{
	for (int i = 0, hisWordsSize = hisWords.size(); i < hisWordsSize; ++i)
	{	
		cout << hisWords[i] << endl;
	}	
}

void stub()
{
	vector<StroustrupHisWord> stroustrupHisWords = 
	{
		{"In the beginning", "First phrase in the Bible..."},
		{"The grace of our LORD Jesus Christ be with you all. Amen.", "Last phrase in the Bible..."}
	};
	//print_hisWords_subscripting(stroustrupHisWords);
	print_hisWords_iterate(stroustrupHisWords);
}

void main(int argc, char *argv[])
{
	stub();
}
