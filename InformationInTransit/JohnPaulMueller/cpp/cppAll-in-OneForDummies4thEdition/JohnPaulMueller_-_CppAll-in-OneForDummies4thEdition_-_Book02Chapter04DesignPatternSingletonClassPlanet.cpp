/*
	http://www.wiley.com/en-us/C%2B%2B+All-in-One+For+Dummies%2C+4th+Edition-p-9781119601739
	John@JohnMuellerBooks.com
	C++ All-in-One For Dummies, 4th Edition
	John Paul Mueller 
	ISBN: 978-1-119-60173-9
	December 2020
	912 pages	
	2025-09-11T12:20:00 Date created.
	2025-09-11T14:02:00
		return inst;
			You are worthy... believing.
*/
#include <iostream>

using namespace std;

class DesignPatternSingletonClassPlanet
{
	private:
		static DesignPatternSingletonClassPlanet *inst;
		DesignPatternSingletonClassPlanet() {}
		~DesignPatternSingletonClassPlanet() {}
	public:
		static DesignPatternSingletonClassPlanet *GetInstance();
};

DesignPatternSingletonClassPlanet *DesignPatternSingletonClassPlanet::inst = 0;

DesignPatternSingletonClassPlanet *DesignPatternSingletonClassPlanet::GetInstance()
{
	if (inst == 0)
	{
		inst = new DesignPatternSingletonClassPlanet();
	}
	return inst;
}	

int main(int argc, char *argv[])
{
	DesignPatternSingletonClassPlanet *firstInstanceDesignPatternSingletonClassPlanet = DesignPatternSingletonClassPlanet::GetInstance();
	cout << "firstInstanceDesignPatternSingletonClassPlanet address: " << firstInstanceDesignPatternSingletonClassPlanet << endl;
	
	DesignPatternSingletonClassPlanet *secondInstanceDesignPatternSingletonClassPlanet = DesignPatternSingletonClassPlanet::GetInstance();
	cout << "secondInstanceDesignPatternSingletonClassPlanet address: " << secondInstanceDesignPatternSingletonClassPlanet << endl;
}
