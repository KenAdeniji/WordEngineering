using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.XPath;

/*
2021-03-12T09:36:00 http://cnistorage.azureedge.net/procsharp/procsharp7_b02.pdf
2021-03-16T21:56:00	https://stackoverflow.com/questions/5005900/how-to-serialize-listt
*/

public partial class XMLReaderAndWriterSample
{
	public static void Main(String[] argv)
	{
		/*
		NavigateXml();
		ReadElementContent();
		ReadInteger();
		ReadTextNodes();
		ReadXml();
		SimpleNavigate();
		*/
		SerializeBook();
		/*
		SimpleNavigate();
		UseEvaluate();
		WriterSample();
		*/
	}

	public static void NavigateXml()
	{
		using (FileStream stream = File.OpenRead(BooksFileName))
		{    
			var doc = new XmlDocument();
			doc.Load(stream);
			XmlNodeList authorNodes = doc.GetElementsByTagName("author");
			foreach (XmlNode node in authorNodes)
			{ 
				Console.WriteLine($"Outer XML: {node.OuterXml}");
				Console.WriteLine($"Inner XML: {node.InnerXml}");
				Console.WriteLine($"Next sibling outer XML: " + $"{node.NextSibling.OuterXml}");
				Console.WriteLine($"Previous sibling outer XML: " + $"{node.PreviousSibling.OuterXml}");
				Console.WriteLine($"First child outer Xml: {node.FirstChild.OuterXml}");
				Console.WriteLine($"Parent name: {node.ParentNode.Name}"); 
				Console.WriteLine();
			}
		}
	}
	

	public static void ReadInteger()
	{  
		using (XmlReader reader = XmlReader.Create(BooksFileName))
		{    
			int	bookChaptersCurrent;
			int	bookChaptersCumulative = 0;
			
			while (reader.Read())
			{
				if (reader.NodeType == XmlNodeType.Element)
				{
					if (reader.Name == "chapters")
					{
						bookChaptersCurrent = reader.ReadElementContentAsInt(); 
						bookChaptersCumulative += bookChaptersCurrent;
						Console.WriteLine
						(
							$"Book Chapters Current: {bookChaptersCumulative} Cumulative: {bookChaptersCumulative}"
						);
					}
					else if (reader.Name == "title")
					{
						Console.WriteLine(reader.ReadElementContentAsString());
					}
					for (int i = 0; i < reader.AttributeCount; i++)
					{
						Console.WriteLine(reader.GetAttribute(i));
					}
				}
			}
		}
	}

	public static void ReadElementContent()
	{  
		using (XmlReader reader = XmlReader.Create(BooksFileName))
		{
			while (!reader.EOF)
			{
				if (reader.MoveToContent() == XmlNodeType.Element && reader.Name == "title")
				{ 
					Console.WriteLine(reader.ReadElementContentAsString());
				}
				else
				{
					// move on
					reader.Read();
				}
			}
		}
	}
	
	public static void ReadXml()
	{
		using (FileStream stream = File.OpenRead(BooksFileName))
		{
			var doc = new XmlDocument();
			doc.Load(stream);
			XmlNodeList titleNodes = doc.GetElementsByTagName("title");
			foreach (XmlNode node in titleNodes)
			{
				Console.WriteLine(node.OuterXml);
			}
		}
	}	
	
	public static void ReadTextNodes()
	{  
		using (XmlReader reader = XmlReader.Create(BooksFileName))
		{
			while (reader.Read())
			{
				if (reader.NodeType == XmlNodeType.Text)
				{
					Console.WriteLine(reader.Value);
				}
			}
		}
	}

	public static void SerializeBook()
	{
/*
		FileStream stream = File.OpenWrite(SerializeBooksFileName);
		using (TextWriter writer = new StreamWriter(stream))
		{
			XmlSerializer serializer = new XmlSerializer(typeof(Books));
			serializer.Serialize(writer, Books);
		}
*/		
		Serialization(Books, SerializeBooksFileName);
	}
	
	public static void SimpleNavigate()
	{
		//modify to match your path structure  
		var doc = new XPathDocument(BooksFileName);
		//create the XPath navigator  
		XPathNavigator nav = doc.CreateNavigator();
		//create the XPathNodeIterator of book nodes
		// that have genre attribute value of Apocalyptic
		XPathNodeIterator iterator = nav.Select("/bookstore/book[@genre='Apocalyptic']");
		while (iterator.MoveNext())
		{ 
			XPathNodeIterator newIterator = iterator.Current.SelectDescendants
			(    
				XPathNodeType.Element,
				matchSelf: false
			);
			while (newIterator.MoveNext())
			{
				Console.WriteLine($"{newIterator.Current.Name}: " + $"{newIterator.Current.Value}");
			}
		}
	}

