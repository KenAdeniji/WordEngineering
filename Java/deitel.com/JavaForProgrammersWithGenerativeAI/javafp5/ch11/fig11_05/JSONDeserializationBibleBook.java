import com.fasterxml.jackson.core.type.TypeReference;
import com.fasterxml.jackson.databind.ObjectMapper;
import java.io.IOException;
import java.nio.file.Path;
import java.util.List;

record BibleBook
(
	int ID,
	String Title,
	int Chapters
)
{}

/**
	http://github.com/pdeitel/JavaForProgrammers5e/blob/main/examples/ch11/fig11_05/ReadJSONFile.java
	http://github.com/FasterXML/Jackson
	http://javadoc.io/doc/com.fasterxml.jackson.core/jackson-core/latest
*/
public class JSONDeserializationBibleBook
{
	public static void main(String[] args) 
	{
		Path filePath = Path.of
		(
			System.getProperty("user.home"), 
			"Documents",
			"Pentateuch.json"
		);

		var mapper = new ObjectMapper();

		try
		{
			List<BibleBook> pentateuch = mapper.readValue
			(
				filePath.toFile(),
				new TypeReference<List<BibleBook>>(){}
			);
			System.out.printf
			(
				"%-5s %-15s %10s%n",
				"ID",
				"Title",
				"Chapters"
			);
			for(var bibleBook : pentateuch)
			{
				System.out.printf
				(
					"%-5d %-15s %10d%n",
					bibleBook.ID(),
					bibleBook.Title(),
					bibleBook.Chapters()
				);
			}		
      } 
      catch (IOException e) 
	  {
			System.err.printf
			(
				"Error reading JSON file: %s%n",
				e.getMessage()
			);
      }
   }
}
