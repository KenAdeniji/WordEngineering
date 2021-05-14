/*
	https://books.google.com/books?id=yTVlLrTdf98C&pg=PT31&lpg=PT31&dq=Stephen+Prata+College+of+Marin+in+Kentfield,+California&source=bl&ots=DRq5Ih5AsB&sig=ACfU3U1yjiZOY5U1drvuvdx6aBLP2choRA&hl=en&sa=X&ved=2ahUKEwjFjObu6MDwAhUOqJ4KHWP0D1AQ6AEwB3oECAUQAw#v=onepage&q=Stephen%20Prata%20College%20of%20Marin%20in%20Kentfield%2C%20California&f=false
	2021-05-11T15:55:00	Created.	
		cl /GR /EHsc ArrayInitialization.cpp
*/
#include <iostream>
#include <cstring>
using namespace std;

int main()
{
	int chaptersInThePentateuch[] = {50, 40, 27, 36, 34};
	int pentateuchLength = (sizeof chaptersInThePentateuch) /
		(sizeof chaptersInThePentateuch[0]);
	int pentateuchTotal = 0;	
	for
	(
		int pentateuchIndex = 0;
			pentateuchIndex < pentateuchLength;
			++pentateuchIndex
	)
	{
		cout << "[" << pentateuchIndex << "]: " <<
			chaptersInThePentateuch[pentateuchIndex] << endl;
		pentateuchTotal += 	chaptersInThePentateuch[pentateuchIndex];
	}
	cout << "Total: " << pentateuchTotal;	
}
