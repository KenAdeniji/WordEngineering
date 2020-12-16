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
			string naturalPrimaryKey;
			string commentary;
			string scriptureReference;
	 
		public:
			Light
			(
				string naturalPrimaryKey,
				string commentary,
				string scriptureReference
			);
		 
			void SetLight
			(
				string naturalPrimaryKey,
				string commentary,
				string scriptureReference
			);

			string GetNaturalPrimaryKey();
			
			// operator overloading
			friend ostream& operator <<(ostream& outputStream, const Light& light);
			
			// operator overloading
			friend ostream& operator <<(ostream& outputStream, const Light& light){
				outputStream
					<< "naturalPrimaryKey=" << light.naturalPrimaryKey
					<< " commentary=" << light.commentary
					<< " scriptureReference=" << light.scriptureReference
					;
				return outputStream;
			}			
	};
} 
#endif
