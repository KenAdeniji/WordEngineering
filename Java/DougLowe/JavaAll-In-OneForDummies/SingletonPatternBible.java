/*
	Source: http://www.dummies.com/go/javaaiofd7e
	Learning Made Easy 7th Edition Java All-In-One for dummies A Wiley brand 8 books in one! Doug Lowe Wrote his first program on a computer with than 1K of memory
	Date created: 2023-07-12T12:08:00 ... 2023-07-12T12:33:00
	2023-07-12T12:25:00	SingletonPatternBible firstBible = SingletonPatternBible.getInstance();
*/

public class SingletonPatternBible
{
	private static SingletonPatternBible instance;
	
	private SingletonPatternBible() {}
	
	public static SingletonPatternBible getInstance()
	{
		if (instance == null)
		{
			instance = new SingletonPatternBible();
		}
		return instance;
	}	
	
	public static void main(String[] args)
	{
		stub();
	}
	
	public static void stub()
	{
		SingletonPatternBible firstBible = SingletonPatternBible.getInstance();
		SingletonPatternBible secondBible = SingletonPatternBible.getInstance();
		
		System.out.println
		(
			firstBible == secondBible
			? "The objects are the same."
			: "The objects are not the same."
		);	
	}
}
