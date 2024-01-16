/*
	2024-01-15T07:42:00 http://oualline.com/books.free/teach/slides/ch05.pdf
*/
#include <iostream>
#include <string>

using namespace std;

int main(int argc, char *argv[])
{
	cout << "Please enter a name? ";	
	std::string name; // The name of a person
	std::getline(std::cin, name);
	cout << "A name is: " << name;
}
