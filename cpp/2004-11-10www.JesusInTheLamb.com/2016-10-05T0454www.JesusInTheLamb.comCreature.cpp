/*
	2016-10-05T04:54:00	2016-10-05T0454www.JesusInTheLamb.comCreature.cpp
	2016-10-04	http://stackoverflow.com/questions/1549930/c-equivalent-of-java-tostring
*/

#include <cassert>
#include <string>

#include "2016-10-05T0437www.JesusInTheLamb.comCreature.hpp"

using namespace std;

// Creature constructor
Creature::Creature
(
	string	name
)
{
	SetCreature(name);
}

// Creature operator overloading

ostream& operator <<(ostream& outputStream, const Creature& creature)
{
	outputStream
		<< "name=" << creature.name
		<< " yearsLived=" << creature.yearsLived
		;
		
	return outputStream;
}		
 
// Creature member function
void Creature::SetCreature
(
	string	name
)
{
	assert(name.empty());
	
	this->name = name;
}

string Creature::getName()
{ 
	return name;	
}

int Creature::getYearsLived()
{
	return yearsLived;
}
	
void Creature::setName
(
	string	name
)
{
	assert(name.empty());
	
	this->name = name;
}

void Creature::setYearsLived
(
	int yearsLived
)
{
	assert(yearsLived < 0);
	
	this->yearsLived = yearsLived;
}

