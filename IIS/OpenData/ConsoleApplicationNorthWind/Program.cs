using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplicationNorthWind
{
    //DataSvcUtil
    using ServiceReference1;
    
    class Program
    {
        static void Main(string[] args)
        {
            NorthwindEntities svc = new NorthwindEntities(new Uri("http://localhost:6232/NorthWindWcfDataService.svc"));

            foreach (Products_by_Category c in svc.Products_by_Categories)
            {
                System.Console.WriteLine(c.ProductName);
                System.Console.WriteLine(c.CategoryName);
            }
        }
    }
}

