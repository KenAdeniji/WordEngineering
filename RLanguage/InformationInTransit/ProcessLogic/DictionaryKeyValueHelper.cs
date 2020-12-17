using System;
using System.Collections.Generic;
using System.Threading;

/*
namespace InformationInTransit.ProcessLogic
{
	/*
		2017-04-21	Created.	apress.com/us/book/9781484213339
	*/
	/*
	public static partial class DictionaryKeyValueHelper
	{
		public static void Main(string[] argv)
		{
			Stub();
		}

		public static void PopulateUsingTheAddMethod()
		{
			Dictionary<string, Man> manPopulateAddMethod = new Dictionary<string, Man>();
			manPopulateAddMethod.Add( "Adam", new Man{ Name = "Adam", YearsLived = 930 } );
			
			Man adam = manPopulateAddMethod["Adam"];
			System.Console.WriteLine(adam);
		}

		public static void PopulateUsingTheInitializerSyntax()
		{
			Dictionary<string, Man> manPopulateInitializerSyntax = new Dictionary<string, Man>()
			{
				{ "Adam", new Man{ Name = "Adam", YearsLived = 930 } },
				{ "Eve", new Man{ Name = "Eve" } }
			};	
			
			Man eve = manPopulateInitializerSyntax["Eve"];
			System.Console.WriteLine(eve);
		}
		
		public static void PopulateUsingTheDictionaryInitializationSyntax()
		{
			Dictionary<string, Man> manPopulateDictionaryInitializationSyntax = new Dictionary<string, Man>()
			{
				new Man{ Name = "Adam", YearsLived = 930 },
				new Man{ Name = "Eve" },
				new Man{ Name = "Cain" } 
			};	
			
			Man cain = manPopulateDictionaryInitializationSyntax["Cain"];
			System.Console.WriteLine(cain);
		}
		
		public static void Stub()
		{
			PopulateUsingTheAddMethod();
			PopulateUsingTheInitializerSyntax();
			PopulateUsingTheDictionaryInitializationSyntax();
		}	
		
		public partial class Man
		{
			public string Name { get; set; }
			public int? YearsLived { get; set; }
			
			public override string ToString()
			{
				return String.Format
				(
					"Name: {0} | Years lived: {1}",
					Name, YearsLived
				);
			}	
		}
	}
}
*/