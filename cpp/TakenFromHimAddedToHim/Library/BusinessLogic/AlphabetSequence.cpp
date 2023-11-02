#include <iostream>

#include <cassert>
#include <string>
#include <sstream>

#include <cstring>

#include "AlphabetSequence.hpp"
#include "UtilityHelper.hpp"

using namespace std;

namespace InformationInTransit
{
	namespace BusinessLogic
	{
		AlphabetSequence::AlphabetSequence
		(
			char *word
		)
		{
			setAlphabetSequence(word);
		}

/*
		ostream& operator <<(ostream& outputStream, AlphabetSequence& alphabetSequence)
		{
			return
				outputStream
				<< "Word=" //<< alphabetSequence.Word
				;
		}		
*/

		std::ostream& operator<<(std::ostream &strm, AlphabetSequence& alphabetSequence) 
		{
			//return strm << "AlphabetSequence(" << alphabetSequence.getIndex() << ")";
			return strm;
		}
		 
		void AlphabetSequence::setAlphabetSequence
		(
			char *word 
		)
		{
			UtilityHelper::copySample(word, Word);
			AlphabetSequence::setIndex(word);
		}

		long AlphabetSequence::getIndex()
		{
			return Index;
		};

		void AlphabetSequence::setIndex
		(
			char *word 
		)
		{
			bool wordIsNumber = UtilityHelper::isNumber(word);
			Index = wordIsNumber ? 
				atoll(word) : 
				calcAlphabetSequenceIndex(word);
		}

		char * AlphabetSequence::getWord()
		{
			return Word;
		};

		
		long AlphabetSequence::calcAlphabetSequenceIndex
		(
			char* word
		)	
		{
			long alphabetSequenceIndex = 0;
			int destination_size = strlen(word);
			
			for 
			(
				unsigned int index = 0, size = strlen(word); 
				index < size;
				index++
			) 
			{
				long currentUnicodeValue = word[index];
				if ((currentUnicodeValue >= 65L) && (currentUnicodeValue <= 90L)) //Upper case
				{	
					alphabetSequenceIndex += (currentUnicodeValue -64L);
				}	
				if ((currentUnicodeValue >= 97L) && (currentUnicodeValue <= 122L)) //Lower case
				{	
					alphabetSequenceIndex += (currentUnicodeValue -96L);
				}	
			}
			
			return alphabetSequenceIndex;
		}
		
	}
}
