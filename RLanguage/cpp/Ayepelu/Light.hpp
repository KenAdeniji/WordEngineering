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
			string named;
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

			string GetNamed();
			
			void SetNamed(string);
			void SetCommentary(string);
			void SetScriptureReference(string);
			
			// operator overloading
			friend ostream& operator <<(ostream& outputStream, const Light& light);
			
			// operator overloading
			friend ostream& operator <<(ostream& outputStream, const Light& light){
				outputStream
					<< "named=" << light.named
					<< " commentary=" << light.commentary
					<< " scriptureReference=" << light.scriptureReference
					;
				return outputStream;
			}			
	};
} 
#endif
