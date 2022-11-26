#include <iostream>
using namespace std;

//2022-11-24T16:55:00 http://cplusplus.com/doc/tutorial/dynamic/
//2022-11-24T17:11:00 ... 2022-11-24T17:21:00 Initialize new array

int main ()
{
	int * bibleBooksChapters = new (nothrow) int [5];
	if (bibleBooksChapters == nullptr) {
	  // error assigning memory. Take measures.
	  
	}
	bibleBooksChapters[0] = 50;
	bibleBooksChapters[1] = 40;
	bibleBooksChapters[2] = 27;
	bibleBooksChapters[3] = 36;
	bibleBooksChapters[4] = 34;
	int n, booksCount;
	double sum; 
	for 
	(
		n = 0, booksCount = 5, sum = 0; 
		n < booksCount;
		++n 
	)
	{
		sum += bibleBooksChapters[n];
	}
	cout << "Average: " << sum / booksCount << endl;
	cout << "Count: " << booksCount << endl;;
	cout << "Sum: " << sum << endl;
	delete bibleBooksChapters;	
	return 0;
}
