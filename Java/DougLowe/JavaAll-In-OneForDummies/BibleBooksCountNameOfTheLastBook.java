/*
	Source: http://www.dummies.com/go/javaaiofd7e
	Date created: 2023-07-11T12:05:00 ... 2023-07-11T12:44:00
*/

import java.lang.String;
import java.util.Scanner;

public class BibleBooksCountNameOfTheLastBook
{
	static Scanner sc = new Scanner(System.in);
	
	static final int BooksCount = 66;
	static final boolean FirstBook = true;
	static final String LastBook = "Revelation";
	
	public static void main(String[] args)
	{
		stub();
	}
	
	public static void stub()
	{
		queryBooksCount();
		queryLastBook();
		queryFirstBook();
	}
	
	public static void queryBooksCount()
	{
		System.out.print("How many books are there in the Bible? ");
		int booksCount = sc.nextInt();
		System.out.println
		(
			booksCount == BooksCount
			? "Correct"
			: "Wrong"
		);
	}

	public static void queryFirstBook()
	{
		System.out.print("Is Genesis the first book in the Bible (true or false)? ");
		boolean firstBook = sc.nextBoolean();
		System.out.println
		(
			firstBook == FirstBook
			? "Correct"
			: "Wrong"
		);
	}
	
	public static void queryLastBook()
	{
		System.out.print("Which is the last book in the Bible? ");
		String lastBook = sc.nextLine();
		System.out.println
		(
			lastBook.equalsIgnoreCase(LastBook)
			? "Correct"
			: "Wrong"
		);
	}
}
