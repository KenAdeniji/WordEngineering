/*
	Source: http://www.dummies.com/go/javaaiofd7e
	Learning Made Easy 7th Edition Java All-In-One for dummies A Wiley brand 8 books in one! Doug Lowe Wrote his first program on a computer with than 1K of memory
	Dated: 
		2023-07-16T07:50:00 ... 2023-07-16T08:02:00 Code.
		2023-07-16T08:02:00 speak() versus (VS) 2023-07-18T21:06:00 wordType()
*/

public class Man
{
	private String named;

	public Man(String named)
	{
		setNamed(named);
	}
	
	public String wordType()
	{
		return null;
	}	
	
	public String getNamed()
	{
		return named;
	}

	public void setNamed(String named)
	{
		this.named = named;
	}
	
	public static void main(String[] args)
	{
		stub();
	}
	
	public static void stub()
	{
		Prayer prayer = new Prayer("Abraham");
		System.out.println
		(
			prayer.wordType()
		);
		
		Prophet prophet = new Prophet("Moses");
		System.out.println
		(
			prophet.wordType()
		);
	}
}
