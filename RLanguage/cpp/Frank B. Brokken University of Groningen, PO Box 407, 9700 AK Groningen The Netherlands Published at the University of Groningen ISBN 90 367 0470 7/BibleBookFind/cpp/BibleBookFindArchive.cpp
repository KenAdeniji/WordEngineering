/*
	2020-04-27	Created.
	2016-10-05T06:55:00 http://stackoverflow.com/questions/12248703/creating-an-instance-of-class
	2020-01-14T11:23	LINK : fatal error LNK1104: cannot open file 'libucrt.lib'
	2020-01-16T14:20:00	https://stackoverflow.com/questions/50220966/how-to-use-vectors-of-c-stl-with-webassembly
	2020-01-17T13:23:00	https://stackoverflow.com/questions/37362473/modern-c-way-to-copy-string-into-char
*/

#include <iostream>
#include <string>
#include <vector>

#include "BibleBook.hpp"

using namespace std;

void initialization();
BibleBook getBibleBook(int id);
int getBibleBook(string title);

vector<BibleBook> BibleBooks;

void initialization()
{
	BibleBooks.push_back(BibleBook(1,"Genesis",50));
	BibleBooks.push_back(BibleBook(2,"Exodus",40));
	BibleBooks.push_back(BibleBook(3,"Leviticus",27));
	BibleBooks.push_back(BibleBook(4,"Numbers",36));
	BibleBooks.push_back(BibleBook(5,"Deuteronomy",34));
	BibleBooks.push_back(BibleBook(6,"Joshua",24));
	BibleBooks.push_back(BibleBook(7,"Judges",21));
	BibleBooks.push_back(BibleBook(8,"Ruth",4));
	BibleBooks.push_back(BibleBook(9,"1 Samuel",31));
	BibleBooks.push_back(BibleBook(10,"2 Samuel",24));
	BibleBooks.push_back(BibleBook(11,"1 Kings",22));
	BibleBooks.push_back(BibleBook(12,"2 Kings",25));
	BibleBooks.push_back(BibleBook(13,"1 Chronicles",29));
	BibleBooks.push_back(BibleBook(14,"2 Chronicles",36));
	BibleBooks.push_back(BibleBook(15,"Ezra",10));
	BibleBooks.push_back(BibleBook(16,"Nehemiah",13));
	BibleBooks.push_back(BibleBook(17,"Esther",10));
	BibleBooks.push_back(BibleBook(18,"Job",42));
	BibleBooks.push_back(BibleBook(19,"Psalms",150));
	BibleBooks.push_back(BibleBook(20,"Proverbs",31));
	BibleBooks.push_back(BibleBook(21,"Ecclesiastes",12));
	BibleBooks.push_back(BibleBook(22,"Song of Solomon",8));
	BibleBooks.push_back(BibleBook(23,"Isaiah",66));
	BibleBooks.push_back(BibleBook(24,"Jeremiah",52));
	BibleBooks.push_back(BibleBook(25,"Lamentations",5));
	BibleBooks.push_back(BibleBook(26,"Ezekiel",48));
	BibleBooks.push_back(BibleBook(27,"Daniel",12));
	BibleBooks.push_back(BibleBook(2728,"Hosea",14));
	BibleBooks.push_back(BibleBook(29,"Joel",3));
	BibleBooks.push_back(BibleBook(30,"Amos",9));
	BibleBooks.push_back(BibleBook(31,"Obadiah",1));
	BibleBooks.push_back(BibleBook(32,"Jonah",4));
	BibleBooks.push_back(BibleBook(33,"Micah",7));
	BibleBooks.push_back(BibleBook(34,"Nahum",3));
	BibleBooks.push_back(BibleBook(35,"Habakkuk",3));
	BibleBooks.push_back(BibleBook(36,"Zephaniah",3));
	BibleBooks.push_back(BibleBook(37,"Haggai",2));
	BibleBooks.push_back(BibleBook(38,"Zechariah",14));
	BibleBooks.push_back(BibleBook(39,"Malachi",4));
	BibleBooks.push_back(BibleBook(40,"Matthew",28));
	BibleBooks.push_back(BibleBook(41,"Mark",16));
	BibleBooks.push_back(BibleBook(42,"Luke",24));
	BibleBooks.push_back(BibleBook(43,"John",21));
	BibleBooks.push_back(BibleBook(44,"Acts",28));
	BibleBooks.push_back(BibleBook(45,"Romans",16));
	BibleBooks.push_back(BibleBook(46,"1 Corinthians",16));
	BibleBooks.push_back(BibleBook(47,"2 Corinthians",13));
	BibleBooks.push_back(BibleBook(48,"Galatians",6));
	BibleBooks.push_back(BibleBook(49,"Ephesians",6));
	BibleBooks.push_back(BibleBook(50,"Philippians",4));
	BibleBooks.push_back(BibleBook(51,"Colossians",4));
	BibleBooks.push_back(BibleBook(52,"1 Thessalonians",5));
	BibleBooks.push_back(BibleBook(53,"2 Thessalonians",3));
	BibleBooks.push_back(BibleBook(54,"1 Timothy",6));
	BibleBooks.push_back(BibleBook(55,"2 Timothy",4));
	BibleBooks.push_back(BibleBook(56,"Titus",3));
	BibleBooks.push_back(BibleBook(57,"Philemon",1));
	BibleBooks.push_back(BibleBook(58,"Hebrews",13));
	BibleBooks.push_back(BibleBook(59,"James",5));
	BibleBooks.push_back(BibleBook(60,"1 Peter",5));
	BibleBooks.push_back(BibleBook(61,"2 Peter",3));
	BibleBooks.push_back(BibleBook(62,"1 John",5));
	BibleBooks.push_back(BibleBook(63,"2 John",1));
	BibleBooks.push_back(BibleBook(64,"3 John",1));
	BibleBooks.push_back(BibleBook(65,"Jude",1));
	BibleBooks.push_back(BibleBook(66,"Revelation",22));
}

BibleBook getBibleBook(int id)
{
	return BibleBooks[id - 1];
}

int getBibleBook(string title)
{
	BibleBook bibleBookIterate;
	for (int index = 0, size = BibleBooks.size(); index <= size; ++index)
	{
		bibleBookIterate = BibleBooks[index];
		if 
		(
			//strcasecmp(bibleBookIterate.getTitle().c_str(), title.c_str())
			_stricmp(bibleBookIterate.getTitle().c_str(), title.c_str()) == 0
		)
		{
			return index;
		}	
	}
	return -1;	
}
	
int main(int argc, char *argv[])
{
	initialization();
	cout << getBibleBook(41) << std::endl;
	
	int bookID = getBibleBook("Ruth");
	cout << BibleBooks[bookID] << std::endl;
	
	return 1;
}
