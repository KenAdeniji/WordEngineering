using System;

using System.Data.Entity;
using System.Data.EntityClient;
using System.Linq;

using System.Data.Metadata.Edm;
using SoughtOutModel;

/*
	2020-06-15	https://docs.microsoft.com/en-us/ef/ef6/querying
	2020-06-15	https://ptgmedia.pearsoncmg.com/images/9780735664166/samplepages/9780735664166.pdf
	2020-06-15	https://www.mssqltips.com/sqlservertip/6116/create-entity-data-model-using-a-database-first-approach/
	2020-06-15	https://docs.microsoft.com/en-us/previous-versions/dotnet/netframework-4.0/bb738546(v=vs.100)
*/

namespace SoughtOut
{
	public class EntityDataModelActor
	{
		public static void Main()
		{
			Stub();
		}
		
		public static void Stub()
		{
			using (var context = new SoughtOutEntities())
			{

				// Query for all the actors
				var actors = from b in context.Actors
							   where b.Name.StartsWith("")
							   select b;

				foreach(Actors actor in actors)
				{
					System.Console.WriteLine(actor.Name);
				}		

				// Query for God
				var god = context.Actors
								.Where(b => b.Name == "God")
								.FirstOrDefault();
				System.Console.WriteLine(god.Name);		
			
			}
		}
	}
}

