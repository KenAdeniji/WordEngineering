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
using System.Text.RegularExpressions;

using InformationInTransit.ProcessLogic;

using Newtonsoft.Json;

namespace InformationInTransit.ProcessLogic
{
	/*
		2016-09-26 	Created.	DictionaryQueryHelper.cs	http://www.codemag.com/Article/1609041
		2016-09-28	http://www.newtonsoft.com/json/help/html/CreateJsonSchemaManually.htm
		2016-09-28	http://stackoverflow.com/questions/15184153/unable-to-cast-object-of-type-whereselectlistiterator
	*/
	public partial class DictionaryQueryHelper
	{
		public static void Main(string[] argv)
		{
			string serializedPersonAndAnAddress = PersonAndAnAddressSerialize();
			//System.Console.WriteLine(serializedPersonAndAnAddress);
			
			PersonAndAnAddress deserializedPersonAndAnAddress = PersonAndAnAddressDeserialize();
			//System.Console.WriteLine(deserializedPersonAndAnAddress);
			
			List<PersonAndAnAddress> people = PersonAndAnAddressQuery(johnSmithAndJaneDoe);
			
			foreach (PersonAndAnAddress personAndAnAddress in people)
			{
				System.Console.WriteLine(personAndAnAddress);	
			}		
		}

		public static PersonAndAnAddress PersonAndAnAddressDeserialize()
		{
			PersonAndAnAddress deserializedPersonAndAnAddress = JsonConvert.DeserializeObject<PersonAndAnAddress>(johnSmith);
			return deserializedPersonAndAnAddress;
		}

		public static List<PersonAndAnAddress> PersonAndAnAddressListDeserialize(string json)
		{
			List<PersonAndAnAddress> deserializedPeople = 
				JsonConvert.DeserializeObject<List<PersonAndAnAddress>>(json);
			return deserializedPeople;
		}
		
		public static List<PersonAndAnAddress> PersonAndAnAddressQuery(string json)
		{
			List<PersonAndAnAddress> people = (List<PersonAndAnAddress>) PersonAndAnAddressListDeserialize(json);
			return PersonAndAnAddressQuery(people);
		}

		public static List<PersonAndAnAddress> PersonAndAnAddressQuery(List<PersonAndAnAddress> people)
		{
			List<PersonAndAnAddress> result = (people.AsQueryable().Where(x => x.DateOfBirth <= DateTime.Parse("1974-07-01"))).ToList();	
			return result;	
		}
		
		public static string PersonAndAnAddressSerialize()
		{
			var person = new Dictionary<string, object>();
			person["FirstName"] = "John";
			person["LastName"] = "Smith";
			person["DateOfBirth"] = DateTime.Parse("01/01/1970");
			person["Active"] = true;
			person["Donations"] = 1500d;
			var address = new Dictionary<string, object>();
			address["Number"] = "1234";
			address["Street"] = "Market Street";
			address["City"] = "Philadelphia";
			address["State"] = "PA";
			address["ZipCode"] = "19101";
			person["Address"] = address;

			string json = JsonConvert.SerializeObject(person, Formatting.Indented);

			return json;
		}
		
		public class PersonAndAnAddress 
		{
			public 	bool 		Active 			{get; set;}
			public 	DateTime 	DateOfBirth 	{get; set;}
			public 	decimal 	Donations 		{get; set;}
			public 	string 		FirstName 		{get; set;}
			public 	string 		LastName 		{get; set;}
			
			public	Address 	Address			{get; set;}
			
			public override string ToString()
			{
				string formattedString = String.Format
				(
					FormattedString,
					Active,
					DateOfBirth,
					Donations,
					FirstName,
					LastName,
					Address
				);	
				return formattedString;
			}	
			
			public const string FormattedString = 
				@"Active: {0} Date of Birth: {1} Donations: {2} First name: {3} Last name: {4} Address: {5}";
		}

		public class Address 
		{
			public	string Street	{get; set;}
			public	string City		{get; set;}
			public	string State	{get; set;}
			public	string ZipCode	{get; set;}
			
			public override string ToString()
			{
				string formattedString = String.Format
				(
					FormattedString,
					Street,
					City,
					State,
					ZipCode
				);	
				return formattedString;
			}	
			
			public const string FormattedString = @"Street: {0} City: {1} State: {2} ZipCode: {3}";
		}
		
		public const string johnSmith = 
			@"{
				'FirstName': 'John',
				'LastName': 'Smith',
				'DateOfBirth': '1970-01-01T00:00:00',
				'Active': true,
				'Donations': 1500.0,
				'Address': {
					'Number': '1234',
					'Street': 'Market Street',
					'City': 'Philadelphia',
					'State': 'PA',
					'ZipCode': '19101'
				}
			}"
		;	
		
		public const string johnSmithAndJaneDoe	=
		@"[
			{
				'FirstName': 'John',
				'LastName': 'Smith',
				'DateOfBirth': '1970-01-01T00:00:00',
				'Active': true,
				'Donations': 1500.0,
				'Address': {
					'Number': '1234',
					'Street': 'Market Street',
					'City': 'Philadelphia',
					'State': 'PA',
					'ZipCode': '19101'
				}
			}, 
			{
				'FirstName': 'Jane',
				'LastName': 'Doe',
				'DateOfBirth': '1975-01-01T00:00:00'
			}
		]";
		
	}
}
