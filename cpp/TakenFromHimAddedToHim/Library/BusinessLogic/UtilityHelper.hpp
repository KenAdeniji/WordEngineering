/*
	2023-11-02T04:50:00	Created.
	2016-02-11	http://www.learncpp.com/cpp-tutorial/89-class-code-and-header-files/			
*/
#include <regex>
#include <String>

using namespace std;

#ifndef WordEngineering_UtilityHelper_HPP
#define WordEngineering_UtilityHelper_HPP

namespace InformationInTransit
{
	namespace BusinessLogic
	{
		class UtilityHelper
		{
			public:
				void static copySample(char *, char *);
				bool static isNumber(char *);
		};
	}
}	

#endif
