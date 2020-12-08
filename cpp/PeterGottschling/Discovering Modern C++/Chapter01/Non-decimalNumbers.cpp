#include <iostream>

/*
https://github.com/lpvcpp/cpp_book/blob/master/Discovering%20Modern%20C%2B%2B%20-%20Peter%20Gottschling.pdf
*/

int main()
{   
	int octalNumber =042; //Integer literals starting with a zero are interpreted as octal numbers.
	std::cout 	<< "042: " << octalNumber << std::endl;
	int hexNumber = 0xfa;
	std::cout 	<< "0xfa: " << hexNumber << std::endl;
	int binaryNumber = 0b11111010; //int binaryNumber = 250
	std::cout 	<< "0b11111010: " << binaryNumber << std::endl;
	return 0;
}
	