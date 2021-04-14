/*
	2021-04-12T19:59:00	Created.
		cl /GR /EHsc FileReadPentateuchBookTitle.cpp
		https://stackoverflow.com/questions/7868936/read-file-line-by-line-using-ifstream-in-c
*/

#include <fstream>
#include <iostream>
#include <string>
#include <vector>

using namespace std;

void main(void)
{
	ifstream inputFile;

	std::vector<std::string> bookTitles;	

	inputFile.open("FileWritePentateuchBookTitle.txt");

	string bookTitle;

	while (inputFile >> bookTitle)
	{
		bookTitles.push_back(bookTitle);
	}

	for 
	(
		int index = 0, length = bookTitles.size();
		index < length;
		++index
	)
	{
        cout << bookTitles[index] << endl;
    }
	
	inputFile.close();
}
