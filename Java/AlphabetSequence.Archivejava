/*
	2019-05-31	Created.
*/
import java.io.*;
public class AlphabetSequence {
	public static void main(String args[]) {
		for	( String arg : args ) {
			String upperCase = arg.toUpperCase();
			long alphabetSequenceIndex = 0;
			for(char character : upperCase.toCharArray()) {
				if (character >= 'A' && character <= 'Z')
				{
					alphabetSequenceIndex += (int) character - 64;
				}			
			}
			System.out.format("Word: %s AlphabetSequenceIndex: %d\n", arg, alphabetSequenceIndex);
		}			
	}   
}
