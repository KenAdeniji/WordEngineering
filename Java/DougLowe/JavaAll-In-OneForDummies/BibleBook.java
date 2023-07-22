/*
	Source: http://www.dummies.com/go/javaaiofd7e
	Learning Made Easy 7th Edition Java All-In-One for dummies A Wiley brand 8 books in one! Doug Lowe Wrote his first program on a computer with than 1K of memory
	Date created: 2023-07-12T10:49:00 ... 2023-07-12T12:05:00
	Accessor Pattern: 
		2023-07-12T11:12:00	Methods for getFieldName() and setFieldName()
		2023-07-12T11:22:00	isFieldName() getFieldName() for boolean values
	2023-07-21T17:45:00	... 2023-07-21T18:02:00 genesis.equals(other)
		BibleBook genesis = new BibleBook(1, "Genesis");
		System.out.println(genesis);

		BibleBook other = new BibleBook(1, "genesis");
		System.out.println(other);
		
		if 
		(
			genesis.equals(other)
		)
		{
			System.out.println("These Bible books are the same.");
		}
		else
		{
			System.out.println("These Bible books are not the same.");
		}
		
*/

public class BibleBook implements Cloneable
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

		BibleBook other = new BibleBook(1, "genesis");
		System.out.println(other);
		
		if 
		(
			genesis.equals(other)
		)
		{
			System.out.println("These Bible books are the same.");
		}
		else
		{
			System.out.println("These Bible books are not the same.");
		}
		
		BibleBook cloned = (BibleBook) genesis.clone(); //2023-07-21T18:43:00 ... 2023-07-21T19:01:00 Shallow copy. All the fields are primitive types or immutable objects such as strings
		cloned.setBookID(-1);
		cloned.setBookTitle("Genesis cloned");
		System.out.println(genesis);
		System.out.println(cloned);
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

	/*
		BibleBook genesis = new BibleBook(1, "Genesis");
		BibleBook cloned = (BibleBook) genesis.clone(); //2023-07-21T18:43:00 ... 2023-07-21T19:01:00 Shallow copy. All the fields are primitive types or immutable objects such as strings
		cloned.setBookID(-1);
		cloned.setBookTitle("Genesis cloned");
		System.out.println(genesis);
		System.out.println(cloned);
	*/
	public Object clone()
	{
		BibleBook bibleBook;
		try
		{
			bibleBook = (BibleBook) super.clone();
		}
		catch(CloneNotSupportedException e)
		{
			return null; //Will never happen
		}
		return bibleBook;
	}	

	public boolean equals(Object obj)
	{
		//An object must equal itself
		if (this == obj)
		{
			return true;
		}
		
		//No object equals null
		if (obj == null)
		{
			return true;
		}

		//Objects of different types are nevel equal
		if (this.getClass() != obj.getClass())
		{
			return false;
		}
		
		//Cast to a BibleBook, then compare the fields
		BibleBook bibleBook = (BibleBook) obj;
		return
		(
				this.bookID == bibleBook.getBookID()
			&&	this.bookTitle.equalsIgnoreCase(bibleBook.getBookTitle())
		);
	}

	public String toString()
	{
		return(this.getClass().getName() + " ID " + bookID + " of " + instanceCount + " Title " + bookTitle);
	}
}
