export class WhatIHaveAsAPeriod
{
	static addDays(myDate,days) {
		return new Date(myDate.getTime() + days*24*60*60*1000);
	}

	static DaysInYears(metric, value){//constructor
		this.metric = metric;
		this.value = value;
	}
	
	static daysDifference(datedFrom = new Date(), datedUntil = new Date()) {
		datedFrom = !isNaN(datedFrom) ? datedFrom : new Date();
		datedUntil = !isNaN(datedUntil) ? datedUntil : new Date();
		return Math.round((datedUntil - datedFrom)/(1000*60*60*24));
	}

	static daysBetween(date1, date2) {
		// The number of milliseconds in one day
		var ONE_DAY = 1000 * 60 * 60 * 24

		// Convert both dates to milliseconds
		var date1_ms = date1.getTime()
		var date2_ms = date2.getTime()

		// Calculate the difference in milliseconds
		var difference_ms = Math.abs(date1_ms - date2_ms)

		// Convert back to days and return
		return Math.round(difference_ms/ONE_DAY)
	}
	
	static biblicalCalendarDifference(days)
	{
		var year = Math.trunc(days / 360);
		var remainder = days % 360;
		var month = Math.trunc(remainder / 30);
		var day = Math.trunc(remainder % 30);
		
		var calendar = "";
		
		if (year > 0)
		{
			calendar += year + " year" + (year === 1 ? "" : "s");
		}

		if (month > 0)
		{
			if (calendar != "")
			{
				calendar += ", ";
			}
			
			calendar += month + " month" + (month === 1 ? "" : "s");
		}

		if (day > 0)
		{
			if (calendar != "")
			{
				calendar += ", ";
			}
			calendar += day + " day" + (day === 1 ? "" : "s");
		}

		return calendar;
	}

	static getBusinessDatesCount(startDate, endDate) {
		var count = 0;
		var curDate = startDate;
		while (curDate <= endDate) {
			var dayOfWeek = curDate.getDay();
			if(!((dayOfWeek == 6) || (dayOfWeek == 0)))
			   count++;
			curDate.setDate(curDate.getDate() + 1);
		}
		return count;
	}

	static isLeap(year)
	{ 
		return year % 4 == 0 && year % 100 != 0 || year % 400 == 0; 
	}
	
	static isLeapYear(year)
	{
		var date = new Date(year+"/02/29");
		var leapYear = false;
		if (1 === date.getMonth())
		{
			leapYear = true;
		}	
		return leapYear;
	}	
	
	static getDateDifference(date1 = new Date(), date2 = new Date()) {
		// Ensure start is before end
		let start = new Date(Math.min(date1, date2));
		let end = new Date(Math.max(date1, date2));

		let years = end.getFullYear() - start.getFullYear();
		let months = end.getMonth() - start.getMonth();
		let days = end.getDate() - start.getDate();

		// If days are negative, borrow days from the previous month
		if (days < 0) {
			months--;
			// Day 0 of the end month gives the last day of the previous month
			const prevMonthLastDay = new Date(end.getFullYear(), end.getMonth(), 0).getDate();
			days += prevMonthLastDay;
		}

		// If months are negative, borrow 12 months from the years
		if (months < 0) {
			years--;
			months += 12;
		}

		return { years, months, days };
	}
	
	static yearMonthWeekDay(datedFrom = new Date(), datedUntil = new Date()) {
		datedFrom = !isNaN(datedFrom) ? datedFrom : new Date();
		datedUntil = !isNaN(datedUntil) ? datedUntil : new Date();
		var	dateCurrent = datedFrom;
		var	days = 0;
		var	weeks = 0;
		var	months = 0;
		var	years = 0;
		
		var	weekDays = 0;
		
		var daysInYears = new Array();
		
		while ( dateCurrent < datedUntil )
		{
			var daysOffset = 365;
			var isLeap = WhatIHaveAsAPeriod.isLeapYear(dateCurrent.getFullYear());
			if (isLeap)
			{
				daysOffset = 366;
			}
			if ( WhatIHaveAsAPeriod.addDays(dateCurrent, daysOffset ) > datedUntil )
			{
				break;
			}
			dateCurrent = WhatIHaveAsAPeriod.addDays( dateCurrent, daysOffset );
			++years;
		}
		
		while ( dateCurrent < datedUntil )
		{
			var currentMonth = dateCurrent.getMonth();
			var daysOffset = daysInMonth[currentMonth];
			var isLeap = WhatIHaveAsAPeriod.isLeapYear(dateCurrent.getFullYear());
			if (isLeap && currentMonth == 2)
			{
				daysOffset = 29;
			}
			if ( WhatIHaveAsAPeriod.addDays(dateCurrent, daysOffset ) > datedUntil )
			{
				break;
			}
			dateCurrent = WhatIHaveAsAPeriod.addDays( dateCurrent, daysOffset );
			++months;
		}

		weekDays = WhatIHaveAsAPeriod.daysBetween(dateCurrent, datedUntil);
	
		weeks = Math.floor(weekDays / 7);

		days = weekDays % 7;
		
		var yearOutput = "";
		
		daysInYears.push(new WhatIHaveAsAPeriod.DaysInYears("year", years));
		daysInYears.push(new WhatIHaveAsAPeriod.DaysInYears("month", months));
		daysInYears.push(new WhatIHaveAsAPeriod.DaysInYears("week", weeks));
		daysInYears.push(new WhatIHaveAsAPeriod.DaysInYears("day", days));
		
		for (var index = 0, length = daysInYears.length; index < length; ++index)
		{
			if (daysInYears[index].value == 0) { continue; }
			var aShineInTheCloud	=	"";

			aShineInTheCloud = 	((yearOutput.length === 0) ? "" : ", " ) +
								(daysInYears[index].value + " ") +
								daysInYears[index].metric +
								((daysInYears[index].value === 1) ? "" : "s");
			
			yearOutput 			+=	aShineInTheCloud;			
		}
	
		return yearOutput;
	}

	//	                 1   2   3   4   5   6   7,  8,  9  10, 11, 12	
	static daysInMonth = [ 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 ];
}
