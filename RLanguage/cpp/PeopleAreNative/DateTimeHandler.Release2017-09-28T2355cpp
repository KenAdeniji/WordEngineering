#include "DateTimeHandler.hpp"

using namespace std;

namespace PeopleAreNative
{
	int DateTimeHandler::dateDifference
	(
		int fromYear,
		int fromMonth,
		int fromDay,	
		int toYear,
		int toMonth,
		int toDay
	)
	{
		int days = rdn(toYear, toMonth, toDay) - rdn(fromYear, fromMonth, fromDay);
		return days;
	}
	
	int DateTimeHandler::rdn(int y, int m, int d) { /* Rata Die day one is 0001-01-01 */
		if (m < 3)
			y--, m += 12;
		return 365*y + y/4 - y/100 + y/400 + (153*m - 457)/5 + d - 306;
	}
	
	extern "C" __declspec(dllexport) int call_DateTimeHandler_dateDifference
	(
		int	fromYear,
		int	fromMonth,
		int	fromDay,	
		int	toYear,
		int	toMonth,
		int	toDay
	)	
	{
		return DateTimeHandler::dateDifference
		(
			fromYear,
			fromMonth,
			fromDay,	
			toYear,
			toMonth,
			toDay
		);	
	}	
}
