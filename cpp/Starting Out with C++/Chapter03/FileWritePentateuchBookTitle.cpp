/*
	2021-04-12T18:48:00	Created.
		cl /GR /EHsc FileWritePentateuchBookTitle.cpp
*/

#include <fstream>
#include <iostream>
#include <string>
#include <vector>

using namespace std;

void main(void)
{
	ofstream outputFile;

	std::vector<std::string> bookTitles
	{
		"Genesis",
		"Exodus",
		"Leviticus",
		"Numbers",
		"Deuteronomy"
	};	

	outputFile.open("FileWritePentateuchBookTitle.txt");

	for 
	(
		int index = 0, length = bookTitles.size();
		index < length;
		++index
	)
	{
        outputFile << bookTitles[index] << endl;
    }
	
	outputFile.close();
}
