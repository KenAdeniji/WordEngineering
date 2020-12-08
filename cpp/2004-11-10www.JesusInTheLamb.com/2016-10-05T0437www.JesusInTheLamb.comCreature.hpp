/*
	2016-10-05T04:43:00	2016-10-05T0437www.JesusInTheLamb.comCreature.hpp
	2016-10-04	http://stackoverflow.com/questions/1549930/c-equivalent-of-java-tostring
	
	2016-10-05T08:24:00 YearsLived, Adam, 930.
*/

#include <iostream>
#include <string>

using namespace std;

#ifndef Creature_HPP
#define Creature_HPP
 
class Creature
{
	public:
		int		yearsLived;
	
		string	name;
 
	public:
		Creature() {
			cout << "Creature constructor." << endl;
		}
	
		Creature
		(
			string	name
		);

		friend ostream& operator <<(ostream& outputStream, const Creature& creature);
	 
		void SetCreature
		(
			string	name
		);

		string	getName();
		void	setName(string name);
		
		int		getYearsLived();
		void	setYearsLived(int yearsLived);
};
 
#endif
