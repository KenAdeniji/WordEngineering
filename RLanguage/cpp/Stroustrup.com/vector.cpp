// compile with: /GR /EHsc
/*
	2015-02-25	Created. http://stroustrup.com/Programming
*/

#include <algorithm>
#include <iostream>
#include <string>
#include <vector>

using namespace std;

void input(vector<double>& temperatures);
double median(vector<double>& temperatures);
void output(vector<double>& temperatures);
double sum(vector<double>& temperatures);

int main() {
	//vector<double> v = {5, 7, 9, 4, 6, 8};
	vector<double> temperatures;
	
	input(temperatures);
	
	if (temperatures.size() <= 0)
	{
		return 0;
	}
	
	sort(temperatures.begin(), temperatures.end());
	
	double total = sum(temperatures);
	double average = total / temperatures.size();
	double medianResult = median(temperatures);
	
	cout << "Average: " << average << endl;
	cout << "Count: " << temperatures.size() << endl;
	cout << "Maximum: " << temperatures[temperatures.size() - 1] << endl;	
	cout << "Median: " << medianResult << endl;
	cout << "Minimum: " << temperatures[0] << endl;
	cout << "Sum: " << total << endl;	
}

void input(vector<double>& temperatures)
{
	cout << "Enter temperatures: ";
	for (double temp; cin >> temp;)
	{
		temperatures.push_back(temp);
	}	
}

double median(vector<double>& temperatures)
{
	double result = 0;
	int count = temperatures.size();
	
	if (count % 2 == 1)
	{
		result = temperatures[(count - 1) / 2];
	}
	else
	{
		result = (
			temperatures[(count / 2) - 1] + 
			temperatures[count / 2]
		) / 2;
	}
	
	return result;	
}

void output(vector<double>& temperatures)
{
	cout << "Temperatures: ";
	for (int i = 0; i < temperatures.size(); ++i)
	{
		cout << temperatures[i] << '\n';
	}	
}

double sum(vector<double>& temperatures)
{
	double result = 0;
	for (int i = 0; i < temperatures.size(); ++i)
	{
		result += temperatures[i];
	}
	return result;
}
