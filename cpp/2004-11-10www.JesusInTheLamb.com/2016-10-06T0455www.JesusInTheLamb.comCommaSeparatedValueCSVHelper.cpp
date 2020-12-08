/*
	2016-10-06T04:55:00	2016-10-06T0455www.JesusInTheLamb.comCommaSeparatedValueCSVHelper.cpp
 	2016-10-06 http://stackoverflow.com/questions/5373107/how-to-implement-static-class-member-functions-in-cpp-file	
	2016-10-06T04:45:00 http://stackoverflow.com/questions/1120140/how-can-i-read-and-parse-csv-files-in-c
*/

#include <iostream>
#include <string>
#include <vector>

#include "2016-10-06T0455www.JesusInTheLamb.comCommaSeparatedValueCSVHelper.hpp"

using namespace std;


	void parseCSV(const string& csvSource, vector<vector<string> >& lines)
	{

	bool inQuote(false);
		bool newLine(false);
       string field;
       lines.clear();
       vector<string> line;

       string::const_iterator aChar = csvSource.begin();
       while (aChar != csvSource.end())
       {
          switch (*aChar)
          {
          case '"':
             newLine = false;
             inQuote = !inQuote;
             break;

          case ',':
             newLine = false;
             if (inQuote == true)
             {
                field += *aChar;
             }
             else
             {
                line.push_back(field);
                field.clear();
             }
             break;

          case '\n':
          case '\r':
             if (inQuote == true)
             {
                field += *aChar;
             }
             else
             {
                if (newLine == false)
                {
                   line.push_back(field);
                   lines.push_back(line);
                   field.clear();
                   line.clear();
                   newLine = true;
                }
             }
             break;

          default:
             newLine = false;
             field.push_back(*aChar);
             break;
          }

          aChar++;
       }

       if (field.size())
          line.push_back(field);

       if (line.size())
          lines.push_back(line);

}

