/*
	2023-11-02T04:50:00	Created.
	2016-02-11	http://www.learncpp.com/cpp-tutorial/89-class-code-and-header-files/
	2023-11-02T04:50:00	http://stackoverflow.com/questions/4654636/how-to-determine-if-a-string-is-a-number-with-c	
*/
#include <regex>
//#include <String>
#include <sstream>

#include "UtilityHelper.hpp"

using namespace std;

namespace InformationInTransit
{
	namespace BusinessLogic
	{
		void UtilityHelper::copySample
		(
			char *source,
			char *target
		)
		{
			int destination_size = strlen(source);
			strncpy(target, source, destination_size);
			target[destination_size] = '\0';
		}
		
		bool UtilityHelper::isNumber
		(
			char *x
		)
		{
			char *p;
			long converted = strtol(x, &p, 10);
			if (*p) {
				// conversion failed because the input wasn't a number
				return false;
			}
			else {
				// use converted
				return true;
			}			
		}
	}
}	
