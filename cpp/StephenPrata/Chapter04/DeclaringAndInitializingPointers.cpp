/*
	https://books.google.com/books?id=yTVlLrTdf98C&pg=PT31&lpg=PT31&dq=Stephen+Prata+College+of+Marin+in+Kentfield,+California&source=bl&ots=DRq5Ih5AsB&sig=ACfU3U1yjiZOY5U1drvuvdx6aBLP2choRA&hl=en&sa=X&ved=2ahUKEwjFjObu6MDwAhUOqJ4KHWP0D1AQ6AEwB3oECAUQAw#v=onepage&q=Stephen%20Prata%20College%20of%20Marin%20in%20Kentfield%2C%20California&f=false
	2021-05-10T21:33:00	Created.
		cl /GR /EHsc DeclaringAndInitializingPointers.cpp
*/
#include <iostream>
using namespace std;

int main()
{
	int higgens = 5;
	int *pi = &higgens;
	
	cout 	<< "Value of higgens = " << higgens
			<< " Address of higgens = " << &higgens << endl;
	cout 	<< "Value of *pi = " << *pi
			<< " Value of pi = " << pi << endl;
}
			