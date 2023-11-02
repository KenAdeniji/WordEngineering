#include <iostream>

#include "Library/ProcessLogic/TakenFromHimAddedToHimMain.hpp"

using namespace std;

int main( int argc, char *argv[] )
{
	cout << "Arguments count:" << argc << endl;
    for ( int index = 1; index < argc; index++ )
    {
		AlphabetSequence* alphabetSequence = new AlphabetSequence(argv[index]);
		cout << "[" << index << " of " << argc << "]: " << alphabetSequence->Word << endl;
		//free(alphabetSequence->Word); 
		delete alphabetSequence;
    }
}
