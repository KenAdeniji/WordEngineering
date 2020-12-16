// compile with: /GR /EHsc
/*
	2015-08-10	Created.	groups.csail.mit.edu/graphics/classes/6.837/F03/lectures/cpp_tutorial.ppt
*/

#include <iostream>

#include "Image.h"

using namespace std;

int main()
{
}

void CreatingAnInstance(void)
{
}

//Stack allocation:  Constructor and destructor called automatically when the function is entered and exited.
void CreatingAnInstanceStackAllocation(void)
{
	Image myImage;
	//myImage.SetAllPixels(ClearColor);	
}
	
//Heap allocation:  Constructor and destructor must be called explicitly.
void CreatingAnInstanceHeapAllocation(void)
{
	Image *imagePtr;
	imagePtr = new Image();
	//imagePtr->SetAllPixels(ClearColor);

	//

	delete imagePtr;
}
