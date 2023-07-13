/*
	Source: http://www.dummies.com/go/javaaiofd7e
	Learning Made Easy 7th Edition Java All-In-One for dummies A Wiley brand 8 books in one! Doug Lowe Wrote his first program on a computer with than 1K of memory
	Date created: 2023-07-12T10:49:00 ... 2023-07-12T12:05:00
	Accessor Pattern: 
		2023-07-12T11:12:00	Methods for getFieldName() and setFieldName()
		2023-07-12T11:22:00	isFieldName() getFieldName() for boolean values
*/

public class BibleBook
{
	private int bookID;
	private String bookTitle;
	
	private static int instanceCount = 0;
	
	public static void main(String[] args)
	{
		stub();
	}
	
	public static void stub()
	{
		BibleBook genesis = new BibleBook(1, "Genesis");
		System.out.println(genesis);
	}
	
	public int getBookID()
	{
		return bookID;
	}
	
	public void setBookID(int bookID)
	{
		this.bookID = bookID;
	}

	public String getBookTitle()
	{
		return bookTitle;
	}
	
	public void setBookTitle(String bookTitle)
	{
		this.bookTitle = bookTitle;
	}

	//boolean get accessor
	public boolean isPentateuch()
	{
		return bookID <= 5 ? true : false;
	}
	
	//Constructor overloading
	public BibleBook()
	{
		this(-1, null);
	}	
	
	public BibleBook
	(
		int bookID,
		String bookTitle
	)
	{
		instanceCount++;
		this.bookID = bookID;
		this.bookTitle = bookTitle;
	}
	
	public String toString()
	{
		return ("ID " + bookID + " of " + instanceCount + " Title " + bookTitle);
	}
}
