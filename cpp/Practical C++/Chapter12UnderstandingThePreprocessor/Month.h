//2016-10-03 Header file: Month.h

const int MONTH_COUNT = 12;
const char* MONTH_NAMES[] = {
	"January",
	"February",
	"March",
	"April",
	"May",
	"June",
	"July",
	"August",
	"September",
	"October",
	"November",
	"December"
};

struct Month {
	char* Name;
	int Number;
};	
