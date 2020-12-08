/*
	2016-10-05T05:51:00	2016-10-05T0551www.JesusInTheLamb.comMan.hpp
	2016-10-05T06:26:00	http://stackoverflow.com/questions/24725326/error-c2504-base-class-undefined
*/

#include <iostream>
#include <string>

#include "2016-10-05T0437www.JesusInTheLamb.comCreature.hpp"

using namespace std;

#ifndef Man_HPP
#define Man_HPP
 
class Man : public Creature // Derived from Creature
{
	public:
		Man() : Creature() {
			cout << "Man constructor." << endl;
		}
};
 
#endif
