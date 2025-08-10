//2025-08-08T19:23:00 http://www.google.com/books/edition/Java_for_Programmers/MqpJEQAAQBAJ?hl=en&gbpv=1
public class IterateCommandLineArguments
{
	/**
		Iterate Command-Line Arguments
	*/
	public static void main
	(
		String[] args
	)
	{
		if (args.length > 0)
		{
			int index = 0;
			for(String arg: args) 
			{
				System.out.printf("[%d] %s length:%d%n", index++, arg, arg.length());
			}	
		} 
		else 
		{
			System.out.println("No arguments passed!");
		}
	}	
}
