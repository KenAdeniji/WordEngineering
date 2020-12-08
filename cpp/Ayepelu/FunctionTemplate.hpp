/*
	2017-11-27	Created.
	2017-11-27	http://stackoverflow.com/questions/5192874/question-about-vector-iterator-in-template-functions
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
		template<typename T> void static Render(vector<T> myvec)
		{
			typename vector<T>::iterator it;
			cout << "Vector contains:" << endl;
			for( it = myvec.begin(); it < myvec.end(); it++)
			{
				 cout << " " << *it << endl;
			}
			cout << endl;
		}
		static void Dump(string);
	};
} 
#endif
