/*
	2024-01-13T18:17:00 http://oualline.com/books.free/teach/slides/ch05.pdf
*/
#include <iostream>
#include <vector>

using namespace std;

int main(int argc, char *argv[])
{
	float score;
	vector<float> scores;

	for(;;)
	{
		cout << "Enter a score? ";
		cin >> score;
		if (score < 0 )
		{
			break;
		}
		scores.push_back(score);
	}

	int scoreCount = scores.size();
	cout << "Count: " << scoreCount << endl;
	
	float scoreSum = 0;
	for (int scoreIndex = 0; scoreIndex < scoreCount; ++scoreIndex)
	{
		scoreSum += scores[scoreIndex];
	}
	cout << "Sum: " << scoreSum << endl;
	
	float scoreAverage = scoreSum / scoreCount;
	cout << "Average: " << scoreAverage << endl;
}
