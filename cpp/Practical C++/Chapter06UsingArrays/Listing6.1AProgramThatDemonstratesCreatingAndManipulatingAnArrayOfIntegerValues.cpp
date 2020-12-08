#include <iostream>

using namespace std;
//2016-10-03 cl /clr Listing6.1AProgramThatDemonstratesCreatingAndManipulatingAnArrayOfIntegerValues.cpp

void main(int argc, char *argv[])
{
	int num[7];
	for (int index = 0; index < (sizeof(num)/sizeof(*num)); ++index)
	{
		num[index] = index;
		printf
		(
			"num[%i]: %i\n",
			index,
			num[index]
		);
	}	
}
