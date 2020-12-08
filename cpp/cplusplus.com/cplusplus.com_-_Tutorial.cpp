/*
	2019-03-14	http://www.cplusplus.com/files/tutorial.pdf
	2019-03-15	https://stackoverflow.com/questions/2204176/how-to-initialise-memory-with-new-operator-in-c
*/	
#include <iostream>
#include <sstream>
#include <string>
using namespace std;
const double PI = 22.0 / 7.0;

int* memoryAllocation(int);
void memoryHousekeeping(int *);
void profile(void);

int main(void)
{   
	//profile();
	int *pointer = memoryAllocation(12);
	memoryHousekeeping(pointer);
	return 0;
}

int* memoryAllocation(int count)
{ 											//1   2   3   4   5   6   7   8   9  10  11  12
	int *pointer = new (nothrow) int [count]{31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
	if (pointer == 0) 
	{ 
		cerr << "Error: memory could not be allocated";
		return pointer;
	};
	int daysInYear = 0;
	for (int index = 0; index < count; ++index)
	{
		daysInYear += pointer[index];
	}
	cout << daysInYear << endl;
	return pointer; 
}	

void memoryHousekeeping(int *pointer)
{
	delete [] pointer;
}	

void profile(void)
{   
	string answerAge;
	string answerName;

	string questionAge = "How old are you? ";
	string questionName = "What's your name? ";
	int yourAge;

	string greeting = "Hello, ";

	cout << "PI: " << PI << endl;
	cout << questionName;
	getline(cin, answerName);
	cout << greeting << answerName << endl;
	string mystr ("1204"); 

	cout << questionAge;
	getline(cin, answerAge);
	stringstream(answerAge) >> yourAge;
	cout << "You are " << yourAge 
		<< " year" << (yourAge <= 1 ? "" : "s" ) << " old " << endl;
	
	return;
}
