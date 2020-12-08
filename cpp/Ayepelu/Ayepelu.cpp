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

#include "FunctionTemplate.hpp"
#include "Light.hpp"

using namespace std;
using namespace WordEngineering;

vector<Light> populateLights();

vector<Light> PopulateLights()
{
	vector<Light> lights;

	Light* sun = new Light
	(
		"Sun",
		"The greater light to rule the day.",
		"Genesis 1:14-19"
	);
	lights.push_back(*sun);

	Light* moon = sun; //Copy constructor.
	moon->SetNamed("Moon");
	moon->SetCommentary("The lesser light to rule the night.");
	lights.push_back(*moon);
	
	//lights = { sun, moon };	
	
	//lights.assign(sun, moon);
	return lights;
}
	
void main()
{
	auto lights = PopulateLights();
	FunctionTemplate::Render<Light>(lights);
}
