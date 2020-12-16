/*
	2020-04-29	Created. https://fbb-git.gitlab.io/cppannotations/cppannotations/html
	2019-12-30	https://medium.com/@tdeniffel/pragmatic-compiling-from-c-to-webassembly-a-guide-a496cc5954b8
	2016-10-04	http://stackoverflow.com/questions/1549930/c-equivalent-of-java-tostring
*/

#include <iostream>
#include <string>

using namespace std;

#ifndef GodTitle_HPP
#define GodTitle_HPP

class GodTitle
{
	private:				  			// In C++, all properties are private, by default
	string title;        			
	string commentary;     		
	string scriptureReference;		

	public:                     // member functions
		GodTitle(): title(""), commentary(""), scriptureReference("") {}
  
		GodTitle(string _title, string _commentary, string _scriptureReference): 
			title(_title), commentary(_commentary), scriptureReference(_scriptureReference) {}
  
		~GodTitle(void); 
		
		GodTitle( GodTitle& godTitle); // copy constructor
		
		void  setTitle(string  &title);
		void  setCommentary(string  &commentary);
		void  setScriptureReference(string  &scriptureReference);

		string  getTitle();
		string  getCommentary();
		string  getScriptureReference();
		
		friend ostream& operator <<(ostream& outputStream,  GodTitle& GodTitle);
		
		void setGodTitle
		(
			string  title,
			string  commentary,
			string  scriptureReference
		);
		
};
#endif
