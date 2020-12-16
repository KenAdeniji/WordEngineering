/*
2019-05-07	Created.	https://isocpp.org/wiki/faq/big-picture
2019-05-08	https://www.tutorialspoint.com/cplusplus/cpp_interfaces.htm
*/

#include <iostream>
#include <string>

using namespace std;

#ifndef IAnimal_HPP
#define IAnimal_HPP
 
class IAnimal {  // common animal interface
public:
	virtual std::string sound() = 0;
};
 
#endif

