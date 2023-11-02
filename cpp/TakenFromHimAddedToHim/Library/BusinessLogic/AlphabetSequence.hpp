/*
	2023-11-01T07:50:00	Created.
	2016-02-11	http://www.learncpp.com/cpp-tutorial/89-class-code-and-header-files/			
*/
#include <cassert>
#include <string>
#include <sstream>

using namespace std;

#ifndef WordEngineering_AlphabetSequence_HPP
#define WordEngineering_AlphabetSequence_HPP

namespace InformationInTransit
{
	namespace BusinessLogic
	{
		class AlphabetSequence
		{
			private:
			public:
				char* Word;
				long Index;
		 
			public:
				AlphabetSequence
				(
					char*
				);
			 
				friend ostream& operator <<(ostream& outputStream, const AlphabetSequence& alphabetSequence);
			 
				void setAlphabetSequence
				(
					char*
				);
		/*
				long getIndex
				(
				);
		*/	

				void setIndex
				(
					char *
				);

				long calcAlphabetSequenceIndex
				(
					char*
				);
		};
	}
}	

#endif
