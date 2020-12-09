using System;
using System.Linq;

public class LinqString
{
	public static void Main(string[] argv)
	{
		var query = from m in typeof(string).GetMethods()
            where m.IsStatic == true
            orderby m.Name
            group m by m.Name into g
            orderby g.Count()
            select new { Name = g.Key, Overloads = g.Count() };

		foreach (var item in query)
		{
			System.Console.WriteLine(item);
		}
	}
}	
