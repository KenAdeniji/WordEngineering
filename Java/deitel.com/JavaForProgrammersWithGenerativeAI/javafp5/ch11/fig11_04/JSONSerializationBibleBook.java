import com.fasterxml.jackson.databind.ObjectMapper;
import java.io.IOException;
import java.nio.file.Path;
import java.util.List;

record BibleBook
(
	int BookID,
	String BookTitle,
	int BookChapters
)
{}

/**
	http://github.com/pdeitel/JavaForProgrammers5e/blob/main/examples/ch11/fig11_04/CreateJSONFile.java
	http://github.com/FasterXML/Jackson
	http://javadoc.io/doc/com.fasterxml.jackson.core/jackson-core/latest
*/
public class JSONSerializationBibleBook
{
	public static void main(String[] args) 
	{
		List<BibleBook> pentateuch = List.of
		(
			new BibleBook(1, "Genesis", 50),
			new BibleBook(2, "Exodus", 40),
			new BibleBook(3, "Leviticus", 27),
			new BibleBook(4, "Numbers", 36),
			new BibleBook(5, "Deuteronomy", 34)
		);

		Path filePath = Path.of
		(
			System.getProperty("user.home"), 
			"Documents",
			"Pentateuch.json"
		);

		var mapper = new ObjectMapper();

		try
		{
			mapper.writeValue(filePath.toFile(), pentateuch);
			System.out.printf
			(
				"JSON file created at: %s%n", 
				filePath.toAbsolutePath()
			);
      } 
      catch (IOException e) 
	  {
			System.err.printf
			(
				"Error writing JSON file: %s%n",
				e.getMessage()
			);
      }
   }
}
