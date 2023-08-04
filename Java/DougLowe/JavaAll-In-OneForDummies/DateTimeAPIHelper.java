/*
	Source: http://www.dummies.com/go/javaaiofd7e
	Learning Made Easy 7th Edition Java All-In-One for dummies A Wiley brand 8 books in one! Doug Lowe Wrote his first program on a computer with than 1K of memory
	Date created: 2023-08-03T14:31:00 ... 
	2023-08-03T14:31:00 ... 2023-08-03T16:24:00 import java.time.*; 
	2023-08-03T16:43:00 Microsoft Windows start date is 1601-01-01.
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
		
		System.out.println("LocalDate: " + LocalDate.now());
		System.out.println("LocalDateTime: " + LocalDateTime.now());		
		System.out.println("LocalTime: " + LocalTime.now());
	}
}
