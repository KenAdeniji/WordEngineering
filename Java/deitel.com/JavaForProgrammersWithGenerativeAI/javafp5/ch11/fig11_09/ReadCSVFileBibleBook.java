import com.fasterxml.jackson.databind.MappingIterator;
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
	http://github.com/pdeitel/JavaForProgrammers5e/blob/main/examples/ch11/fig11_09/ReadCSVFile.java
	http://github.com/FasterXML/Jackson
	http://javadoc.io/doc/com.fasterxml.jackson.core/jackson-core/latest
	Datasets in CSV (comma-separated values) file format:
		http://openml.org
		http://github.com/awesomedata/awesome-public-datasets
		http://vincentarelbundock.github.io/Rdatasets/articles/data.html
		http://catalog.data.gov/dataset/?res-format=CSV
*/
public class ReadCSVFileBibleBook
{
	public static void main(String[] args) throws IOException
	{
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
			MappingIterator<BibleBook> iterator = 
				mapper.readerFor(BibleBook.class)
					.with(schema)
					.readValues
					(
						filePath.toFile()
					);

			List<BibleBook> pentateuch = iterator.readAll();
			
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
				"Error writing CSV file: %s%n",
				e.getMessage()
			);
      }
   }
}
