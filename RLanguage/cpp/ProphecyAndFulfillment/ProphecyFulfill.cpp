/*
	2016-02-20	Hosea 11:1, Matthew 2:13-18.
	2016-02-23	Created. Isaiah 61:2, Luke 4:19.
*/

#include <cassert>

#include "ProphecyFulfill.hpp"

using namespace std;

/*
	2016-02-23	http://www.onlamp.com/pub/a/onlamp/2004/10/28/design_by_contract_in_c.html
	2016-02-23	stackoverflow.com/questions/1793867/best-way-to-check-if-a-character-array-is-empty
*/
// ProphecyFulfill constructor
ProphecyFulfill::ProphecyFulfill
(
	char prophecy[2000],
	char fulfill[2000]
)
{
	SetProphecyFulfill(prophecy, fulfill);
}
 
// ProphecyFulfill member function
void ProphecyFulfill::SetProphecyFulfill
(
	char localProphecy[2000],
	char localFulfill[2000]	
)
{
	assert(localProphecy[0] != '\0' || strlen(localProphecy) != 0); 
	assert(localFulfill[0] != '\0' || strlen(localFulfill) != 0); 
	
	strcpy(prophecy, localProphecy);
	strcpy(fulfill, localFulfill);	
}

char* ProphecyFulfill::getProphecy()
{ 
	//char* str = (char* ) malloc(sizeof(char) * 2000); // free(str);
	char* str = new char[2000];
	str = prophecy;
	return str;	
}

char* ProphecyFulfill::getFulfill()
{ 
	//char *str = (char* ) malloc(sizeof(char) * 2000); // free(str);
	char* str = new char[2000];
	str = fulfill;
	return str;	
}
