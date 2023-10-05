/*
	2019-12-30	https://medium.com/@tdeniffel/pragmatic-compiling-from-c-to-webassembly-a-guide-a496cc5954b8
	2016-10-04	http://stackoverflow.com/questions/1549930/c-equivalent-of-java-tostring
*/

//#include <iostream>
//#include <string>

//using namespace std;

#ifndef BibleBook_HPP
#define BibleBook_HPP
 
class BibleBook
{
	public:
		int		id;
		char*	title;
		int		chapters;
 
	public:
		BibleBook() 
		{
		};
	
		BibleBook
		(
			int		id,	
			char*	title,
			int		chapters
		);

		BibleBook(const BibleBook& bibleBook); // copy constructor
		
		//friend ostream& operator <<(ostream& outputStream, const BibleBook& BibleBook);
	 
		~BibleBook(void) 
		{ 
			delete[] title;
		};
	 
		void setBibleBook
		(
			int		id,
			char*	title,
			int		chapters
		);

		int		getID() const;
		void	setID(int id);

		char*	getTitle() const;
		void	setTitle(char* title);

		int		getChapters() const;
		void	setChapters(int chapters);
};
 
#endif
