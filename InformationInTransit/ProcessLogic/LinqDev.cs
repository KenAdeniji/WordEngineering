using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Linq;
using System.Xml.Linq;

namespace InformationInTransit.ProcessLogic
{
    public static partial class LinqDev
    {
        public static void Main(string[] argv)
        {
            WhereOrderBy();
        }

        public static void HelloLinq()
        {
            string[] greetings = { "hello world", "hello LINQ", "hello Apress" };
            var items =
            from s in greetings
            where s.EndsWith("LINQ")
            select s;
            foreach (var item in items)
                Console.WriteLine(item);
        }

        public static void XmlQueryUsingLinqToXml()
        {
            XElement books = XElement.Parse(
            @"<books>
                <book>
                    <title>Pro LINQ: Language Integrated Query in C# 2008</title>
                    <author>Joe Rattz</author>
                </book>
                <book>
                    <title>Pro WF: Windows Workflow in .NET 3.0</title>
                    <author>Bruce Bukovics</author>
                </book>
                <book>
                    <title>Pro C# 2005 and the .NET 2.0 Platform, Third Edition</title>
                    <author>Andrew Troelsen</author>
                </book>
            </books>");

            var titles =
                from book in books.Elements("book")
                where (string)book.Element("author") == "Joe Rattz"
                select book.Element("title");

            foreach (var title in titles)
                Console.WriteLine(title.Value);
        }

        public static void DatabaseQueryUsingLinqToSql()
        {
            /*
            Northwind db = new Northwind(@"Data Source=(local);Initial Catalog=NorthWind;Persist Security Info=True;Integrated Security=SSPI");
            var custs =
            from c in db.Customers
            where c.City == "Rio de Janeiro"
            select c;
            foreach (var cust in custs)
                Console.WriteLine("{0}", cust.CompanyName);
           */ 
        }

        public static void ConvertArrayOfStringsToIntegers()
        {
            string[] numbers = { "0042", "010", "9", "27" };
            int[] nums = numbers.Select(s => Int32.Parse(s)).OrderBy(s => s).ToArray();
            ObjectDumper.Write(nums);
        }

        public static void WhereOrderBy()
        {
            int[] nums = new int[] { 6, 2, 7, 1, 9, 3 };
            IEnumerable<int> numsLessThanFour = nums
            .Where(i => i < 4)
            .OrderBy(i => i);
            ObjectDumper.Write(numsLessThanFour);
        }
    }
}
