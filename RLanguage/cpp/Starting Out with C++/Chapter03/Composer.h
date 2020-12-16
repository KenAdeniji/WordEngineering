// compile with: /GR /EHsc
/*
	2015-03-10	Created.
*/

#include <iostream>
#include <fstream>
#include <string>
#include <vector>

#ifndef ComposerFilename
#define ComposerFilename "Composer.txt"
#endif

using namespace std;

namespace WordEngineering
{

	class Composer
	{
		protected:
			vector<string> composers;
			
		public:
			void dataEntry()
			{
				string name;
				while(true)
				{
					cout << "Enter composer: ";
					std::getline(std::cin,name);
					if (name.length() <= 0)
					{
						break;
					}	
					composers.push_back(name);
				}
			}
			
			void readFile()
			{
				string name = "";
				ifstream inputFile;
				inputFile.open(ComposerFilename);
				composers.erase(composers.begin(), composers.end());
				//composers.clear(); if (composers.empty())
				do {
					inputFile >> name;
					if (inputFile.eof())
					{
						break;
					}	
					composers.push_back(name);
				} while ( true );
				inputFile.close();
				for ( auto &i : composers ) {
					cout << i << std::endl;
				}
			}
			
			void writeFile()
			{
				ofstream outputFile;
				outputFile.open(ComposerFilename);
				for ( auto &i : composers ) {
					outputFile << i << std::endl;
				}
				outputFile.close();
			}
	} composer;
}
