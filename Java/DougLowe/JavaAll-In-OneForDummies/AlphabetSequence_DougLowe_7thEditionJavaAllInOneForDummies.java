/*
	Source: http://www.dummies.com/go/javaaiofd7e
	Learning Made Easy 7th Edition Java All-In-One for dummies A Wiley brand 8 books in one! Doug Lowe Wrote his first program on a computer with than 1K of memory
	Lives in Fresno, California (CA).
	Wife is Kristen Gearhart.
	Date created: 2025-03-01T18:000:00
	Accessor Pattern: 
		2023-07-12T11:12:00	Methods for getFieldName() and setFieldName()
		2023-07-12T11:22:00	isFieldName() getFieldName() for boolean values
*/

import java.time.*;
import java.util.ArrayList;

public class AlphabetSequence_DougLowe_7thEditionJavaAllInOneForDummies
{
	private	String			word;
	private	LocalDateTime	dated;
	private	long 			alphabetSequenceIndex = -1;

	private static 	ArrayList<AlphabetSequence_DougLowe_7thEditionJavaAllInOneForDummies> AlphabetSequences;
	
	public static void main(String[] args)
	{
		stub();
	}
	
	public static void stub()
	{
		//System.out.println(AlphabetSequences);
		for
		(
			AlphabetSequence_DougLowe_7thEditionJavaAllInOneForDummies alphabetSequence:AlphabetSequences
		)
		{
			int i = AlphabetSequences.indexOf(alphabetSequence);
			System.out.println("Item " + i + ":" + alphabetSequence);	
		}		
	}
	
	public AlphabetSequence_DougLowe_7thEditionJavaAllInOneForDummies
	(
		String	word
	)
	{
		this.word = word;
		ComputeAlphabetSequenceIndex();
		this.dated = LocalDateTime.now();
	}

	public AlphabetSequence_DougLowe_7thEditionJavaAllInOneForDummies
	(
		String			word,
		LocalDateTime	dated
	)
	{
		//2025-03-01T20:50:00 flexible constructors.
		//this.dated = dated;
		this(word);
		this.dated = dated;
	}
	
	public String toString()
	{
		return ("word " + word + " dated " + dated);
	}

	public void ComputeAlphabetSequenceIndex()
	{
		String upperCase = word.toUpperCase();
		alphabetSequenceIndex = 0;
		for(char character : upperCase.toCharArray()) 
		{
			if (character >= 'A' && character <= 'Z')
			{
				alphabetSequenceIndex += (int) character - 64;
			}			
		}
	}	
	
	static
	{
		AlphabetSequences = new ArrayList<>() //Generics diamond operator
		{
			{
				add( new AlphabetSequence_DougLowe_7thEditionJavaAllInOneForDummies("Who do I use with the word?"));
				add( new AlphabetSequence_DougLowe_7thEditionJavaAllInOneForDummies("Who do I use with the word?", LocalDateTime.parse("2025-03-01T14:30:00")) );
			}
		};
	}	
}
