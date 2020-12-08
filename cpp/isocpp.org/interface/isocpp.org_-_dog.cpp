#include <cassert>

#include "isocpp.org_-_animalInterface.hpp"
#include "isocpp.org_-_dog.hpp"

// Dog constructor
Dog::Dog
(
	string	breed
)
{
	SetDog(breed);
}

// Dog operator overloading

ostream& operator <<(ostream& outputStream, const Dog& Dog)
{
	outputStream
		<< "breed=" << Dog.breed
		//<< " yearsLived=" << Dog.yearsLived
		;
		
	return outputStream;
}		
 
// Dog member function
void Dog::SetDog
(
	string	breed
)
{
//	assert(breed.empty());
	
	this->breed = breed;
}

string Dog::getBreed()
{ 
	return breed;	
}

void Dog::setBreed
(
	string	breed
)
{
	assert(breed.empty());
	
	this->breed = breed;
}

string Dog::sound()
{ 
	return "bark";	
}
