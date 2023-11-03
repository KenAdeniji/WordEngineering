/*
	2023-11-01T07:50:00	Created.
	2016-02-11	http://www.learncpp.com/cpp-tutorial/89-class-code-and-header-files/			
	2023-11-02T08:16:00 Access modifier, friend, private, protected, public.
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
				char *Word;
				long Index;

			protected:
				void setAlphabetSequence
				(
					char*
				);

				void setIndex
				(
					char *
				);

				long calcAlphabetSequenceIndex
				(
					char *
				);
				
			public:
				AlphabetSequence
				(
					char *
				);
			 
				friend ostream& operator <<(ostream&, const AlphabetSequence&);		
				long getIndex();

				char * getWord();
		};
	}
}	

#endif
