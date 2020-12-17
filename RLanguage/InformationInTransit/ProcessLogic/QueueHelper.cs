using System;
using System.Collections.Generic;

namespace InformationInTransit.ProcessLogic
{
	/*
		2017-04-21	Created.	apress.com/us/book/9781484213339
	*/
	public static partial class QueueHelper
	{
		public static void Main(string[] argv)
		{
			Stub();
		}

		public static void Stub()
		{
			Queue<Man> genealogy = new Queue<Man>();
			genealogy.Enqueue( new Man{ Name = "Adam", YearsLived = 930 } );
			genealogy.Enqueue( new Man{ Name = "Eve"} );
			genealogy.Enqueue( new Man{ Name = "Cain"} );
			genealogy.Enqueue( new Man{ Name = "Abel"} );
			genealogy.Enqueue( new Man{ Name = "Seth", YearsLived = 912 } );
			foreach(Man man in genealogy)
			{
				System.Console.WriteLine(man);
			}

			Man firstMan = genealogy.Peek();
			System.Console.WriteLine
			(
				"First Man: {0}",
				firstMan
			);
			
			genealogy.Dequeue();
			Man secondMan = genealogy.Peek();
			System.Console.WriteLine
			(
				"Second Man: {0}",
				secondMan
			);
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
