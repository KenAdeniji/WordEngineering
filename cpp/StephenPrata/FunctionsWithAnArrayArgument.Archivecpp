// compile: cl /GR /EHsc FunctionsWithAnArrayArgument.cpp
/*
	2019-01-25	Created. Stephen Prata.
*/

#include <iostream>

using namespace std;

int sum_arr(int arr[], int n);        // prototype

int main()
{
	int cookies[] = {1,2,4,8,16,32,64,128};
	// some systems require preceding int with static to
	// enable array initialization
	int sum = sum_arr(cookies, sizeof(cookies)/sizeof(int));
	cout << "Total cookies eaten: " << sum <<  "\n";
	return 0;
}

// return the sum of an integer array
int sum_arr(int arr[], int n)
{
	int total = 0;
	for (int i = 0; i < n; i++)
	total = total + arr[i];
	return total;
}
