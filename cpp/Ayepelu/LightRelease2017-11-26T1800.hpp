/*
	2017-11-26	Created.
*/

#include <iostream>
#include <string>

using namespace std;

#ifndef Light_HPP
#define Light_HPP
 
class Light
{
	private:
		string naturalPrimaryKey;
 
	public:
		Light
		(
			string naturalPrimaryKey
		);
	 
		void SetLight
		(
			string naturalPrimaryKey
		);

		string GetNaturalPrimaryKey();
		
		// operator overloading
		friend ostream& operator <<(ostream& outputStream, const Light& light);
		
		// operator overloading
		friend ostream& operator <<(ostream& outputStream, const Light& light){
			outputStream
				<< "naturalPrimaryKey=" << light.naturalPrimaryKey
				;
			return outputStream;
		}			
};
 
#endif
