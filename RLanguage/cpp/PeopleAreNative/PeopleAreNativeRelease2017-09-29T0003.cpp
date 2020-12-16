#include <iostream>

#include "DateTimeHandler.hpp"

using namespace std;

using namespace PeopleAreNative;

/*
	vcvars32.bat
	2017-09-27	cl PeopleAreNative.cpp DateTimeHandler.cpp
	2017-09-27	http://stackoverflow.com/questions/14218894/number-of-days-between-two-dates-c
	2017-09-28	http://msdn.microsoft.com/en-us/library/5cb46ksf.aspx?f=255&MSPPError=-2147217396
	2017-09-28	http://albertech.blogspot.com/2014/12/how-to-compile-dll-using-clexe.html
	2017-09-28	cl.exe /D_USRDLL /D_WINDLL DateTimeHandler.cpp PeopleAreNative.cpp /MT /link /DLL /OUT:PeopleAreNative.dll
	2017-09-28	https://drthitirat.wordpress.com/2013/05/30/combine-gui-of-c-with-c-codes/
	2017-09-28	http://stackoverflow.com/questions/3677157/error-c2375-redefinition-different-linkage
*/

int main(){
	int days = call_DateTimeHandler_dateDifference((int)2012, (int)1, (int)24, (int)2013, (int)1, (int)8);
	cout << "Days: " << days;
}

