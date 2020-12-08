/*
	2016-10-04	cl /clr PublisherQuePrentice-HallIndia.TitlePracticalC++.AuthorRobMcGregor.ChapterNumber21.ChapterTitleUnderstandingC++Classes.Listing21.4Box.cpp
*/

#include <iostream>
#include "PublisherQuePrentice-HallIndia.TitlePracticalC++.AuthorRobMcGregor.ChapterNumber21.ChapterTitleUnderstandingC++Classes.Listing21.3Box.h"

// Constructors.

// Default constructor
Box::Box()
{
}

// Default-parameter constructor
Box::Box
(
	double length = 0.0f, double width = 0.0f, double height = 0.0f
)
{
	this->height = height;
	this->length = length;
	this->width = width;
}	

// Copy constructor
Box::Box(Box& box)
{
	this->height = box.height;
	this->length = box.length;
	this->width = box.width;
}

// ::operator=()
Box& Box::operator=(const Box& box)
{
	this->height = box.height;
	this->length = box.length;
	this->width = box.width;
	
	return *this;
}

double Box::Volume()
{
	return height * length * width;
}

void main(int argc, char *argv[])
{
	Box	*boxFirst = new Box(1967.0f, 10.0f, 15.0f);
	
	std::cout << boxFirst->Volume() << '\n';
	
	delete boxFirst;
}
