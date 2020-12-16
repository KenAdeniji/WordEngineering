using System;
using System.Linq;
using System.Data.Linq;

using nwind;

/*
	2018-11-04	Created.
	2018-11-04	SqlMetal /server:myserver /database:northwind /code:nwind.cs /namespace:nwind
*/
public static partial class QueryASQLServerDatabase
{
	public static void Main(String[] argv)
	{
		Stub();
	}

	public static void Stub()
	{
		Northwind db = new Northwind
		(
			DatabaseConnectionString
		);
		
		var custs =
			from c in db.Customers
			where c.City == "Rio de Janeiro"
			select c;
			
		foreach(var cust in custs)
		{
			System.Console.WriteLine
			(
				"{0}",
				cust.CompanyName
			);
		}
	}
	
	public const string DatabaseConnectionString =
		@"Data Source=(local);Initial Catalog=Northwind;Persist Security Info=True;Integrated Security=SSPI;Connect Timeout=600;Application Name=Northwind;MultipleActiveResultSets=True;";
}	
			