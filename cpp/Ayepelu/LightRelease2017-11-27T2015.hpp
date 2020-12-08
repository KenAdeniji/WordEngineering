/*
	2017-11-26	Created.
*/

#include <iostream>
#include <string>

using namespace std;

#ifndef Light_HPP
#define Light_HPP

namespace WordEngineering
{
	class Light
	{
		private:
			string alias;
			string commentary;
			string scriptureReference;
	 
		public:
			Light
			(
				string,
				string,
				string
			);
		 
			void SetLight
			(
				string,
				string,
				string
			);

			string GetAlias();
			
			void SetAlias(string);
			void SetCommentary(string);
			void SetScriptureReference(string);
			
			// operator overloading
			friend ostream& operator <<(ostream& outputStream, const Light& light);
			
			// operator overloading
			friend ostream& operator <<(ostream& outputStream, const Light& light){
				outputStream
					<< "alias=" << light.alias
					<< " commentary=" << light.commentary
					<< " scriptureReference=" << light.scriptureReference
					;
				return outputStream;
			}			
	};
} 
#endif
