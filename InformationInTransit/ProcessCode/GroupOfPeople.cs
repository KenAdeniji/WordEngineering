using System;
using System.Collections.Generic;

namespace InformationInTransit.ProcessCode
{
	/*
		2021-11-10	Created.	
	*/
    public partial class GroupOfPeople
    {
		public List<Request> Requests;
		
		public partial class Apostle : GroupOfPeople
		{
			public Apostle()
			{
				Requests = new List<Request>
				{
					new Request{ Title = "Teach us to pray", ScriptureReference = "Luke 11:1" },
					new Request{ Title = "Increase our faith", ScriptureReference = "Luke 17:5" }
				};	
			}	
		}
		
		public partial class Request
		{
			public string Title { get; set; }
			public string ScriptureReference { get; set; }
		}
    }
}
