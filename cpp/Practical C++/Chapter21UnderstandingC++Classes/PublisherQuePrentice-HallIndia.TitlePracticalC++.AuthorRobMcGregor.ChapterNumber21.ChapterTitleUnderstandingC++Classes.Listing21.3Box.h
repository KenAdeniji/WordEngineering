/*
	2016-10-04	PublisherQuePrentice-HallIndia.TitlePracticalC++.AuthorRobMcGregor.ChapterNumber21.ChapterTitleUnderstandingC++Classes.Listing21.3Box.h
*/

#ifndef __BOX_H__
#define __BOX_H__

class Box
{
	public:
		Box();
		Box(double length, double width, double height);
		Box(Box& box);
		Box& operator=(const Box& box);
		
		double Volume();
		
		double height;
		double length;
		double width;
};

#endif //__BOX_H__