	public static void UseEvaluate()
	{  
		//modify to match your path structure
		var doc = new XPathDocument(BooksFileName);
		//create the XPath navigator  
		XPathNavigator nav = doc.CreateNavigator();
		//create the XPathNodeIterator of book nodes
		XPathNodeIterator iterator = nav.Select("/bookstore/book");
		while (iterator.MoveNext())
		{
			if (iterator.Current.MoveToChild("title", string.Empty))
			{ 
				Console.WriteLine($"{iterator.Current.Name}: {iterator.Current.Value}");
			}
		}
		Console.WriteLine("=========================");  
		Console.WriteLine($"Count Books = " +     $"{nav.Evaluate("count(/bookstore/book)")}");
		Console.WriteLine($"Total Chapters = " +     $"{nav.Evaluate("sum(/bookstore/book/chapters)")}");
		Console.WriteLine($"Total Chapters = " +     Convert.ToDecimal($"{nav.Evaluate("sum(/bookstore/book/chapters)")}")/Convert.ToDecimal($"{nav.Evaluate("count(/bookstore/book/chapters)")}"));
	}
	
	public static void WriterSample()
	{  
		var settings = new XmlWriterSettings
		{
			Indent = true,
			NewLineOnAttributes = true,
			Encoding = Encoding.UTF8,
			WriteEndDocumentOnClose = true
		};
		
		StreamWriter stream = File.CreateText(NewBooksFileName);  
		using (XmlWriter writer = XmlWriter.Create(stream, settings))
		{    
			writer.WriteStartDocument();
			writer.WriteStartElement("bookstore");
			
			//Create elements and attributes - Genesis
			writer.WriteStartElement("book"); 
			writer.WriteAttributeString("genre", "Pentateuch");

			writer.WriteElementString("title", "Genesis");
			
			writer.WriteStartElement("id"); 
			writer.WriteValue(1);
			writer.WriteEndElement();
			
			writer.WriteElementString("author", "Moses");

			writer.WriteStartElement("chapters"); 
			writer.WriteValue(50);
			writer.WriteEndElement();
			
			writer.WriteEndElement();
			
			//Create elements and attributes - Revelation
			writer.WriteStartElement("book"); 
			writer.WriteAttributeString("genre", "Apocalyptic");

			writer.WriteElementString("title", "Revelation");
			
			writer.WriteStartElement("id"); 
			writer.WriteValue(66);
			writer.WriteEndElement();
			
			writer.WriteElementString("author", "Apostle John");

			writer.WriteStartElement("chapters"); 
			writer.WriteValue(22);
			writer.WriteEndElement();
			
			writer.WriteEndElement();
			
			writer.WriteEndElement();
			writer.WriteEndDocument();
		}
	}
	
    public IList<Object> Deserialize(string a_fileName)
    {
        XmlSerializer deserializer = new XmlSerializer(typeof(List<Object>));

        TextReader reader = new StreamReader(a_fileName);

        object obj = deserializer.Deserialize(reader);

        reader.Close();

        return (List<Object>)obj;
    }

    public static void Serialization(IList<Book> a_stations,string a_fileName)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Book>));

        using (var stream = File.OpenWrite(a_fileName))
        {
            serializer.Serialize(stream, a_stations);
        }
    }
	
	public const string BooksFileName = "2021-03-11ChristianNagel_-_BibleBook.xml";
	public const string NewBooksFileName = "2021-03-15ChristianNagel_-_BibleBookSample.xml";
	public const string SerializeBooksFileName = "2021-03-16ChristianNagel_-_BibleBookSerialize.xml";
	
	public static readonly List<Book> Books = new List<Book>
	{
		new Book { Genre = "Pentateuch", Title = "Genesis", ID = 1, Author = "Genesis", Chapters = 50 },
		new Book { Genre = "Apocalyptic", Title = "Revelation", ID = 66, Author = "Apostle John", Chapters = 22 }
	};	
	
	[Serializable]
	public class Book
	{
		[XmlAttribute(AttributeName = "genre")]
		public string Genre {get; set;}
		
		[XmlElement(ElementName = "title")]
		public string Title {get; set;}

		[XmlElement(ElementName = "id")]
		public int ID {get; set;}

		[XmlElement(ElementName = "author")]
		public string Author {get; set;}

		[XmlElement(ElementName = "chapters")]
		public int Chapters {get; set;}

		public override string ToString() =>    $"{Genre} {Title} {ID} {Author} {Chapters}";		
	}
}	
