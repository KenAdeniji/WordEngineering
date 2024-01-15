/*
	2024-01-13T17:49:00 http://oualline.com/books.free/teach/slides/ch04.pdf
*/
#include <iostream>

using namespace std;

int main(int argc, char *argv[])
{
	float height;
	float width;
	float area;

	cout << "What is the height? ";
	cin >> height;

	cout << "What is the width? ";
	cin >> width;
	
	area = height * width;

	cout << "Area: " << area;	
}
