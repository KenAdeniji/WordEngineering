/*
	2016-10-05T0536www.JesusInTheLamb.comCreation.cpp
	2016-10-05T06:55:00 http://stackoverflow.com/questions/12248703/creating-an-instance-of-class
*/

#include <iostream>
#include <vector>

#include "2016-10-05T0605www.JesusInTheLamb.comLiving.hpp"

using namespace std;

void dumpManVector(vector<Man> men);
vector<Man> initialization();

void dumpManVector(vector<Man> men)
{
	for (int index = 0; index < men.size(); ++index)
	{
		Man man = men[index];
		cout << man << endl;
	}	
}

vector<Man> initialization()
{
	Man* adam = new Man();
	
	adam->name = "Adam";
	adam->yearsLived = 930;
	cout << *adam << endl;
	
	vector<Man> men;
	
	men.push_back(*adam);
	
	return men;
}
	
void stub();
void stub()
{
	Man* adam = new Man();

/*	
	adam->setName("Adam");
	adam->name = "Adam";
*/

	adam->name = "Adam";
	adam->yearsLived = 930;
	
	cout << *adam << endl;
	
/*	
	cout << "Adam's yearsLived: " << adam->yearsLived << endl;
	cout << "Adam's name: " << adam->name << endl;
*/



	delete adam;	
}
	
void main(int argc, char *argv[])
{
	//stub();
	
	vector<Man> men = initialization();
	dumpManVector(men);
}


