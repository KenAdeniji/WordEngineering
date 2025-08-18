import com.fasterxml.jackson.databind.ObjectWriter;
import com.fasterxml.jackson.dataformat.csv.CsvMapper;
import com.fasterxml.jackson.dataformat.csv.CsvSchema;
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
	http://github.com/pdeitel/JavaForProgrammers5e/blob/main/examples/ch11/fig11_08/CreateCSVFile.java
	http://github.com/FasterXML/Jackson
	http://javadoc.io/doc/com.fasterxml.jackson.core/jackson-core/latest
	Datasets in CSV (comma-separated values) file format:
		http://openml.org
		http://github.com/awesomedata/awesome-public-datasets
		http://vincentarelbundock.github.io/Rdatasets/articles/data.html
		http://catalog.data.gov/dataset/?res-format=CSV
*/
public class CreateCSVFileBibleBook
{
	public static void main(String[] args) throws IOException
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
			"Pentateuch.csv"
		);

		var mapper = new CsvMapper();
		CsvSchema schema = mapper
			.schemaFor(BibleBook.class)
			.withHeader()
		;					

		try
		{
			ObjectWriter writer = mapper.writer(schema);

			writer.writeValue
			(
				filePath.toFile(),
				pentateuch
			);
			System.out.printf
			(
				"CSV file created at: %s%n", 
				filePath.toAbsolutePath()
			);
      } 
      catch (IOException e) 
	  {
			System.err.printf
			(
				"Error writing CSV file: %s%n",
				e.getMessage()
			);
      }
   }
}
