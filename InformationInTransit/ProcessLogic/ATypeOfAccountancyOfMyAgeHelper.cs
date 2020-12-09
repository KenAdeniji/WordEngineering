using System;

using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;	
using System.Xml;
using System.Xml.Serialization;

/*
	2017-04-15	Created.	ATypeOfAccountancyOfMyAgeHelper.cs
	2017-04-15	http://stackoverflow.com/questions/24937955/regular-expression-for-datetimeformat-yyyy-mm-ddthhmmss-iso8601-format
*/
namespace InformationInTransit.ProcessLogic
{
    public partial class ATypeOfAccountancyOfMyAgeHelper
    {
        public static void Main(string[] argv)
        {
			Dictionary<ATypeOfAccountancyOfMyAgeHelper.CompositeKey, ATypeOfAccountancyOfMyAgeHelper.TypeAccountancy> myAge = 
				ATypeOfAccountancyOfMyAgeHelper.Query
			(
				DefaultAddress
			);
			System.Console.WriteLine(DefaultAddress);
			/*
			DataSet dataSet = ATypeOfAccountancyOfMyAgeHelper.TransformDictionaryDataset(myAge);
			string	json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
			System.Console.WriteLine(json);
			*/
        }

        public static string Stub()
        {
			return DefaultAddress;
        }
		
        public static Dictionary<CompositeKey, TypeAccountancy> Query
		(
			string	uri
		)
        {
			string[] uris = uri.Split( new string[] { Environment.NewLine }, StringSplitOptions.None  );
			DateTime matchValue;
			
			string content = null;
			
			Dictionary<CompositeKey, TypeAccountancy> myAge = new Dictionary<CompositeKey, TypeAccountancy>();
			CompositeKey compositeKey = null;
			TypeAccountancy typeAccountancy = null;
			
			bool validDate = false;
			bool found = false;
			
			try
			{
				foreach(string currentUrl in uris)
				{
					content = WebHelper.GetPageAsString(currentUrl);
					string pattern = "(19|20)[0-9][0-9]-(0[0-9]|1[0-2])-(0[1-9]|([12][0-9]|3[01]))T([01][0-9]|2[0-3]):[0-5][0-9]:[0-5][0-9]";
					MatchCollection matches = Regex.Matches(content, pattern);
					System.Console.WriteLine(matches.Count);
					
					foreach(Match match in matches)
					{
						System.Console.WriteLine(match);
						validDate = DateTime.TryParse(match.Value, out matchValue);
						if (validDate == false)
						{
							continue;
						}	
						compositeKey = new CompositeKey
						{
							Uri = currentUrl,
							Dated = matchValue.Date
						};
						found = myAge.TryGetValue(compositeKey, out typeAccountancy);
						System.Console.WriteLine
						(
							"Dated: {0} | found: {1} | count: {2}",
							matchValue,
							found,
							myAge.Count
						);
						if (!found)
						{ 
							typeAccountancy = new TypeAccountancy
							{
								CompositeKey = compositeKey,
								Occurrence = 1
							};
							myAge.Add(compositeKey, typeAccountancy);
						}
						else
						{
							++typeAccountancy.Occurrence;
						}			 			
					}	
				}
			}
			catch(Exception ex)
			{
				System.Console.WriteLine
				(
					"Exception: {0}",
					ex.Message
				);
			}	
			return myAge;	
        }

		public static DataSet TransformDictionaryDataset(Dictionary<CompositeKey, TypeAccountancy> myAge)
		{
			DataTable dataTable = new DataTable();
			dataTable.Clear();
			dataTable.Columns.Add("Uri");
			dataTable.Columns.Add("Dated", typeof(DateTime));
			dataTable.Columns.Add("Occurrence", typeof(Int64));
			
			foreach(KeyValuePair<CompositeKey, TypeAccountancy> entry in myAge)
			{
				// do something with entry.Value or entry.Key
				object[] o = 
				{ 
					entry.Key.Uri,
					entry.Key.Dated,
					entry.Value.Occurrence
				};
				System.Console.WriteLine
				(
					"Uri: {0} | Dated: {1} | Occurrence: {2}",
					entry.Key.Uri,
					entry.Key.Dated,
					entry.Value.Occurrence
				);
				dataTable.Rows.Add(o);
			}

			DataSet dataSet = new DataSet();
			dataSet.Tables.Add(dataTable);
			
			return dataSet;
		}
		
		public partial class CompositeKey
		{
			public string Uri { get; set; }
			public DateTime Dated { get; set; }
			
			public override int GetHashCode()
			{
				return Uri.ToString().GetHashCode() ^ Dated.ToString().GetHashCode();
			}
 
			public override bool Equals(object obj)
			{
				return true;
				if (obj is CompositeKey)
				{
					CompositeKey compositeKey = (CompositeKey)obj;
					return 
					(
						this.Uri.Equals(compositeKey.Uri, StringComparison.CurrentCultureIgnoreCase) 
						&& this.Dated.ToString().Equals(compositeKey.Dated.ToString(), StringComparison.CurrentCultureIgnoreCase)
					);
				}
				return false;
			}			
		}

		public partial class TypeAccountancy
		{
			public CompositeKey CompositeKey { get; set; }
			public long	Occurrence  { get; set; }
		}

		public static readonly string DefaultAddress = 
			@"http://e-comfort.ephraimtech.com/WordEngineering/WordUnion/2015-10-23DoctoralDissertation.html";
    }
}
