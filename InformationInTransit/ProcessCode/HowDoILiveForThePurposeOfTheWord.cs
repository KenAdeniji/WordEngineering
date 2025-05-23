using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.SqlServer.Server;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.Web;

using System.Data.Linq;
using System.Linq;

namespace InformationInTransit.ProcessCode
{
	/*
		2021-07-04	How do I live; for the purpose of the Word?
		2021-07-05	Created.
		2021-07-05T13:36:00 https://stackoverflow.com/questions/41757762/use-sql-like-operator-in-c-sharp-linq
	*/
    public partial class HowDoILiveForThePurposeOfTheWord
    {
		public static void Main(String[] argv)
		{
			Query(argv[0]);
		}

		public static List<HowDoILiveForThePurposeOfTheWord> Query(String question)
		{
			question = question.Trim().ToUpper();
			List<HowDoILiveForThePurposeOfTheWord> resultSet = 
				HowDoILiveForThePurposeOfTheWords
				.Where
				(
					x => 
					x.Named.ToUpper().Contains(question) ||
					x.Meaning.ToUpper().Contains(question) ||
					x.ScriptureReference.ToUpper().Contains(question) ||
					x.Namer.ToUpper().Contains(question) ||
					x.What.ToUpper().Contains(question) ||
					x.When.ToUpper().Contains(question) ||
					x.Where.ToUpper().Contains(question) ||
					x.Who.ToUpper().Contains(question)
				).ToList();
			return resultSet;	
		}
			
		public static readonly List<HowDoILiveForThePurposeOfTheWord> HowDoILiveForThePurposeOfTheWords = new List<HowDoILiveForThePurposeOfTheWord>
		{
			new HowDoILiveForThePurposeOfTheWord {Named="El Chaiyai",Meaning="The God of my Life.",ScriptureReference="Psalms 42:8",Namer="Psalmist",What="God",Who="God"},
			new HowDoILiveForThePurposeOfTheWord {Named="El Chanun",Meaning="The Gracious God.",ScriptureReference="Jonah 4:2",Namer="Jonah",What="God",Who="God"}
		};	
		
		public String Named {get; set;}
		public String Meaning {get; set;}
		public String ScriptureReference {get; set;}
		public String Namer {get; set;}
		public String What {get; set;}
		public String When {get; set;}
		public String Where {get; set;}
		public String Who {get; set;}
    }
}
