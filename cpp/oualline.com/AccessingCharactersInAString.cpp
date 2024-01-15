/*
	2024-01-14T09:05:00 http://oualline.com/books.free/teach/slides/ch05.pdf
	2024-01-14T09:06:00	String interpolation
		http://stackoverflow.com/questions/37956090/how-to-construct-a-stdstring-with-embedded-values-i-e-string-interpolation
		string s = std::format("{1} to {0}", "a", "b");
*/
#include <iostream>
#include <string>

using namespace std;

int main(int argc, char *argv[])
{
	string stringFormat;
	for(int argcIndex = 1; argcIndex <= argc; ++argcIndex)
	{	
		for
		(
			int positionIndex = 0,
				positionCount = strlen(argv[argcIndex])                                          
				;
			positionIndex < positionCount;
			++positionIndex
		)
		{	
			cout 
				<< 	"Argument index: [" << argcIndex << " of " << argc - 1 << "] "
				<< 	"Character index: [" << positionIndex << "] "
				<< 	"String array letter: " << argv[argcIndex][positionIndex] 
				<< 	" String.at: " << string( argv[argcIndex] ).at(positionIndex)
				<<	endl
			;	
			
		}	
	}	
}
