/*
	2022-12-10T19:34:00 Created.	http://greenteapress.com/thinkcpp/thinkCScpp.pdf
*/

#include <iostream>
#include <string>

#include <ctime>
#include <chrono>

using namespace std;

#ifndef StroustrupHisWord_HPP
#define StroustrupHisWord_HPP
 
class StroustrupHisWord
{
	private:
		std::string		commentary;	
		time_t			dated;
		long			hisWordID;
 		std::string		word;
		
	public:
		StroustrupHisWord() 
		{
			cout << "StroustrupHisWord constructor." << endl;
		}
	
		StroustrupHisWord
		(
			std::string		commentary,	
			std::string		word
		);

		friend ostream& operator <<(ostream& outputStream, const StroustrupHisWord& StroustrupHisWord);
	 
		void setStroustrupHisWord
		(
			std::string		commentary,	
			std::string		word
		);

		std::string		getCommentary();
		void			setCommentary(std::string);
		
		std::string		getWord();
		void			setWord(std::string);
};
 
#endif
