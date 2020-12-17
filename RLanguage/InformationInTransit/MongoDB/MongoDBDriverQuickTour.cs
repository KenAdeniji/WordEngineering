using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

using System.Threading.Tasks;

using MongoDB.Bson;
using MongoDB.Driver;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;

namespace InformationInTransit.MongoDB
{
	///<summary>
	/// 2018-04-21 	Created.
	///	2018-04-21	http://mongodb.github.io/mongo-csharp-driver/2.5/getting_started/quick_tour/
	///</summary>
	public partial class MongoDBDriverQuickTour
	{
		public static void Main(string[] argv)
		{
			//Stub();
			
			MongoDBHelper.SaveDataTableToCollection
			(
				MongoDBConnectionString,
				"Bible",
				"Scripture",
				SelectScripture()
			);
			
			MongoDBHelper.FindAllDocumentsInACollection
			(
				MongoDBConnectionString,
				"Bible",
				"Scripture"
			);
		}
		
		public static DataTable SelectScripture()
		{
			DataTable dataTable = (DataTable)DataCommand.DatabaseCommand
			(
				SelectScriptureStatement,
				CommandType.Text,
				DataCommand.ResultType.DataTable
			);
			
			return dataTable;
		}
		
		public static void Stub()
		{
			// To directly connect to a single MongoDB server
			// (this will not auto-discover the primary even if it's a member of a replica set)
			var client = new MongoClient();

			/*
			// or use a connection string
			var client = new MongoClient("mongodb://localhost:27017");

			// or, to connect to a replica set, with auto-discovery of the primary, supply a seed list of members
			var client = new MongoClient("mongodb://localhost:27017,localhost:27018,localhost:27019");		
			*/

			var database = client.GetDatabase("WordEngineering");

			var collection = database.GetCollection<BsonDocument>("BibleBook");
			
			/*
            foreach(BibleBook bibleBook in BibleBook.BibleBooks)
            {
				var document = new BsonDocument
				{
					{ "ID", bibleBook.Id },
					{ "Title", bibleBook.Title }
				};	
				collection.InsertOne(document);	
            }
			*/
			
			var count = collection.Count(new BsonDocument());
			
			var document = collection.Find(new BsonDocument()).FirstOrDefault();
			Console.WriteLine(document.ToString());
		}
		
		/*
			// To directly connect to a single MongoDB server
			// (this will not auto-discover the primary even if it's a member of a replica set)
			var client = new MongoClient();

			// or use a connection string
			var client = new MongoClient("mongodb://localhost:27017");

			// or, to connect to a replica set, with auto-discovery of the primary, supply a seed list of members
			var client = new MongoClient("mongodb://localhost:27017,localhost:27018,localhost:27019");		
		*/
		public const String	MongoDBConnectionString	= "";
		public const String SelectScriptureStatement = "SELECT bookId, chapterId, verseId, KingJamesVersion, AmericanStandardBible, YoungLiteralTranslation, testament, bookTitle, scriptureReference, chapterIdSequence, verseIdSequence, bibleReference FROM Bible..Scripture ORDER BY VerseIDSequence";
	}
}
