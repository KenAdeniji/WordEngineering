/**
	2025-08-12T19:02:00 http://www.google.com/books/edition/Java_for_Programmers/MqpJEQAAQBAJ?hl=en&gbpv=1
	Using the Date/Time API to calculate a period of time for the user,
	and the starting day of the week.
	http://en.wikipedia.org/wiki/List_of_ISO_639_language_codes
		ISO 639-1 Language Codes
		ISO 639 is a standardized nomenclature used to classify languages. Each language is assigned a two-letter (set 1) and three-letter lowercase abbreviation (sets 2–5).[2] Part 1 of the standard, ISO 639-1 defines the two-letter codes, and Part 3 (2007), ISO 639-3, defines the three-letter codes, aiming to cover all known natural languages, largely superseding the ISO 639-2 three-letter code standard. 
	http://en.wikipedia.org/wiki/ISO_3166-1_alpha-2
		ISO 3166-1 alpha-2 codes are two-letter country codes defined in ISO 3166-1, part of the ISO 3166 standard[1] published by the International Organization for Standardization (ISO), to represent countries, dependent territories, and special areas of geographical interest. They are the most widely used of the country codes published by ISO (the others being alpha-3 and numeric), and are used most prominently for the Internet's country code top-level domains (with a few exceptions). They were first included as part of the ISO 3166 standard in its first edition in 1974. 
	http://en.wikipedia.org/wiki/List_of_tz_database_time_zones
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
		2025-08-12T19:51:00 I have grown ambient to regurgitative HTML and JavaScript.
			JavaScript Essentials for Dummies by Paul McFedries.
				var alias = prompt(string, default);
					When the user exits by clicking the OK button, the computer returns the value entered by the user.
					When the user exits by clicking the Cancel button, the computer returns null.
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
		System.out.printf
		(
			"From day of the week: %s%n",
			datetimeFrom.getDayOfWeek().getDisplayName
			(
				TextStyle.FULL,
				Locale.getDefault()
			)
		);
		var period = Period.between(dateFrom, now.toLocalDate());
		var duration = Duration.between(datetimeFrom, now);
		System.out.printf
		(
			"""
				%d years, %d months, and %d days
				
                    Total months:     %,d
                      Total days:     %,d
                     Total hours:     %,d
                   Total minutes:     %,d
                   Total seconds:     %,d
			""",
			period.getYears(),
			period.getMonths(),
			period.getDays(),
			period.toTotalMonths(),
			dateFrom.until(now.toLocalDate(), ChronoUnit.DAYS),
			duration.toHours(),
			duration.toMinutes(),			
			duration.toSeconds()
		);
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
	public static String LocalDateTimeNow = "2024-06-15T12:40:56";
}
