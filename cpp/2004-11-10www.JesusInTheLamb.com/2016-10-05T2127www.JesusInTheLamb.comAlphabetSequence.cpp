/*
	2016-10-05T21:27:00	2016-10-05T2127www.JesusInTheLamb.comAlphabetSequence.cpp
	2016-10-04	http://stackoverflow.com/questions/1549930/c-equivalent-of-java-tostring
	
	2016-10-05T21:21:00	2016-10-05T2105www.JesusInTheLamb.comAlphabetSequence.hpp
		void	setAlphabetSequenceIndex(string word);
		void	setAlphabetSequenceIndex(unsigned long alphabetSequenceIndex);
		
	2016-10-05T21:37:00	2016-10-05T2105www.JesusInTheLamb.comAlphabetSequence.hpp
		AlphabetSequence(unsigned long alphabetSequenceIndex);
		
	2016-10-05T22:05:00	
		cl /EHsc 2016-10-05T2127www.JesusInTheLamb.comAlphabetSequence.cpp
		
	2016-10-05T22:28:00
		http://stackoverflow.com/questions/947621/how-do-i-convert-a-long-to-a-string-in-c
*/

#include <cassert>
#include <string>
#include <sstream>

#include "2016-10-05T2228www.JesusInTheLamb.comUnicodeHelper.hpp"
#include "2016-10-05T2105www.JesusInTheLamb.comAlphabetSequence.hpp"

using namespace std;

namespace InformationInTransit
{
	// AlphabetSequence constructor
	AlphabetSequence::AlphabetSequence
	(
		string	word
	)
	{
		setAlphabetSequence(word);
	}

	AlphabetSequence::AlphabetSequence
	(
		unsigned long long	alphabetSequenceIndex
	)
	{
		string word = "";
		
		stringstream mystream;
		mystream << alphabetSequenceIndex;
		word = mystream.str();
		
		setAlphabetSequence(word);
	}
	
	// AlphabetSequence operator overloading

	ostream& operator <<(ostream& outputStream, const AlphabetSequence& alphabetSequence)
	{
		outputStream
			<< "word=" << alphabetSequence.word
			;
			
		return outputStream;
	}		
	 
	// AlphabetSequence member function
	void AlphabetSequence::setAlphabetSequence
	(
		string	word
	)
	{
		this->word = word;
	}
}
