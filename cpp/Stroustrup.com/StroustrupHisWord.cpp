/*
	2022-12-10T19:52:00 Created.	http://greenteapress.com/thinkcpp/thinkCScpp.pdf
	2016-10-04	http://stackoverflow.com/questions/1549930/c-equivalent-of-java-tostring
	2025-04-20T17:56:00...http://stackoverflow.com/questions/997946/how-to-get-current-time-and-date-in-c
*/
#include <ctime>
#include <iomanip>
#include <iostream>
#include <string>

#include "StroustrupHisWord.hpp"

using namespace std;

long	HisWord_Identity	=	0;

// StroustrupHisWord constructor
StroustrupHisWord::StroustrupHisWord
(
	std::string		word,
	std::string		commentary
)
{
	setStroustrupHisWord
	(
		word, 
		commentary
	);
}

// StroustrupHisWord operator overloading

ostream& operator <<(ostream& outputStream, const StroustrupHisWord& StroustrupHisWord)
{
	outputStream
		<< 	"commentary = "	 	<< 	StroustrupHisWord.commentary
		<<	" dated = " 		<< 	std::put_time(localtime(&StroustrupHisWord.dated), "%F %T")
		<<	" hisWordID = " 	<< 	StroustrupHisWord.hisWordID
		<< 	" word = " 			<< 	StroustrupHisWord.word
		;
		
	return outputStream;
}		
 
// StroustrupHisWord member function
void StroustrupHisWord::setStroustrupHisWord
(
	std::string		word,
	std::string		commentary
)
{
	this->commentary	= 	commentary;
	this->dated			=	chrono::system_clock::to_time_t(chrono::system_clock::now());
	this->hisWordID		=	++HisWord_Identity;
	this->word			= 	word;
}

std::string StroustrupHisWord::getCommentary()
{
	return	commentary;
}

std::string StroustrupHisWord::getWord()
{ 
	return	word;
}

void StroustrupHisWord::setCommentary
(
	std::string		commentary
)
{
	this->commentary	= 	commentary;
}

void StroustrupHisWord::setWord
(
	std::string		word
)
{
	this->word			= 	word;
}
