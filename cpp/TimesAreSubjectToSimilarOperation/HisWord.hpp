/*
	2016-02-11	Created.	http://stackoverflow.com/questions/12346260/c-date-and-time
	2016-02-11	http://www.learncpp.com/cpp-tutorial/89-class-code-and-header-files/			
*/
#include <ctime>
#include <iostream>
#include <iomanip>
#include <vector>

#ifndef HisWord_HPP
#define HisWord_HPP
 
class HisWord
{
	private:
		int sequenceOrderID;
		std::time_t dated;
		char Word[2000];
 
	public:
		HisWord
		(
			int sequenceOrderID,
			std::time_t dated,
			char Word[2000]
		);
	 
		void SetHisWord
		(
			int sequenceOrderID,
			std::time_t dated,
			char Word[2000]
		);

		//void DumpHisWord(vector<HisWord> hisWords);
		
		int getSequenceOrderID();
		char* getWord();
};
 
#endif
