/*
	2019-12-30	https://medium.com/@tdeniffel/pragmatic-compiling-from-c-to-webassembly-a-guide-a496cc5954b8
	2016-10-04	http://stackoverflow.com/questions/1549930/c-equivalent-of-java-tostring
	2019-12-31	http://www.fredosaurus.com/notes-cpp/oop-condestructors/copyconstructors.html
*/

#include <cassert>
#include <string>

#include "BibleBook.hpp"

using namespace std;

int BibleBook::Occurrences = 0;           // the static data member

// BibleBook constructor

BibleBook::BibleBook
(
)
{
	
}

BibleBook::BibleBook
(
	int 	id,
	string	title,
	int		chapters
)
{
	setBibleBook(id, title, chapters);
	++Occurrences;
}

BibleBook::~BibleBook
(
)
{
	--Occurrences;
}

BibleBook::BibleBook(const BibleBook& bibleBook) //copy constructor
{ 
	id = bibleBook.id;
	title = bibleBook.title;
	chapters = bibleBook.chapters;
} 

// BibleBook operator overloading

ostream& operator <<(ostream& outputStream, const BibleBook& BibleBook)
{
	outputStream
		<< "ID = " << BibleBook.getID()	
		<< " title = " << BibleBook.getTitle()
		<< " chapters = " << BibleBook.getChapters()
		;
		
	return outputStream;
}		

// BibleBook member function
void BibleBook::setBibleBook
(
	int 	id,
	string	title,
	int		chapters
)
{
	assert(id >= 1);

	this->id = id;
	this->title = title;
	this->chapters = chapters;
}

const int BibleBook::getOccurrences()
{ 
	return Occurrences;	
}

int BibleBook::getID() const
{ 
	return id;	
}

string BibleBook::getTitle() const
{ 
	return title;	
}

int BibleBook::getChapters() const
{
	return chapters;
}

void BibleBook::setID
(
	int id
)
{
	this->id = id;
}
	
void BibleBook::setTitle
(
	string	title
)
{
	this->title = title;
}

void BibleBook::setChapters
(
	int chapters
)
{
	this->chapters = chapters;
}
