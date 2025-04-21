/*
	2025-02-16T16:40:00...2025-02-16T17:00:00 javac compile error
		javac -d . BibleBook.java
		java w3schools.BibleBook
	2025-02-16T17:48:00 http://stackoverflow.com/questions/12670398/how-to-initialize-static-arraylistmyclass-in-one-line	
	2025-02-16T17:54:00 http://stackoverflow.com/questions/18410035/ways-to-iterate-over-a-list-in-java
*/
package w3schools;

import java.util.ArrayList;
import java.util.List;

public class BibleBook
{
	public static 	ArrayList<BibleBook> BibleBooks;
	private int 	bookID;
	private	String	bookTitle;
	
	public BibleBook
	(
		int		bookID,
		String	bookTitle
	)
	{
		this.bookID = bookID;
		this.bookTitle = bookTitle;
	}

	public String toString() 
	{
		return "ID: " + this.bookID + " Title: " + this.bookTitle;
	}

	public int getBookID()
	{
		return bookID;
	}	
	
	public void setBookID
	(
		int bookID
	)
	{
		this.bookID = bookID;
	}	

	public String getBookTitle()
	{
		return bookTitle;
	}	
	
	public void setBookTitle
	(
		String bookTitle
	)
	{
		this.bookTitle = bookTitle;
	}	

	public static void main(String... args)
	{
		/*
		for (BibleBook element : BibleBooks)
		{
			System.out.println(element.toString());
		}
		*/
		BibleBooks.forEach(System.out::println);
	}
	
	static
	{
		BibleBooks = new ArrayList<BibleBook>()
		{
			{
				add( new BibleBook(1, "Genesis") );
				add( new BibleBook(2, "Exodus") );
			}
		};
	}	
}	