/*
	2016-10-05T21:05:00	2016-10-05T2105www.JesusInTheLamb.comAlphabetSequence.hpp
	2016-10-04	http://stackoverflow.com/questions/1549930/c-equivalent-of-java-tostring
	
	2016-10-05T21:21:00	2016-10-05T2105www.JesusInTheLamb.comAlphabetSequence.hpp
		void	setAlphabetSequenceIndex(string word);
		void	setAlphabetSequenceIndex(unsigned long alphabetSequenceIndex);
		
	2016-10-05T21:37:00	2016-10-05T2105www.JesusInTheLamb.comAlphabetSequence.hpp		
		AlphabetSequence(unsigned long alphabetSequenceIndex);
*/

#include <cassert>
#include <iostream>
#include <string>

using namespace std;

#ifndef AlphabetSequence_HPP
#define AlphabetSequence_HPP

namespace InformationInTransit
{
	class AlphabetSequence
	{
		public:
			string	word;
	 
		public:
			AlphabetSequence() 
			{
				cout << "AlphabetSequence constructor." << endl;
			};
		
			AlphabetSequence
			(
				string	word
			);

			AlphabetSequence
			(
				unsigned long long word
			);
			
			friend ostream& operator <<(ostream& outputStream, const AlphabetSequence& alphabetSequence);
		 
			void setAlphabetSequence
			(
				string	word
			);

			long getAlphabetSequenceIndex()
			{
				long alphabetSequenceIndex = 0;

				string uppercaseWord = UnicodeHelper::toupper(word);
				
				for 
				(
					unsigned int index = 0, size = word.size(); 
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

			string getWord()
			{ 
				return word;
			}

			void setWord
			(
				string	word
			)
			{
				//assert(word.empty());
				this->word = word;
			}

	};
} 
#endif
