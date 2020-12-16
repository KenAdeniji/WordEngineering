// compile with: cl fbb-git.gitlab.io_-_BibleBook.cpp /EHsc /GR
/*
	2020-04-26	Created. fbb-git.gitlab.io/cppannotations/cppannotations/html
*/

#include <iostream>
#include <string>
#include <vector>

using namespace std;

void display
(
	vector<string>& bibleBooks,
	const int start = 1,
	const int count = 66
);

int main()
{
	vector<string> bibleBooks = 
	{
		"Genesis",
		"Exodus",
		"Leviticus",
		"Numbers",
		"Deuteronomy"
	};
	display(bibleBooks, 1, bibleBooks.size());
}
	
void display
(
	vector<string>& bibleBooks,
	const int start,
	const int end
)
{
	for 
	(
		int index = start;
		index <= end;
		++index
	)
	{
		cout << index << " " << bibleBooks[index - 1] << std::endl;
	}	
}	
