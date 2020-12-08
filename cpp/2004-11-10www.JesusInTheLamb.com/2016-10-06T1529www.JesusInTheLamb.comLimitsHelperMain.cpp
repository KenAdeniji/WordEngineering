/*
	2016-10-06T15:29:00 2016-10-06T1529www.JesusInTheLamb.comLimitsHelperMain.cpp
	2016-10-05 Stephen Prata C++ Primer Plus. Alexander Book Company. Address: 50 2nd Street, San Francisco, CA 94105 Phone:(415) 495-2992.
	2016-10-06T12:06:00	http://stackoverflow.com/questions/11310898/how-do-i-get-the-type-of-a-variable	
*/

#include <climits> //or #include "limits.h"
#include <iostream>
#include <vector>

//#include "2016-10-061339www.JesusInTheLamb.comLimitsHelper.hpp"

using namespace std;
//using namespace InformationInTransit;

void main(int argc, char *argv[])
{
/*
	cout << argc << endl;
	//cout << LimitsHelper::dump() << endl;
	
	cout 
		<< "sizeof int " << sizeof int
		<< endl;
*/

	int k = -2;
	
	cout << typeid(k).name() << endl;

	int typeValue = 2;
	
	cout 
		<< "typeValue: " << typeValue
		<< " typeName: " << typeid(typeValue).name()
		<< endl;
}
