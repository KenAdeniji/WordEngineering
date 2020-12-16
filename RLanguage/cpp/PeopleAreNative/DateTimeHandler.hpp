#ifndef DateTimeHandler_HPP
#define DateTimeHandler_HPP
 
namespace PeopleAreNative
{
	class DateTimeHandler
	{
		private:
			static int rdn(int y, int m, int d);
			
		public:
		static int dateDifference
		(
			int	fromYear,
			int	fromMonth,
			int	fromDay,	
			int	toYear,
			int	toMonth,
			int	toDay
		);
	};
	
	extern "C" __declspec(dllexport) int call_DateTimeHandler_dateDifference		
	(
		int	fromYear,
		int	fromMonth,
		int	fromDay,	
		int	toYear,
		int	toMonth,
		int	toDay
	);
} 
#endif
