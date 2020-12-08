/*
	2013-01-07	Ayepelu.
	2017-11-26	Created.
	2017-11-27	http://stackoverflow.com/questions/8906545/how-to-initialize-a-vector-in-c
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
vector<Light> populateLights();

void printCollection(vector<Light> lights)
{
	for (int i = 0; i < lights.size(); ++i)
	{
		cout << "light: " << lights[i] << endl;
	}	
}

vector<Light> populateLights()
{
	vector<Light> lights;

	Light* sun = new Light
	(
		"Sun",
		"The greater light to rule the day.",
		"Genesis 1:14-19"
	);
	lights.push_back(*sun);

	Light* moon = new Light
	(
		"Moon",
		"The lesser light to rule the night.",
		"Genesis 1:14-19"
	);

	//Light* moon = sun;
	lights.push_back(*moon);
	
	//lights = { sun, moon };	
	
	//lights.assign(sun, moon);
	return lights;
}
	
void main()
{
	vector<Light> lights = populateLights();
	printCollection(lights);
}
