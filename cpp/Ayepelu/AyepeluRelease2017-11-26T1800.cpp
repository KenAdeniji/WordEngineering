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

	Light* light = new Light("Sun");
	lights.push_back(*light);

	light = new Light("Moon");
	lights.push_back(*light);
	
	printCollection(lights);	
}
	
int main(){
	stub();
}
