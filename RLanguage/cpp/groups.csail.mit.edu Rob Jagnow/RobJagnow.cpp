// compile with: /GR /EHsc
/*
	2015-08-09	Created.	groups.csail.mit.edu/graphics/classes/6.837/F03/lectures/cpp_tutorial.ppt
*/

#include <iostream>

using namespace std;

int addPassByReference(int*, int*);
int	addPassByReferenceAlternateNotation(int&, int&);
int addPassByValue(int, int);
void arrayHeapAllocation(void);
void arrayStackAllocation(void);
void pointer(void);
void strings(void);

int main()
{
	pointer();
	arrayStackAllocation();
	strings();
	int a = 3, b = 5, sum;
	sum = addPassByValue(a, b);
	printf("%d + %d = %d\n", a, b, sum);
	sum = addPassByReference(&a, &b);
	printf("%d + %d = %d\n", a, b, sum);
	sum = addPassByReferenceAlternateNotation(a, b);
	printf("%d + %d = %d\n", a, b, sum);
}

void pointer(void)
{
	int *intPtr;				//Create a pointer
	intPtr = new int;			//Allocate memory
	*intPtr = 20080808;			//Set value at given addPassByValueress
	cout << *intPtr << endl;	//Display value at given addPassByValueress
	delete intPtr;				//Deallocate memory
	int otherVal = 5;	
	intPtr = &otherVal;			//Change intPtr to point to a new location
	cout << *intPtr << endl;	//Display value at given addPassByValueress	
}

void arrayStackAllocation(void)
{
	int intArray[10];
	intArray[0] = 6837;
}

void arrayHeapAllocation(void)
{
	int *intArray;
	intArray = new int[10];
	intArray[0] = 6837;
	
	delete[] intArray;
}

void strings(void)
{
	char myString[20];	//A string in C++ is an array of characters
	strcpy(myString, "Hello World");
	cout << myString << endl;
	
	myString[0] = 'H';	//Strings are terminated with the NULL or '\0' character
	myString[1] = 'i';
	myString[2] = '\0';

	printf("%s\n", myString);	
}

int addPassByValue(int a, int b) {
	return a+b;
}

int addPassByReference(int *a, int *b) {
	*a = 4;
	*b = 2;
	return *a+*b;
}

int addPassByReferenceAlternateNotation(int &a, int &b) {
	a = 7;
	b = 1;
	return a+b;
}
