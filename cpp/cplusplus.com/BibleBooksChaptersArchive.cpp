#include <iostream>
using namespace std;

//2022-11-24T15:22:00 http://cplusplus.com/doc/tutorial/arrays

int bibleBooksChapters [] = {50, 40, 27, 36, 34};
int n, booksCount;
double sum; 

int main ()
{
	for 
	(
		n = 0, booksCount = sizeof(bibleBooksChapters) / sizeof(int), sum = 0; 
		n < booksCount;
		++n 
	)
	{
		sum += bibleBooksChapters[n];
	}
	cout << "Average: " << sum / booksCount << endl;
	cout << "Count: " << booksCount << endl;;
	cout << "Sum: " << sum << endl;	
	return 0;
}
