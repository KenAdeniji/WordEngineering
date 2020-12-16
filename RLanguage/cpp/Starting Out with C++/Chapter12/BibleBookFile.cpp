#include <iostream>
#include <fstream>
#include <string>
#include <vector>

using namespace std;

void fileInput(void);
void fileOutput(void);

std::vector<std::string> BibleBooks = {
	"Genesis",
	"Exodus",
	"Leviticus",
	"Numbers",
	"Deuteronomy"
};

void fileInput(void)
{
	string filename = "BibleBook.txt";
	//fstream bibleBookFile(filename, ios::in | ios::out);
	fstream bibleBookFile(filename, ios::in);
	if (!bibleBookFile || bibleBookFile.fail())
	{
		cout << filename << " file open error." << endl;
		return;
	}
	int index = -1;
	while(!bibleBookFile.eof())
	{
		bibleBookFile >> BibleBooks[++index];
		cout << BibleBooks[index] << endl;
	}	
	bibleBookFile.close();
}

void fileOutput(void)
{
	string filename = "BibleBook.txt";
	//fstream bibleBookFile(filename, ios::in | ios::out);
	fstream bibleBookFile(filename, ios::out);
	if (!bibleBookFile || bibleBookFile.fail())
	{
		cout << filename << " file open error." << endl;
		return;
	}
	for 
	(
		int index = 0, length = BibleBooks.size();
		index < length;
		++index
	)
	{
		bibleBookFile << BibleBooks[index] << endl;
	}	
	bibleBookFile.close();
}

void main(void)
{
	fileOutput();
	fileInput();
}
