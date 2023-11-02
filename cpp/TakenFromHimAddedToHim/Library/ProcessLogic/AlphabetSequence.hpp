/*
	2023-11-01T07:50:00	Created.
	2016-02-11	http://www.learncpp.com/cpp-tutorial/89-class-code-and-header-files/			
*/
#include <cassert>
#include <string>
#include <sstream>

using namespace std;

#ifndef WordEngineering_TakenFromHimAddedToHim_HPP
#define WordEngineering_TakenFromHimAddedToHim_HPP

/*
namespace WordEngineering
{
	namespace TakenFromHimAddedToHim
	{
*/		
		class AlphabetSequence
		{
			private:
			public:
				char* Word;
		 
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
				int unsigned getIndex
				(
				);
		*/				
		};
/*
	}
}	
*/

//namespace NamespaceAlias = WordEngineering::TakenFromHimAddedToHim;

#endif
