/*
2019-05-07	Created.	https://isocpp.org/wiki/faq/big-picture
2019-05-08	https://www.tutorialspoint.com/cplusplus/cpp_interfaces.htm
*/

#include <iostream>
#include <string>

using namespace std;

#include "isocpp.org_-_animal.hpp"

void f(IAnimal& animal);
void g();

void f(IAnimal& animal)  // use animal
{
	animal.sound();
}

void g()
{
	Dog dalmatian = new Dog("Dalmatian");
	
	int animalType = -1;
    cin >> animalType;

	switch(animalType)
	{
		case 0:
			f(dalmatian);
			break;
	}		
}

int main(void) 
{
	g();
}
