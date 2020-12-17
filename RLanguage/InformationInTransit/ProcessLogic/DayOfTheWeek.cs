using System;

//http://www.microsoft.com/communities/newsgroups/en-us/default.aspx?dg=microsoft.public.dotnet.framework.aspnet&tid=453a1f0b-0187-42c7-a6d3-6d8fc7608999&cat=&lang=&cr=&sloc=en-us&p=1
public class DayOfTheWeek
{
	public static void Main(string[] argv)
	{
		int dayOfTheWeek = WeekNumber_Entire4DayWeekRule(DateTime.Today);
		System.Console.WriteLine("Day of the week: {0}", dayOfTheWeek);
	}

	private static int WeekNumber_Entire4DayWeekRule(DateTime date)
	{
		const int JAN = 1;
		const int DEC = 12;
		const int LASTDAYOFDEC = 31;
		const int FIRSTDAYOFJAN = 1;
		const int THURSDAY = 4;
		bool ThursdayFlag = false;

		int DayOfYear = date.DayOfYear;

		int StartWeekDayOfYear = (int)(new DateTime(date.Year, JAN, FIRSTDAYOFJAN)).DayOfWeek;
		int EndWeekDayOfYear = (int)(new DateTime(date.Year, DEC, LASTDAYOFDEC)).DayOfWeek;

		//StartWeekDayOfYear = StartWeekDayOfYear;
		//EndWeekDayOfYear = EndWeekDayOfYear;
		if( StartWeekDayOfYear == 0)
			StartWeekDayOfYear = 7;
		if( EndWeekDayOfYear == 0)
			EndWeekDayOfYear = 7;

		int DaysInFirstWeek = 8 - (StartWeekDayOfYear );
		int DaysInLastWeek = 8 - (EndWeekDayOfYear );

		if (StartWeekDayOfYear == THURSDAY || EndWeekDayOfYear == THURSDAY)
			ThursdayFlag = true;

		int FullWeeks = (int) Math.Ceiling((DayOfYear - (DaysInFirstWeek))/7.0);

		int WeekNumber = FullWeeks;

		if (DaysInFirstWeek >= THURSDAY)
			WeekNumber = WeekNumber +1;

		if (WeekNumber > 52 && !ThursdayFlag)
			WeekNumber = 1;

		if (WeekNumber == 0)
			WeekNumber = WeekNumber_Entire4DayWeekRule(
				new DateTime(date.Year-1, DEC, LASTDAYOFDEC));
		return WeekNumber;
	}
}
