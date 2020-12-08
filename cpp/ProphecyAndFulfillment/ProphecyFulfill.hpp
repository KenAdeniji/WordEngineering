/*
	2016-02-20	Hosea 11:1, Matthew 2:13-18.
	2016-02-23	Created. Isaiah 61:2, Luke 4:19.
*/

#include <iostream>

#ifndef ProphecyFulfill_HPP
#define ProphecyFulfill_HPP
 
class ProphecyFulfill
{
	private:
		char prophecy[2000];
		char fulfill[2000];
 
	public:
		ProphecyFulfill
		(
			char prophecy[2000],
			char fulfill[2000]
		);
	 
		void SetProphecyFulfill
		(
			char prophecy[2000],
			char fulfill[2000]
		);

		char* getProphecy();
		char* getFulfill();
};
 
#endif
