/**
	2025-08-12T19:02:00 http://www.google.com/books/edition/Java_for_Programmers/MqpJEQAAQBAJ?hl=en&gbpv=1
	Using the Date/Time API to calculate a period of time for the user,
	and the starting day of the week.
*/
import java.time.Duration;
import java.time.LocalDate;
import java.time.LocalDateTime;
import java.time.LocalTime;
import java.time.Period;
import java.time.format.DateTimeFormatter;
import java.time.format.FormatStyle;
import java.time.format.TextStyle;
import java.time.temporal.ChronoUnit;
import java.util.Locale;
public class AgeCalculator
{
	/**
		args[0]=1969-07-20 (YYYY-MM-DD)
		args[1]=22:56 (HH:mm)
		args[2]=2024-06-15T11:40:59 (YYYY-MM-DDTHH:mm:ss)
		
		2025-08-12T19:46:00 Debug mode?
			displayDatesAndTimes().
		2025-08-12T19:51:00 I have grown ambivient to regurgitative console input from HTML and JavaScript.
			HTML supports default value, and placeholder.
			URI supports querystring.
	*/
	public static void main
	(
		String[] args
	)
	{
		var dateFrom = LocalDate.parse
		(
			args.length > 0 ? 
			args[0] : 
			NeilArmstrongSteppedOnToTheMoonDate
		);
		var timeFrom = LocalTime.parse
		(
			args.length > 1 ? 
			args[1] : 
			NeilArmstrongSteppedOnToTheMoonTime
		);
		var datetimeFrom = LocalDateTime.of
		(
			dateFrom,
			timeFrom
		);	
		var now = LocalDateTime.parse
		(
			args.length > 2 ? 
			args[2] : 
			LocalDateTimeNow
		);
		displayDatesAndTimes(datetimeFrom, now);
	}	
	
	public static void displayDatesAndTimes
	(
		LocalDateTime datetimeFrom,
		LocalDateTime now	
	)
	{
		var formatter = DateTimeFormatter.ofLocalizedDateTime
		(
			FormatStyle.MEDIUM
		);
		System.out.printf
		(
			"From: %s%n",
			datetimeFrom.format(formatter)
		);
		System.out.printf
		(
			"Now: %s%n",
			now.format(formatter)
		);
	}	
	
	public static String NeilArmstrongSteppedOnToTheMoonDate = "1969-07-20";
	public static String NeilArmstrongSteppedOnToTheMoonTime = "22:56";
	public static String LocalDateTimeNow = "2024-06-15T11:40:59";
}
