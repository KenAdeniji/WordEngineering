/*
	2016-02-20	Hosea 11:1, Matthew 2:13-18.
	2016-02-23	Created. Isaiah 61:2, Luke 4:19.
*/

#include <ctime>
#include <iomanip>
#include <iostream>
#include <windows.h>
#include <sqltypes.h>
#include <sql.h>
#include <sqlext.h>
#include <vector>

#include "ProphecyFulfill.hpp"

using namespace std;

void printCollection(vector<ProphecyFulfill>);
void stub();

void printCollection(vector<ProphecyFulfill> propheciesFulfillments)
{
	for (int i = 0; i < propheciesFulfillments.size(); ++i)
	{
		char* prophecy = propheciesFulfillments[i].getProphecy();
		char* fulfill = propheciesFulfillments[i].getFulfill();
		
		cout << "Prophecy: " << prophecy << " Fulfill: " << fulfill << endl;
	}	
}

void stub()
{
	char prophecy[2000];
	char fulfill[2000];
	
	vector<ProphecyFulfill> propheciesFulfillments;

	ProphecyFulfill* prophecyFulfill = new ProphecyFulfill
	(
		"Hosea 11:1",
		"Matthew 2:13-18"
	);
	propheciesFulfillments.push_back(*prophecyFulfill);

	prophecyFulfill = new ProphecyFulfill
	(
		"Isaiah 61:2",
		"Luke 4:19"
	);
	propheciesFulfillments.push_back(*prophecyFulfill);
	
	printCollection(propheciesFulfillments);	
}
	
int main(){
	stub();
}
