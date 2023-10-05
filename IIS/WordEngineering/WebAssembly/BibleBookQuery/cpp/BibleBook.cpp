/*
	2019-12-30	https://medium.com/@tdeniffel/pragmatic-compiling-from-c-to-webassembly-a-guide-a496cc5954b8
	2016-10-04	http://stackoverflow.com/questions/1549930/c-equivalent-of-java-tostring
	2019-12-31	http://www.fredosaurus.com/notes-cpp/oop-condestructors/copyconstructors.html
*/

//#include <cassert>
#include <iostream>
//#include <string>

#include "BibleBook.hpp"

using namespace std;

// BibleBook constructor

BibleBook::BibleBook
(
	int 	id,
	char*	title,
	int		chapters
)
{
	setBibleBook(id, title, chapters);
}

// BibleBook operator overloading

ostream& operator <<(ostream& outputStream, const BibleBook& BibleBook)
{
	outputStream
		<< "title=" << BibleBook.title
		<< " chapters=" << BibleBook.chapters
		;
		
	return outputStream;
}		

// BibleBook member function
void BibleBook::setBibleBook
(
	int 	id,
	char*	title,
	int		chapters
)
{
	//assert(id < 1);

	this->id = id;
	this->title = title;
	this->chapters = chapters;
}

int BibleBook::getID() const
{ 
	return id;	
}

char* BibleBook::getTitle() const
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
	//assert(id < 1);
	
	this->id = id;
}
	
void BibleBook::setTitle
(
	char*	title
)
{
	this->title = title;
}

void BibleBook::setChapters
(
	int chapters
)
{
	//assert(chapters < 0);
	
	this->chapters = chapters;
}

/*
BibleBook::BibleBook(const BibleBook& bibleBook) 
{ 
	this->id = bibleBook.id;
	this->title = bibleBook.title;
	this->chapters = bibleBook.chapters;
} 

BibleBook& BibleBook::operator=( const BibleBook& other ) {
  id = other.id;
  title = other.title;
  chapters = other.chapters;
  return *this;
}
*/