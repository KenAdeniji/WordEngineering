/*
	2016-10-06T13:39:00	2016-10-061339www.JesusInTheLamb.comLimitsHelper.hpp
	2016-10-05 Stephen Prata C++ Primer Plus. Alexander Book Company. Address: 50 2nd Street, San Francisco, CA 94105 Phone:(415) 495-2992.
	2016-10-06 http://stackoverflow.com/questions/5373107/how-to-implement-static-class-member-functions-in-cpp-file

		public:
			//static void accumulate(<vector>LimitsHelper& resultList);

	2016-10-06T21:07:00	c header file, types.h
	
*/

//#include <climits> //or #include "limits.h"
#include <iostream>
#include <string>
#include <vector>

using namespace std;

#ifndef LimitsHelper_HPP
#define LimitsHelper_HPP

namespace InformationInTransit
{
	class LimitsHelper
	{
		private:
			//static vector<string> dataTypes;
			
			string name;
			double min;
			double max;
			double size;
			
		public:
			LimitsHelper() {
				cout << "LimitsHelper constructor." << endl;
			}
		
			LimitsHelper
			(
				string	name
			);		

			static int dump();
	}	
} 

#endif
