#include <iostream>

int main()
{
	int x = 25;
	int *ptr;
	
	ptr = &x; // Store the address of x in pointer.
	std::cout << "The value in x is " << x << std::endl;
	std::cout << "The address of x is " << x << std::endl;
	return 0;
}
