/*
	2016-10-04	cl /clr PublisherQuePrentice-HallIndia.TitlePracticalC++.AuthorRobMcGregor.ChapterNumber21.ChapterTitleUnderstandingC++Classes.Listing21.1ThisPointerStaticDataMember.cpp
*/

#include <iostream>

using namespace std;

//Class declarations

class ThreeDimensionalPoint
{
	public:
		//Constructor / Destructor
		ThreeDimensionalPoint();
		~ThreeDimensionalPoint();
		
		//Public data members
		double	x;
		double	y;
		double	z;
		
	private:
		//Private data members
		static long classInstances;
};	

//Class definitions

//Constructor / Destructor

ThreeDimensionalPoint::ThreeDimensionalPoint() :
	x(0.0f), y(0.0f), z(0.0f)
{
	//Display the increment static member
	std::cout << "Constructing: "
		<< ++(this->classInstances)
		<< "ThreeDimensionalPoint objects exist\n";
}

ThreeDimensionalPoint::~ThreeDimensionalPoint()
{
	//Display the decrement static member
	std::cout << "Destructing: "
		<< --(this->classInstances)
		<< "ThreeDimensionalPoint objects exist\n";
}

long ThreeDimensionalPoint::classInstances = 0;

void main(int argc, char *argv[])
{
	ThreeDimensionalPoint *pointFirst = new ThreeDimensionalPoint;
	
	delete pointFirst;
}
