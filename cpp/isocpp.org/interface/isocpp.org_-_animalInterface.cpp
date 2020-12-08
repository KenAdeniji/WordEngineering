/*
2019-05-07	Created.	https://isocpp.org/wiki/faq/big-picture
2019-05-08	https://www.tutorialspoint.com/cplusplus/cpp_interfaces.htm
*/

#include <iostream>
#include <string>

#include "isocpp.org_-_animalInterface.hpp"
#include "isocpp.org_-_dog.hpp"

using namespace std;

void f(IAnimal& animal);
void g();

void f(IAnimal& animal)  // use animal
{
	cout << animal.sound();
}

void g()
{
	Dog* dalmatian = new Dog("Dalmatian");
	
	int animalType = -1;
	
	cout << "0 for Dog" << endl;
	
    cin >> animalType;

	switch(animalType)
	{
		case 0:
			f(*dalmatian);
			break;
	}		
}

int main(void) 
{
	g();
}
