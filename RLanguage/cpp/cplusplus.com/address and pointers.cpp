// address and pointers
// 2016-02-09	http://www.cplusplus.com/doc/tutorial/pointers/
#include <iostream>
using namespace std;

void main(void)
{
	int index = 5;
	auto addressOfIndex = &index;
	int indexPointer = *addressOfIndex;
	cout << "addressOfIndex: " << addressOfIndex << endl;	
	cout << "indexPointer: " << indexPointer << endl;
	
	int content[] = { 1, 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31 };

	for 
	(
		int index = 0, count = sizeof(content) / sizeof(int), *addressOfElement = content;
		index < count;
		++index
	)
	{
		//cout << addressOfElement[index] << endl;
		cout << *(addressOfElement + index) << endl;
	}
	
	return;
}
