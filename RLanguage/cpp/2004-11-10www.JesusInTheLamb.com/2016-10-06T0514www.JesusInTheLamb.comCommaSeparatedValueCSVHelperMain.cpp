/*
	2016-10-06T05:14:00	2016-10-06T0514www.JesusInTheLamb.comCommaSeparatedValueCSVHelperMain.cpp
 	2016-10-06 http://stackoverflow.com/questions/5373107/how-to-implement-static-class-member-functions-in-cpp-file
	2016-10-06T04:45:00 http://stackoverflow.com/questions/1120140/how-can-i-read-and-parse-csv-files-in-c
	
	2016-10-06T11:30:00 Copy the Comma Separated Value (CSV) file, Word.csv into the E:\WordEngineering\C++\2004-11-10www.JesusInTheLamb.com directory.
		This file, Word.csv, was generated on 2016-09-13.
		
	2016-10-06T11:55:00	http://stackoverflow.com/questions/2602013/read-whole-ascii-file-into-c-stdstring	
*/

#include <fstream>
#include <iostream>
#include <streambuf>
#include <string>
#include <vector>

#include "2016-10-06T0455www.JesusInTheLamb.comCommaSeparatedValueCSVHelper.hpp"
#include "2016-10-06T1211www.JesusInTheLamb.comFileHelper.hpp"

using namespace std;

void parseCSVStub(const string& csvSource, vector<vector<string> >& lines)
{
	parseCSV(csvSource, lines);
}	

	string get_file_string(string path_to_file)
	{
		std::ifstream ifs(path_to_file);
		return string((std::istreambuf_iterator<char>(ifs)),
            (std::istreambuf_iterator<char>()));
	}	

void main(int argc, char *argv[])
{
	string csvSource;
	std::vector<vector<string>>	lines;
	
	string path_to_file = "Word.csv";
	
	csvSource = get_file_string(path_to_file);
	
	cout << csvSource << endl;//you can do anything with the string!!!
	
	//parseCSVStub(csvSource, lines);
	
}
