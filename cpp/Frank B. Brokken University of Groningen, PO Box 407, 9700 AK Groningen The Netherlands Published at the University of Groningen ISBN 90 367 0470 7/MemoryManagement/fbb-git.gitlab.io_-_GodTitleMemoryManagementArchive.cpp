/*
	2020-04-29	Created. https://fbb-git.gitlab.io/cppannotations/cppannotations/html
	2019-12-30	https://medium.com/@tdeniffel/pragmatic-compiling-from-c-to-webassembly-a-guide-a496cc5954b8
	2016-10-04	http://stackoverflow.com/questions/1549930/c-equivalent-of-java-tostring
	2019-12-31	http://www.fredosaurus.com/notes-cpp/oop-condestructors/copyructors.html
*/

#include <cassert>
#include <string>

#include "fbb-git.gitlab.io_-_GodTitleMemoryManagement.hpp"

using namespace std;

// GodTitle destructor
GodTitle::~GodTitle
(
)
{

}

GodTitle::GodTitle( GodTitle& godTitle) //copy constructor
{ 
	title = godTitle.title;
	commentary = godTitle.commentary;
	scriptureReference = godTitle.scriptureReference;
} 

// GodTitle operator overloading

ostream& operator <<(ostream& outputStream,  GodTitle& GodTitle)
{
	outputStream
		<< "title = " << GodTitle.getTitle()
		<< " commentary = " << GodTitle.getCommentary()
		<< " scriptureReference = " << GodTitle.getScriptureReference()		
		;
		
	return outputStream;
}		

// GodTitle member function
void GodTitle::setGodTitle
(
	string  title,
	string  commentary,
	string  scriptureReference
)
{
	this->title = title;
	this->commentary = commentary;
	this->scriptureReference = scriptureReference;
}

string  GodTitle::getTitle() 
{ 
	return title;	
}

string  GodTitle::getCommentary() 
{
	return commentary;
}

string  GodTitle::getScriptureReference() 
{
	return scriptureReference;
}

void GodTitle::setTitle
(
	string	&title
)
{
	//this->title = title;
}

void GodTitle::setCommentary
(
	string &commentary
)
{
	//this->commentary = commentary;
}

void GodTitle::setScriptureReference
(
	string &scriptureReference
)
{
	//this->scriptureReference = scriptureReference;
}
