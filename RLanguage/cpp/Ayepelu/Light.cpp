/*
	2017-11-26	Created.
	2017-11-28	Change attribute name from named to named.
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
		string named,
		string commentary,
		string scriptureReference
	)
	{
		SetLight
		(
			named,
			commentary,
			scriptureReference
		);
	}
	 
	// Light member function
	void Light::SetLight
	(
		string localNamed,
		string localCommentary,
		string localScriptureReference
	)
	{
		assert(sizeof(localNamed) != 0); 
		named.assign(localNamed);
		commentary.assign(localCommentary);	
		scriptureReference.assign(localScriptureReference);	
	}

	string Light::GetNamed()
	{ 
		string localNamed;
		localNamed.assign(named);	
		return localNamed;
	}
	
	void Light::SetNamed
	(
		string localNamed
	)
	{
		assert(sizeof(localNamed) != 0); 
		named.assign(localNamed);
	}

	void Light::SetCommentary
	(
		string localCommentary
	)
	{
		commentary.assign(localCommentary);
	}
	
	void Light::SetScriptureReference
	(
		string localScriptureReference
	)
	{
		scriptureReference.assign(localScriptureReference);
	}
}
