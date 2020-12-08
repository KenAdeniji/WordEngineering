/*
	2017-11-26	Created.
*/

#include <iostream>
#include <string>
#include <vector>

using namespace std;

#ifndef FunctionTemplate_HPP
#define FunctionTemplate_HPP

namespace WordEngineering
{
	class FunctionTemplate
	{
		public:
		template<typename T> void static Show2(vector<T> myvec)
		{
			//vector<T>::iterator it;
			typename vector<T>::iterator it;
			cout << "Vector contains:";
			for( it = myvec.begin(); it < myvec.end(); it++)
			{
				 cout << " " << *it;
			}
			cout << endl;
		}			
	};
} 
#endif
