using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace InformationInTransit.ProcessLogic
{
    public static partial class LinqEssential
    {
        public static void Main(string[] argv)
        {
            TransformIntoXml();
        }

        public static readonly List<Instrument> Instruments = new List<Instrument>
        {
            new Instrument { InstrumentId = 1, Name = "Soprano Saxophone" },
            new Instrument { InstrumentId = 2, Name = "Tenor Saxophone" },
            new Instrument { InstrumentId = 3, Name = "Trumpet" },
            new Instrument { InstrumentId = 4, Name = "Keyboards" }
        };

        public static readonly List<Mountain> Mountains = new List<Mountain>() 
        {
            new Mountain { Name = "Rainier", Height = 4392, State = "WA" },
            new Mountain { Name = "Baker", Height = 3286, State = "WA" },
            new Mountain { Name = "Adams", Height = 3742, State = "WA" }
        };

        public static readonly List<Musician> People = new List<Musician>
        {
            new Musician { MusicianId = 1, Name = "Sonny Rollings" },
            new Musician { MusicianId = 2, Name = "Miles Davis"},
            new Musician { MusicianId = 3, Name = "John Coltrane" },
            new Musician { MusicianId = 4, Name = "Charlie Parker" },
            new Musician { MusicianId = 5, Name = "Bela Fleck" }
        };

        public static readonly List<Order> Orders = new List<Order>
        {
            new Order { OrderId = 1, MusicianId = 1, InstrumentId = 2 },
            new Order { OrderId = 2, MusicianId = 2, InstrumentId = 3 },
            new Order { OrderId = 3, MusicianId = 3, InstrumentId = 1 },
            new Order { OrderId = 4, MusicianId = 3, InstrumentId = 2 },
            new Order { OrderId = 5, MusicianId = 4, InstrumentId = 2 },
            new Order { OrderId = 6, MusicianId = 2, InstrumentId = 4 }
        };

        public class Instrument
        {
            public int InstrumentId { get; set; }
            public string Name { get; set; }
        }

        public class Mountain
        {
            public string Name { get; set; }
            public int Height { get; set; }
            public string State { get; set; }
        }

        public class Musician
        {
            public int MusicianId { get; set; }
            public string Name { get; set; }
        }

        public class Order
        {
            public int OrderId { get; set; }
            public int MusicianId { get; set; }
            public int InstrumentId { get; set; }
        }

        public static IEnumerable<string> LinqQueryAdventure()
        {
            List<string> list = new
                List<string> { "LINQ", "query", "adventure" };

            IEnumerable<string> query = from rangeVariable in list
                        where rangeVariable.StartsWith("a")
                        select rangeVariable;
            ObjectDumper.Write(query);
            return query;
        }

        /*
         * The data source for this query is a C# reflection call to GetMethods on the
         * Enumerable type. The Enumerable type has only one purpose: it is the class 
         * that contains all the extension methods that define the LINQ to Objects 
         * operators. It also contains three simple utilities that support those 
         * operators. The call to GetMethods returns an array of the following type:
         * System.Reflection.MethodInfo[], where each MethodInfo object defines one 
         * LINQ operator or utility.
         * The code contains a where clause that strips out all the methods not declared
         * in the Enumerable class:
         * The only line remaining in this query is the last one: the group-by clause. 
         * LINQ uses group-by clauses to arrange elements into a set of keys, and a set
         * of elements that belong to the keys. The type returned by a call to group-by
         * is of System.Linq.IGrouping<TKey, TElement>.
         * To understand how this works, let's begin by examining the problem the 
         * group-by operator solves in this query. There are 47 different LINQ query 
         * operators. Some of these operators are overloaded many times. For instance, 
         * there are 22 overloads of the Min and Max operators. Printing out the same 
         * word 22 times can be confusing. To help bring some organization to our query
         * result, the group-by operator allows us to organize these 22 repeated return 
         * values into a single group.
        */
        public static IEnumerable<System.Linq.IGrouping<string, System.Reflection.MethodInfo>> GroupBy()
        {
            IEnumerable <System.Linq.IGrouping<string, System.Reflection.MethodInfo>> query = from method in typeof(System.Linq.Enumerable).GetMethods()
                        where method.DeclaringType == typeof(Enumerable)
                        orderby method.Name
                        group method by method.Name;

            foreach (System.Linq.IGrouping<string, System.Reflection.MethodInfo> item in query)
            {
                Console.WriteLine(item.Key);
            }
            return query;
        }

        public static void GroupByInto()
        {
            var query = from method in typeof(System.Linq.Enumerable).GetMethods()
                        where method.DeclaringType == typeof(Enumerable)
                        orderby method.Name
                        group method by method.Name into g
                        select new { Name = g.Key, Overloads = g.Count() };
            foreach (var groupBy in query)
            {
                System.Console.WriteLine
                (
                    "{{Name: {0}, Overloads: {1}}}",
                    groupBy.Name,
                    groupBy.Overloads
                );
            }
        }

        public static void Let()
        {
            var query = from method in typeof(System.Linq.Enumerable).GetMethods()
                        let theType = typeof(Enumerable)
                        where method.DeclaringType == theType
                        orderby method.Name
                        group method by theType + "." + method.Name;
        }

        public static void InnerJoin()
        {
            var query = from p in People
                        join o in Orders on p.MusicianId equals o.MusicianId
                        join i in Instruments on o.InstrumentId equals i.InstrumentId
                        orderby p.Name, o.OrderId descending
                        select new 
                        { 
                            Musician = p.Name,
                            OrderId = o.OrderId,
                            Instrument = i.Name
                        };
            ObjectDumper.Write(query);
        }

        public static void GroupJoin()
        {
            var query = from p in People
                        join o in Orders on p.MusicianId equals o.MusicianId
                           into orderGroups
                        select new { Musician = p.Name, Orders = orderGroups };
            foreach (var items in query)
            {
                Console.WriteLine(items.Musician);
                foreach (var item in items.Orders)
                {
                    Console.WriteLine("..OrderId: {0}", item.OrderId);
                }
            }
        }

        public static void OrderGroup()
        {
            var query = from p in People
                         join o in Orders on p.MusicianId equals o.MusicianId
                            into orderGroups
                         select new
                         {
                             Musician = p.Name,
                             Orders = from o in orderGroups
                                      join i in Instruments on o.InstrumentId
                                         equals i.InstrumentId
                                      select i.Name
                         };
            foreach (var items in query)
            {
                Console.WriteLine(items.Musician);
                foreach (var item in items.Orders)
                {
                    Console.WriteLine("..{0}", item);
                }
            }
        }

        public static void OuterJoin()
        {
            var query0 = from o in Orders
                         join i in Instruments
                            on o.InstrumentId equals i.InstrumentId
                         select new { o.OrderId, o.MusicianId, i.Name };

            var query = from p in People
                        join o in query0
                            on p.MusicianId equals o.MusicianId into m
                        from x in m.DefaultIfEmpty()
                        select new { p, x };

            foreach (var items in query)
            {
                Console.WriteLine("{0} {1}", items.p.Name, items.x);
            }
        }

        public static void TransformIntoXml()
        {
            var query = new
            XElement("Mountains",
                from mountain in Mountains
                orderby mountain.Name
                where mountain.Name.EndsWith("r")
                select new
            XElement("Mountain",
                   new
            XAttribute("Name", mountain.Name),
                   new
            XAttribute("Height", mountain.Height)));
        }
    }
}
 