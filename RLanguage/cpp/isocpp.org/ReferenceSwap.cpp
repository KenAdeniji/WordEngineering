/*
	2019-05-09	Created.	https://isocpp.org/wiki/faq/references
*/

#include <iostream>

using namespace std;

void swap(int& i, int& j)
{
	int tmp = i;
	i = j;
	j = tmp;
}
int main()
{
	int x, y;
	cout << "Please enter x: ";
	cin >> x;
	cout << "Please enter y: ";
	cin >> y;
	swap(x,y);
	cout << "Swapped x: " << x << " y: " << y << endl;
}
