using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

using System.Text;

/*
	2018-08-17	https://goalkicker.com/CSharpBook/CSharpNotesForProfessionals.pdf
*/
namespace InformationInTransit.GoalKicker
{
	public static partial class CollectionInitializerGoalKicker
	{
		public static void Main(String[] argv)
		{
			var stringList = new List<string> {    "foo",    "bar", };

			//Note that the intialization is done atomically using a temporary variable, to avoid race conditions.
			var temp = new List<string>();
			temp.Add("foo");
			temp.Add("bar");
			stringList = temp;

			var numberDictionary = new Dictionary<int, string> 
			{    
				{ 1, "One" },    { 2, "Two" }, 
			};

			var tempDictionary = new Dictionary<int, string>();
			tempDictionary.Add(1, "One");
			tempDictionary.Add(2, "Two");
			var numberDictionarynumberDictionary = tempDictionary;
			
			var dict = new Dictionary<string, int> 
			{ 
				["key1"] = 1,
				["key2"] = 50
			};
			
		}	
	}
}
