/*
	2016-10-05T22:28:00	2016-10-05T2228www.JesusInTheLamb.comUnicodeHelper.cpp
	2016-10-04	http://stackoverflow.com/questions/313970/how-to-convert-stdstring-to-lower-case
	2016-10-06T02:32:00 http://stackoverflow.com/questions/19300449/how-to-call-static-method-from-another-class
*/

#include <iostream>
#include <string>

#include "2016-10-05T2228www.JesusInTheLamb.comUnicodeHelper.hpp"

using namespace std;

namespace InformationInTransit
{
	string UnicodeHelper::toupper(string sourceString)
	{
		string destinationString = "";
			
		// Allocate the destination space
		destinationString.resize(sourceString.size());

		// Convert the source string to upper case
		// storing the result in destination string
		std::transform
		(	
			sourceString.begin(),
			sourceString.end(),
			destinationString.begin(),
			::toupper
		);

		return destinationString;
	}	
}
