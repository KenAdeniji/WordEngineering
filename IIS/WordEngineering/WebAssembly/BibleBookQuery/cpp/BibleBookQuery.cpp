/*
	2019-12-30	Created.
	2016-10-05T06:55:00 http://stackoverflow.com/questions/12248703/creating-an-instance-of-class
	2020-01-16T14:20:00	https://stackoverflow.com/questions/50220966/how-to-use-vectors-of-c-stl-with-webassembly
*/

#include <emscripten.h> // note we added the emscripten header

#include "BibleBook.hpp"

extern "C" {
	char* getTitle(int id);
}

const int Bible_Book_Size = 66;

char* getTitle(int id);

BibleBook BibleBooks[Bible_Book_Size] =
{
	BibleBook(1,"Genesis",50),
	BibleBook(2,"Exodus",40),
	BibleBook(3,"Leviticus",27),
	BibleBook(4,"Numbers",36),
	BibleBook(5,"Deuteronomy",34),
	BibleBook(6,"Joshua",24),
	BibleBook(7,"Judges",21),
	BibleBook(8,"Ruth",4),
	BibleBook(9,"1 Samuel",31),
	BibleBook(10,"2 Samuel",24),
	BibleBook(11,"1 Kings",22),
	BibleBook(12,"2 Kings",25),
	BibleBook(13,"1 Chronicles",29),
	BibleBook(14,"2 Chronicles",36),
	BibleBook(15,"Ezra",10),
	BibleBook(16,"Nehemiah",13),
	BibleBook(17,"Esther",10),
	BibleBook(18,"Job",42),
	BibleBook(19,"Psalms",150),
	BibleBook(20,"Proverbs",31),
	BibleBook(21,"Ecclesiastes",12),
	BibleBook(22,"Song of Solomon",8),
	BibleBook(23,"Isaiah",66),
	BibleBook(24,"Jeremiah",52),
	BibleBook(25,"Lamentations",5),
	BibleBook(26,"Ezekiel",48),
	BibleBook(27,"Daniel",12),
	BibleBook(28,"Hosea",14),
	BibleBook(29,"Joel",3),
	BibleBook(30,"Amos",9),
	BibleBook(31,"Obadiah",1),
	BibleBook(32,"Jonah",4),
	BibleBook(33,"Micah",7),
	BibleBook(34,"Nahum",3),
	BibleBook(35,"Habakkuk",3),
	BibleBook(36,"Zephaniah",3),
	BibleBook(37,"Haggai",2),
	BibleBook(38,"Zechariah",14),
	BibleBook(39,"Malachi",4),
	BibleBook(40,"Matthew",28),
	BibleBook(41,"Mark",16),
	BibleBook(42,"Luke",24),
	BibleBook(43,"John",21),
	BibleBook(44,"Acts",28),
	BibleBook(45,"Romans",16),
	BibleBook(46,"1 Corinthians",16),
	BibleBook(47,"2 Corinthians",13),
	BibleBook(48,"Galatians",6),
	BibleBook(49,"Ephesians",6),
	BibleBook(50,"Philippians",4),
	BibleBook(51,"Colossians",4),
	BibleBook(52,"1 Thessalonians",5),
	BibleBook(53,"2 Thessalonians",3),
	BibleBook(54,"1 Timothy",6),
	BibleBook(55,"2 Timothy",4),
	BibleBook(56,"Titus",3),
	BibleBook(57,"Philemon",1),
	BibleBook(58,"Hebrews",13),
	BibleBook(59,"James",5),
	BibleBook(60,"1 Peter",5),
	BibleBook(61,"2 Peter",3),
	BibleBook(62,"1 John",5),
	BibleBook(63,"2 John",1),
	BibleBook(64,"3 John",1),
	BibleBook(65,"Jude",1),
	BibleBook(66,"Revelation",22)
};	

char* EMSCRIPTEN_KEEPALIVE getTitle(int id)
{
	return (char *) BibleBooks[id - 1].getTitle();
}
	
int main(int argc, char *argv[])
{
	//initialization();
	return 1;
}
