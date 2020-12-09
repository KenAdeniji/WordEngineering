using System;
using System.Collections.Generic;
using System.Threading;

namespace InformationInTransit.ProcessLogic
{
	/*
		2017-04-21	Created.	apress.com/us/book/9781484213339
	*/
	public static partial class SortedSetHelper
	{
		public static void Main(string[] argv)
		{
			Stub();
		}

		public static void Stub()
		{
			SortedSet<Man> setOfMan = new SortedSet<Man>(new SortManByName())
			{
				new Man{ Name = "Adam", YearsLived = 930 },
				new Man{ Name = "Eve" },
				new Man{ Name = "Cain" },
				new Man{ Name = "Abel" },
				new Man{ Name = "Seth", YearsLived = 912 }
			};
			
			foreach(Man man in setOfMan)
			{
				System.Console.WriteLine(man);
			}
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

		public partial class SortManByName : IComparer<Man>
		{
			public int Compare(Man firstMan, Man secondMan)
			{
				return String.Compare
				(
					firstMan.Name,
					secondMan.Name,
					true,	//ignore case
					Thread.CurrentThread.CurrentCulture
				);
			}	
		}		
	}
}
