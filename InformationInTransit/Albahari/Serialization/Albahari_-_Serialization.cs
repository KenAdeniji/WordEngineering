using System;
using System.IO;

using System.Runtime.Serialization;
using System.Xml.Serialization;
//using System.Text.Json;

using System.Collections.Generic;

/*
	2021-05-05T12:30:00 http://www.albahari.com/nutshell/cs9ian-supplement.pdf
*/
namespace Albahari.Serialization
{
	public class AlbahariSerialization
	{
		public static void Main(String[] argv)
		{
			Stub();
		}
		
		public static void Stub()
		{
			List<BibleBook> pentateuch = new List<BibleBook>
			{
				new BibleBook {ID = 1, Title = "Genesis"},
				new BibleBook {ID = 2, Title = "Exodus"},
				new BibleBook {ID = 3, Title = "Leviticus"},
				new BibleBook {ID = 4, Title = "Numbers"},
				new BibleBook {ID = 5, Title = "Deuteronomy"}				
			};
			
			var xs = new XmlSerializer (typeof (List<BibleBook>)); 
			
			using (Stream s = File.Create ("Albahari_-_BibleBook.xml"))
				xs.Serialize (s, pentateuch);
			
			List<BibleBook> theFiveBooksOfMoses;
			using (Stream s = File.OpenRead ("Albahari_-_BibleBook.xml"))   
				theFiveBooksOfMoses = (List<BibleBook>) xs.Deserialize (s);
			ObjectDumper.Write(theFiveBooksOfMoses);
		}	
	}
	
	[XmlRoot ("BibleBook", Namespace = "http://mynamespace/test")]
	public class BibleBook
	{
		[XmlAttribute ("ID")] public int ID {get; set;}
		[XmlElement ("Title",  Order = 1)] public string Title {get; set;}
	}	
}
