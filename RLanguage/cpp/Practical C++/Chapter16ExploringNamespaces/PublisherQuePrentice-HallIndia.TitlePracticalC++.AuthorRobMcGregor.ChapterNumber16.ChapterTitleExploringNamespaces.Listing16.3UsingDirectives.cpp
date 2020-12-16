#include <algorithm>
#include <iostream>
#include <string>

using namespace std;
/*
	2016-10-04 	cl /clr PublisherQuePrentice-HallIndia.TitlePracticalC++.AuthorRobMcGregor.ChapterNumber16.ChapterTitleExploringNamespaces.Listing16.3UsingDirectives.cpp
	2016-10-04	http://stackoverflow.com/questions/313970/how-to-convert-stdstring-to-lower-case
*/

// Namespace declarations
namespace informationInTransit
{
	long alphabetSequenceIndex(std::string word);
	long alphabetSequenceIndex(std::string word)
	{
		long alphabetSequence = 0;

		for (unsigned int i = 0; i < word.size(); i++) 
		{
			if (word[i] >= 65 && word[i] <= 90)
			{	
				alphabetSequence += word[i] - 64;
			}	
		}
		
		return alphabetSequence;
		
	}	
}
	
void main(int argc, char *argv[])
{
	using namespace informationInTransit;
	
	std::string sourceString;
	std::string destinationString;
	
	for (int index = 1; index < argc; ++index)
	{
		sourceString = argv[index];
		
		// Allocate the destination space
		destinationString.resize(sourceString.size());

		// Convert the source string to upper case
		// storing the result in destination string
		std::transform
		(	
			sourceString.begin(),
			sourceString.end(),
			destinationString.begin(),
			::toupper
		);

		// Output the result of the conversion
		std::cout 
			<< sourceString
            << ": "
			<< informationInTransit::alphabetSequenceIndex(destinationString)
            << std::endl;	
	}
}
