/*
	2022-04-23 Created.
	http://goalkicker.com/JavaBook/JavaNotesForProfessionals.pdf
	javac BibleBook.java
	java BibleBook
*/
public class BibleBook
{
	public static void main(String[] args)
	{
		BibleBook revelation = new BibleBook(66, "Revelation", "John");
		System.out.println(revelation.getTestament());
	}
	
	private int bookID;
	private String bookTitle;
	private String author;
	
	public BibleBook
	(
		int bookID,
		String bookTitle,
		String author
	)
	{
		this.bookID = bookID;
		this.bookTitle = bookTitle;
		this.author = author;
	}

	public int getBookID()
	{
		return this.bookID;	
	}	
	
	public String getBookTitle()
	{
		return this.bookTitle;	
	}	
	
	public String getAuthor()
	{
		return this.author;	
	}
	
	public String getTestament()
	{
		return this.bookID < 40 ? "Old" : "New";	
	}
}
	