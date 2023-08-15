/*
	Source: http://www.dummies.com/go/javaaiofd7e
	Learning Made Easy 7th Edition Java All-In-One for dummies A Wiley brand 8 books in one! Doug Lowe Wrote his first program on a computer with than 1K of memory
	Date created: 2023-08-03T14:31:00 ... 
	2023-08-03T14:31:00 ... 2023-08-03T16:24:00 import java.time.*; 
	2023-08-03T16:43:00 Microsoft Windows start date is 1601-01-01.
	2023-08-09T04:44:00 Methods that extract information about a date
	2023-08-09T12:34:00 ... 2023-08-09T13:12:00
E:\WordEngineering\Java\DougLowe\JavaAll-In-OneForDummies>javac DateTimeAPIHelper.java
DateTimeAPIHelper.java:39: error: cannot find symbol
                System.out.println("lengthOfMonth(): " + todayNow.lengthOfMonth());
                                                                 ^
  symbol:   method lengthOfMonth()
  location: variable todayNow of type LocalDateTime
DateTimeAPIHelper.java:40: error: cannot find symbol
                System.out.println("lengthOfYear(): " + todayNow.lengthOfYear());
                                                                ^
  symbol:   method lengthOfYear()
  location: variable todayNow of type LocalDateTime
2 errors
	2023-08-09T12:52:00	http://github.com/KenAdeniji/WordEngineering/blob/main/Java/DougLowe/JavaAll-In-OneForDummies/DateTimeAPIHelper.java
*/

import java.time.*; 

public class DateTimeAPIHelper
{
	public static void main(String[] args)
	{
		stub();
	}
	
	public static void stub()
	{
		LocalDateTime todayNow = LocalDateTime.now();
		
		System.out.println("Instant: " + Instant.now());
		System.out.println("LocalDate: " + LocalDate.now());
		System.out.println("LocalDateTime: " + LocalDateTime.now());		
		System.out.println("LocalTime: " + LocalTime.now());
		System.out.println("OffsetDateTime: " + OffsetDateTime.now());
		System.out.println("OffsetTime: " + OffsetTime.now());
		System.out.println("Year: " + Year.now());
		System.out.println("YearMonth: " + YearMonth.now());
		System.out.println("ZonedDateTime: " + ZonedDateTime.now());
		
		System.out.println("getYear(): " + todayNow.getYear());
		System.out.println("getMonth(): " + todayNow.getMonth());
		System.out.println("getMonthValue() 1 ... 12: " + todayNow.getMonthValue());
		System.out.println("getDayOfMonth(): " + todayNow.getDayOfMonth());
		System.out.println("getDayOfWeek(): " + todayNow.getDayOfWeek());
		System.out.println("getDayOfYear(): " + todayNow.getDayOfYear());
		System.out.println("lengthOfMonth(): " + todayNow.lengthOfMonth());
		System.out.println("lengthOfYear(): " + todayNow.lengthOfYear());
	}
}
