#include <vector>

#include "HisWord.hpp"

using namespace std;

// HisWord constructor
HisWord::HisWord
(
	int sequenceOrderID,
	std::time_t dated,
	char Word[2000]
)
{
	SetHisWord(sequenceOrderID, dated, Word);
}
 
// HisWord member function
void HisWord::SetHisWord
(
	int localSequenceOrderID,
	std::time_t localDated,
	char localWord[2000]
)
{
	sequenceOrderID = localSequenceOrderID;
	dated = localDated;
	strcpy(Word, localWord);
}

/*
void HisWord::DumpHisWord(vector<HisWord> hisWords)
{
	for (int i = 0; i < hisWords.size(); ++i)
	{
		cout << hisWords[i] << '\n';
	}	
}
*/

int HisWord::getSequenceOrderID() { return sequenceOrderID; }

char *HisWord::getWord()
{ 
	//char *str = (char* ) malloc(sizeof(char) * 2000); // free(str);
	char *str = new char[2000];
	str = Word;
	return str;	
}
