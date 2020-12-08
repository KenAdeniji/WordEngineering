/*
	2013-01-07	Ayepelu.
	2017-11-26	Created.
*/

#include <ctime>
#include <iomanip>
#include <iostream>
#include <string>
#include <vector>

#include "Light.hpp"

using namespace std;
using namespace WordEngineering;

void printCollection(vector<Light>);
void stub();

void printCollection(vector<Light> lights)
{
	for (int i = 0; i < lights.size(); ++i)
	{
		cout << "light: " << lights[i] << endl;
	}	
}

void stub()
{
	vector<Light> lights;

	Light* sun = new Light
	(
		"Sun",
		"The greater light to rule the day.",
		"Genesis 1:14-19"
	);
	//lights.push_back(*sun);

	Light* moon = new Light
	(
		"Moon",
		"The lesser light to rule the night.",
		"Genesis 1:14-19"
	);
	//lights.push_back(*moon);
	
	//lights = { sun, moon };	
	
	lights.assign(sun, moon);
	
	printCollection(lights);	
}
	
void main()
{
	stub();
}
