using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace WordEngineering
{
	public static partial class JavaScriptObjectNotationJsonHelper
	{
		public static void Main(string[] argv)
		{
			string sJSON = JsonToString(PiniDayanList);
			List<PiniDayan> piniDayanList = OSerializer.Deserialize<List<PiniDayan>>(sJSON);
			foreach(PiniDayan piniDayan in piniDayanList)
			{
				System.Console.WriteLine(piniDayan);
			}	
		}
		
		public static string JsonToString(object json)
		{
			string sJSON = OSerializer.Serialize(json);
			System.Console.WriteLine(sJSON);
			return sJSON;
		}
		
		public static List<PiniDayan> PiniDayanList = new List<PiniDayan>()
		{
			new PiniDayan { Name = "Pini", ID = "111", Age = "30" },
			new PiniDayan { Name = "Yaniv", ID = "Cohen", Age = "31" },
			new PiniDayan { Name = "Yoni", ID = "Biton", Age = "20" }
		};

		public static JavaScriptSerializer OSerializer = new JavaScriptSerializer();
		
		public class PiniDayan
		{
			public string Name { get; set; }
			public string Age { get; set; }
			public string ID { get; set; } 
			public override string ToString()
			{
				return Name + " | " + Age + " | " + ID;
			}
		}
	}
}
