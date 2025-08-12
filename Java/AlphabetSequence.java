import java.io.*;
/**
	AlphabetSequence.
	2019-05-31 Created.
	2025-08-11T20:27:00...2025-08-11T20:42:00 Pure function.
*/
public class AlphabetSequence 
{
	public static void main(String args[]) 
	{
		for	( String arg : args ) 
		{
			System.out.format
			(
				"Word: %s AlphabetSequenceIndex: %d%n",
				arg,
				Index(arg)
			);
		}			
	}   

	public static long Index(String arg)
	{
		String upperCase = arg.toUpperCase();
		long alphabetSequenceIndex = 0;
		for(char character : upperCase.toCharArray()) 
		{
			if (character >= 'A' && character <= 'Z')
			{
				alphabetSequenceIndex += (int) character - 64;
			}			
		}
		return alphabetSequenceIndex;
	}   
}
