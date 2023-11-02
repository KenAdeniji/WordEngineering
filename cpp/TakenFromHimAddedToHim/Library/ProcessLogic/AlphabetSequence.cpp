#include <iostream>

#include <cassert>
#include <string>
#include <sstream>

#include <cstring>

#include "AlphabetSequence.hpp"

using namespace std;

/*
namespace WordEngineering
{
	namespace TakenFromHimAddedToHim
	{
*/		
		AlphabetSequence::AlphabetSequence
		(
			char *word
		)
		{
			setAlphabetSequence(word);
		}

		ostream& operator <<(ostream& outputStream, AlphabetSequence& alphabetSequence)
		{
			return
				outputStream
				<< "Word=" //<< alphabetSequence.Word
				;
		}		
		 
		void AlphabetSequence::setAlphabetSequence
		(
			char *word 
		)
		{
			//size_t destination_size = sizeof(word);
			int destination_size = strlen(word);
			strncpy(Word, word, destination_size);
			Word[destination_size] = '\0';
			
			//snprintf(Word, destination_size, "%s", word);
		}

/*
		std::string toString()
		{
			return "Word: " + *Word + "\n";
		}
*/
		
/*
	}
}
*/
