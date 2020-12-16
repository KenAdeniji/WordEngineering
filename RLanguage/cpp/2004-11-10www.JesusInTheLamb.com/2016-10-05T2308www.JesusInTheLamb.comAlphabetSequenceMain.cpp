/*
	2016-10-05T2308www.JesusInTheLamb.comAlphabetSequenceMain.cpp
	2016-10-05T06:55:00 http://stackoverflow.com/questions/12248703/creating-an-instance-of-class
*/

#include <iostream>

#include "2016-10-05T2302www.JesusInTheLamb.comAlphabetSequenceMain.hpp"

using namespace std;
using namespace InformationInTransit;

void stub(int argc, char *argv[]);

void stub(int argc, char *argv[])
{
	for(int index = 1; index < argc; index++)
	{
		string currentString = "";
		currentString = argv[index];
		
		//cout << argv[index] << currentString;
		
		AlphabetSequence* alphabetSequence = new AlphabetSequence();
	
		alphabetSequence->setWord(currentString);
		
		//alphabetSequence->word = currentString;
		
		long alphabetSequenceIndex = alphabetSequence->getAlphabetSequenceIndex();
		cout 
			<< 	*alphabetSequence
			<< 	endl;
		cout 
			<< 	"alphabetSequenceIndex: "
			<<	alphabetSequenceIndex
			<< 	endl;
		
		delete alphabetSequence;	
	}
}
	
void main(int argc, char *argv[])
{
	stub(argc, argv);
}
