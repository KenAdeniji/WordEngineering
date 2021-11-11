using System;
using System.Collections.Generic;

namespace InformationInTransit.ProcessCode
{
	/*
		2021-11-10	Created.	
	*/
    public partial class GroupOfPeople
    {
		public List<Person> Persons;
		public List<Request> Requests;
		
		public partial class ChildOfJacob : GroupOfPeople
		{
			public ChildOfJacob()
			{
				Persons = new List<Person>
				{
					new Person{ Actor = "Judah", ScriptureReference = "Genesis 29:35, Genesis 37:26-28, Genesis 38" },
					new Person{ Actor = "Joseph", ScriptureReference = "Genesis 30:24, Genesis 37,  Genesis 39-50" }
				};	

				Requests = new List<Request>
				{
					new Request{ Title = "Send Benjamin on the second journey to Egypt", ScriptureReference = "Genesis 43" }
				};	
			}	
		}

		public partial class Apostle : GroupOfPeople
		{
			public Apostle()
			{
				Persons = new List<Person>
				{
					new Person{ Actor = "Peter", ScriptureReference = "Matthew 16-23, John 21:15-17" },
					new Person{ Actor = "John", ScriptureReference = "John 19:26-27" }
				};	

				Requests = new List<Request>
				{
					new Request{ Title = "Teach us to pray", ScriptureReference = "Luke 11:1" },
					new Request{ Title = "Increase our faith", ScriptureReference = "Luke 17:5" }
				};	
			}	
		}
		
		public partial class Person
		{
			public string Actor { get; set; }
			public string ScriptureReference { get; set; }
		}
		
		public partial class Request
		{
			public string Title { get; set; }
			public string ScriptureReference { get; set; }
		}
    }
}
