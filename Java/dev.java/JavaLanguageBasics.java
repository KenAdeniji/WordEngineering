import java.text.*;

public class JavaLanguageBasics
{
    public static void main(String... args) 
	{
		for (String s: Pentateuch_5BooksOfMoses)
		{
			if 
			(
				s.equals
				(
					Pentateuch_5BooksOfMoses
					[
						Genesis_1stBookOfMoses
					]
				)
			)
			{
				System.out.print
				(
					MessageFormat.format
					(
						IndexBookOfMoses,
						Genesis_1stBookOfMoses + 1
					)	
				); 
			}
			if 
			(
				s.equals
				(
					Pentateuch_5BooksOfMoses
					[
						Deuteronomy_5thAndLastBookOfMoses
					]
				)
			)
			{
				System.out.print
				(
					MessageFormat.format
					(
						IndexBookOfMoses,
						Deuteronomy_5thAndLastBookOfMoses + 1
					)	
				); 
			}
			System.out.println(s); 
		}
    }

	final static int Genesis_1stBookOfMoses = 0;	
	final static int Deuteronomy_5thAndLastBookOfMoses = 4;	

	final static String[] Pentateuch_5BooksOfMoses = 
	{
		"Genesis",
		"Exodus",
		"Leviticus",
		"Numbers",
		"Deuteronomy"
	};

	final static String IndexBookOfMoses = "Index Book of Moses [{0}]: ";
}


