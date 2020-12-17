using System;
using System.Collections.Generic;
using System.Linq;

namespace WordEngineering
{
	public static partial class SortSample
	{
		public static void Main(string[] argv)
		{
			Sankarsans.Sort(); 
			Sankarsans.ForEach(s => Console.WriteLine("Member " + s.FirstName + " | " + s.LastName));
			
			Sankarsans.Sort((x, y) => x.LastName.CompareTo(y.LastName));
			Sankarsans.ForEach(s => Console.WriteLine("Member " + s.LastName + ", " + s.FirstName));			
		}
		
		public static List<Sankarsan> Sankarsans = new List<Sankarsan>
		{
			new Sankarsan{ ID = 1, FirstName = "John", LastName = "Doe" }, 
            new Sankarsan{ ID = 3, FirstName = "Allan", LastName = "Jones" }, 
            new Sankarsan{ ID = 2, FirstName = "Martin", LastName = "Moe" }, 
            new Sankarsan{ ID = 4, FirstName = "Ludwig", LastName = "Issac" } 
		};

		public partial class Sankarsan : IComparable<Sankarsan> 
		{
			public int ID { get; set; } 
			public String FirstName { get; set; } 
			public String LastName { get; set; } 
			public DateTime DateOfJoining { get; set; }

			public int CompareTo(Sankarsan other) 
			{ 
				return this.ID.CompareTo(other.ID); 
			} 
		}
	}
}

