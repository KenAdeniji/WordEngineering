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
		string alias,
		string commentary,
		string scriptureReference
	)
	{
		SetLight
		(
			alias,
			commentary,
			scriptureReference
		);
	}
	 
	// Light member function
	void Light::SetLight
	(
		string localAlias,
		string localCommentary,
		string localScriptureReference
	)
	{
		assert(sizeof(localAlias) != 0); 
		alias.assign(localAlias);
		commentary.assign(localCommentary);	
		scriptureReference.assign(localScriptureReference);	
	}

	string Light::GetAlias()
	{ 
		string localAlias;
		localAlias.assign(alias);	
		return localAlias;
	}
	
	void Light::SetAlias
	(
		string localAlias
	)
	{
		assert(sizeof(localAlias) != 0); 
		alias.assign(localAlias);
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
