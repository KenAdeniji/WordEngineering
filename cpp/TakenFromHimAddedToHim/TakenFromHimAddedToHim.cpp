#include <iostream>

#include "Library/BusinessLogic/TakenFromHimAddedToHimMain.hpp"

using namespace std;

using namespace InformationInTransit::BusinessLogic;

int main( int argc, char *argv[] )
{
	cout << "Arguments count:" << argc << endl;
    for ( int index = 1; index < argc; index++ )
    {
		AlphabetSequence* alphabetSequence = new AlphabetSequence(argv[index]);
		cout << "[" << index << " of " << argc << "]: " 
			<< " Word: " << alphabetSequence->getWord() << " "
			<< " Index: " << alphabetSequence->getIndex()
			<< endl;
		//free(alphabetSequence->Word); 
		delete alphabetSequence;
    }
}
