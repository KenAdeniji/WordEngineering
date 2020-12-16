/*
	2016-10-04	cl /clr PublisherQuePrentice-HallIndia.TitlePracticalC++.AuthorRobMcGregor.ChapterNumber22.ChapterTitleImplementingClassInheritance.Living.cpp
*/

#include <iostream>
#include <string>

using namespace std;

#include "PublisherQuePrentice-HallIndia.TitlePracticalC++.AuthorRobMcGregor.ChapterNumber22.ChapterTitleImplementingClassInheritance.CreatureLib.h"

void main(int argc, char *argv[])
{
	Man	adam;
	adam.name = "Adam";
	adam.yearsLived = 930;
	
	std::cout << adam << std::endl;
}
