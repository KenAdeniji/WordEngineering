/*
	2017-03-28	http://www.stroustrup.com/eh_brief.pdf
		ResourcesAndResourceLeaks.cpp created.	
		
	2017-03-29
		E:\Program Files (x86)\Microsoft Visual Studio\2017\Community\VC\Auxiliary\Build\vcvarsall.bat
		cl /GR /EHsc ResourcesAndResourceLeaks.cpp
		
		http://stackoverflow.com/questions/18098564/reading-lines-using-fscanf	
*/
#include <iostream>
#include <string>

using namespace std;

#define LINE_MAX 1000

class File_ptr {
    FILE* p;
public:
	File_ptr(const char* n, const char* a) { p = fopen(n,a); }
	// suitable copy operations
	~File_ptr() { if (p) fclose(p); }

	operator FILE*() { return p; }   // extract pointer for use
};

void use_file(const char* fn)
{
	File_ptr file(fn,"r");

	// use f
	char buf[LINE_MAX];
	while (fgets(buf, sizeof buf, file) != NULL) {
		// process line here
		cout << buf;
	}
	
	fclose(file);
}

int main()
{
	use_file("ResourcesAndResourceLeaks.cpp");		
}
