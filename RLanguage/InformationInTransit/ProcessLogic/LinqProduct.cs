using System;
using System.Collections.Generic;
using System.Linq;

public class LinqProduct
{
    public static void Main(string[] argv)
	{
        DeferredExecution();
	}

    public static void DeferredExecution()
    {
        // select all electronics, there are 7 of them
        IEnumerable<LinqProduct> electronicProducts = Products.Where(p => p.Category == "Electronics");

        // now clear the original list we queried
        Products.Clear();

        // now iterate over those electronics we selected first
        System.Console.WriteLine(electronicProducts.Count());
    }

    public static void DictionaryContainer()
    {
        var results = Products.ToDictionary(product => product.Id, product => product.Name);
    }

    public override string ToString()
    {
        return string.Format("[{0}: {1} - {2}]", Id, Category, Name);
    }

    public string Name { get; set; }
    public int Id { get; set; }
    public string Category { get; set; }

    static List<LinqProduct> Products = new List<LinqProduct>
	{
		new LinqProduct { Name = "CD Player", Id = 1, Category = "Electronics" },
		new LinqProduct { Name = "DVD Player", Id = 2, Category = "Electronics" },
		new LinqProduct { Name = "Blu-Ray Player", Id = 3, Category = "Electronics" },
		new LinqProduct { Name = "LCD TV", Id = 4, Category = "Electronics" },
		new LinqProduct { Name = "Wiper Fluid", Id = 5, Category = "Automotive" },
		new LinqProduct { Name = "LED TV", Id = 6, Category = "Electronics" },
		new LinqProduct { Name = "VHS Player", Id = 7, Category = "Electronics" },
		new LinqProduct { Name = "Mud Flaps", Id = 8, Category = "Automotive" },
		new LinqProduct { Name = "Plasma TV", Id = 9, Category = "Electronics" },
		new LinqProduct { Name = "Washer", Id = 10, Category = "Appliances" },
		new LinqProduct { Name = "Stove", Id = 11, Category = "Electronics" },
		new LinqProduct { Name = "Dryer", Id = 12, Category = "Electronics" },
		new LinqProduct { Name = "Cup Holder", Id = 13, Category = "Automotive" },
	};

}

   