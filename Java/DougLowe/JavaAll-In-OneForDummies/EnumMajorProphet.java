/*
	Source: http://www.dummies.com/go/javaaiofd7e
	Learning Made Easy 7th Edition Java All-In-One for dummies A Wiley brand 8 books in one! Doug Lowe Wrote his first program on a computer with than 1K of memory
	Date created: 2023-07-11T16:16:00 ... 2023-07-11T16:41:00
	2023-07-11T16:41:00	http://stackoverflow.com/questions/1104975/a-for-loop-to-iterate-over-an-enum-in-java
*/

public class EnumMajorProphet
{
	public enum MajorProphet
	{
		Isaiah,
		Jeremiah,
		Ezekiel,
		Daniel
	}	
	
	public static void main(String[] args)
	{
		stub();
	}
	
	public static void stub()
	{
		queryMajorProphetIteration();
	}
	
	public static void queryMajorProphetIteration()
	{
		for (MajorProphet majorProphet : MajorProphet.values())
		{		
			System.out.println(majorProphet);
		}	
	}
}
