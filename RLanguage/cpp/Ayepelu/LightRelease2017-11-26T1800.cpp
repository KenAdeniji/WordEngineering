/*
	2017-11-26	Created.
*/

#include <cassert>
#include <string>

#include "Light.hpp"

using namespace std;

// Light constructor
Light::Light
(
	string naturalPrimaryKey
)
{
	SetLight(naturalPrimaryKey);
}
 
// Light member function
void Light::SetLight
(
	string localNaturalPrimaryKey
)
{
	assert(sizeof(localNaturalPrimaryKey) != 0); 
	naturalPrimaryKey.assign(localNaturalPrimaryKey);	
}

string Light::GetNaturalPrimaryKey()
{ 
	string localNaturalPrimaryKey;
	localNaturalPrimaryKey.assign(naturalPrimaryKey);	
	return localNaturalPrimaryKey;
}
