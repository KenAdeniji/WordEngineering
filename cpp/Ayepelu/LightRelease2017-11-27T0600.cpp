/*
	2017-11-26	Created.
*/

#include <cassert>
#include <string>

#include "Light.hpp"

using namespace std;

namespace WordEngineering
{
	// Light constructor
	Light::Light
	(
		string naturalPrimaryKey,
		string commentary,
		string scriptureReference
	)
	{
		SetLight
		(
			naturalPrimaryKey,
			commentary,
			scriptureReference
		);
	}
	 
	// Light member function
	void Light::SetLight
	(
		string localNaturalPrimaryKey,
		string localCommentary,
		string localScriptureReference
	)
	{
		assert(sizeof(localNaturalPrimaryKey) != 0); 
		naturalPrimaryKey.assign(localNaturalPrimaryKey);
		commentary.assign(localCommentary);	
		scriptureReference.assign(localScriptureReference);	
	}

	string Light::GetNaturalPrimaryKey()
	{ 
		string localNaturalPrimaryKey;
		localNaturalPrimaryKey.assign(naturalPrimaryKey);	
		return localNaturalPrimaryKey;
	}
}
