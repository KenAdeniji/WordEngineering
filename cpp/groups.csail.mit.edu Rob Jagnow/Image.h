/*
	2015-08-10	Created.	groups.csail.mit.edu/graphics/classes/6.837/F03/lectures/cpp_tutorial.ppt
	Header file: Class definition & function prototypes
*/	
#ifndef _IMAGE_H_		//Prevents multiple references
#define _IMAGE_H_

#include <assert.h>		//Include a library file

//#include "vectors.h"	//Include a local file
#include <vector>

class Image {

public:					//Variables and functions accessible from anywhere
	void SetAllPixels(const Vec3f &color);
	
	void Image::SetAllPixels(const Vec3f &color) {
		for (int i = 0; i < width*height; i++)
		  data[i] = color;
	}
private:				//Variables and functions accessible only from within this class
	//...
};

#endif
