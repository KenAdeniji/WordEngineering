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
						"Index Book of Moses [{0}]: ",
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
						"Index Book of Moses [{0}]: ",
						Deuteronomy_5thAndLastBookOfMoses + 1
					)	
				); 
			}
			System.out.println(s); 
		}
    }
	static String[] Pentateuch_5BooksOfMoses = {
		"Genesis",
		"Exodus",
		"Leviticus",
		"Numbers",
		"Deuteronomy"
	};
	static int Genesis_1stBookOfMoses = 0;	
	static int Deuteronomy_5thAndLastBookOfMoses = 4;	
}


