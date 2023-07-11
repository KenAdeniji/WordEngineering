/*
	Source: http://www.dummies.com/go/javaaiofd7e
	Learning Made Easy 7th Edition Java All-In-One for dummies A Wiley brand 8 books in one! Doug Lowe Wrote his first program on a computer with than 1K of memory
	Date created: 2023-07-11T13:58:00 ... 2023-07-11T14:16:00
*/

import javax.swing.JOptionPane;

public class JOptionPaneTestamentsCount
{
	static final int TestamentsCount = 2;
	
	public static void main(String[] args)
	{
		stub();
	}
	
	public static void stub()
	{
		queryTestamentsCount();
	}
	
	public static void queryTestamentsCount()
	{
		String testamentsCount = 
			JOptionPane.showInputDialog
			(
				"How many Testaments are there in the Bible?"
			);
		System.out.println
		(
			Integer.parseInt
			(
				testamentsCount
			) 
			== TestamentsCount
			? "Correct"
			: "Wrong"
		);
	}
}
