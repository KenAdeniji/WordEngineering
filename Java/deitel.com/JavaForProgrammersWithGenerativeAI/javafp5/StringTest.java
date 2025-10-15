//2025-08-08T19:23:00 http://www.google.com/books/edition/Java_for_Programmers/MqpJEQAAQBAJ?hl=en&gbpv=1
public class StringTest
{
	/**
		Compare strings.
	*/
	public static void main
	(
		String[] args
	)
	{
		if (args.length > 0)
		{
			for(String arg: args) 
			{
				System.out.printf("%s length:%d%n", arg, arg.length());
			}	
		} 
		else 
		{
			System.out.println("No arguments passed!");
		}
	}	
}
