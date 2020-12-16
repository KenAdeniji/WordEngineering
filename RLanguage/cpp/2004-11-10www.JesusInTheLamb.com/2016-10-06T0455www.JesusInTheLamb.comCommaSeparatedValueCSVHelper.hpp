/*
	2016-10-06T04:45:00	2016-10-06T0455www.JesusInTheLamb.comCommaSeparatedValueCSVHelper.hpp
	2016-10-06 http://stackoverflow.com/questions/5373107/how-to-implement-static-class-member-functions-in-cpp-file
	2016-10-06T04:45:00 http://stackoverflow.com/questions/1120140/how-can-i-read-and-parse-csv-files-in-c
*/

#include <iostream>
#include <string>
#include <vector>

using namespace std;

#ifndef CommaSeparatedValueCSVHelper_HPP
#define CommaSeparatedValueCSVHelper_HPP

	void parseCSV(const string& csvSource, vector<vector<string> >& lines);

#endif
