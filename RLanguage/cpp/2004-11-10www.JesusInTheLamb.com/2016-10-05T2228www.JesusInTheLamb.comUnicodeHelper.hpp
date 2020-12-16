/*
	2016-10-05T21:28:00	2016-10-05T2228www.JesusInTheLamb.comUnicodeHelper.hpp
	2016-10-06T02:32:00 http://stackoverflow.com/questions/19300449/how-to-call-static-method-from-another-class
*/

#include <algorithm>
#include <iostream>
#include <string>

using namespace std;

#ifndef UnicodeHelper_HPP
#define UnicodeHelper_HPP

namespace InformationInTransit
{
	class UnicodeHelper
	{
		public:
			static UnicodeHelper::string toupper(string sourceString);
	};
} 
#endif
