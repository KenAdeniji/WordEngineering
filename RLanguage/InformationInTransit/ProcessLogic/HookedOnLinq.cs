using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections.ObjectModel;
using System.Xml.Linq;

namespace InformationInTransit.ProcessLogic
{
    public static partial class HookedOnLinq
    {
        public static void Main(string[] argv)
        {
            Array();
            Sum();
            QueryContact();
            Group();
            Join();
            Summary();
            XmlContact();
            XmlContactIterate();
            LambdaExpression();
        }

        public static void Array()
        {
            int[] nums = new int[] { 0, 4, 2, 6, 3, 8, 3, 1 };

            var result = from n in nums
                         where n < 5
                         orderby n
                         select n;

            foreach (int i in result)
                Console.WriteLine(i);
        }

        public static void Sum()
        {
            int[] nums = new int[] { 0, 4, 2, 6, 3, 8, 3, 1 };

            int result = nums.Sum();
            Console.WriteLine("Sum {0}", result);
        }

        public static void QueryContact()
        {
            var q = from c in ListContact
                    where c.DateOfBirth.AddYears(35) > DateTime.Now
                    orderby c.DateOfBirth descending
                    select c.FirstName + " " + c.LastName +
                           " date of birth (DOB) " + c.DateOfBirth.ToString("dd-MMM-yyyy");

            foreach (string s in q)
                Console.WriteLine(s);
        }

        public static void Group()
        {
            var q = from c in ListContact
                    group c by c.State;

            foreach (var group in q)
            {
                Console.WriteLine("State: " + group.Key);
                foreach (Contact c in group)
                    Console.WriteLine("  {0} {1}", c.FirstName, c.LastName);
            }
        }

        public static void Join()
        {
            var q = from callLog in ListCallLog
            join contact in ListContact on callLog.Phone equals contact.Phone
            select new 
            {
                contact.FirstName, 
                contact.LastName, 
                callLog.Dated,
                callLog.Duration
            };
                    
            foreach(var call in q)
            Console.WriteLine
            (
                "{0} – {1} {2} ({3} minutes)",
                call.Dated.ToString("ddMMMyyyy HH:m"),
                call.FirstName,
                call.LastName,
                call.Duration
            );
        }

        public static void Summary()
        {
            var q = from call in ListCallLog
                    where call.Incoming == true
                    group call by call.Phone into g
                    join contact in ListContact on g.Key equals contact.Phone
                    orderby contact.FirstName, contact.LastName
                    select new
                    {
                        contact.FirstName,
                        contact.LastName,
                        Count = g.Count(),
                        Avg = g.Average(c => c.Duration),
                        Total = g.Sum(c => c.Duration)
                    };

            foreach (var call in q)
                Console.WriteLine
                (
                    "{0} {1} - Calls:{2}, Time:{3}mins, Avg:{4}mins",
                    call.FirstName,
                    call.LastName,
                    call.Count,
                    call.Total,
                    Math.Round(call.Avg, 2)
                );
        }

        public static void XmlContact()
        {
            XElement xml = new XElement("contacts",
                    new XElement("contact",
                        new XAttribute("contactId", "2"),
                        new XElement("firstName", "Barry"),
                        new XElement("lastName", "Gottshall")
                    ),
                    new XElement("contact",
                        new XAttribute("contactId", "3"),
                        new XElement("firstName", "Armando"),
                        new XElement("lastName", "Valdes")
                    )
                );
            Console.WriteLine(xml);
        }

        public static void XmlContactIterate()
        {
            XElement xml = new XElement("contacts",
                    from c in ListContact
                    orderby c.FirstName
                    select new XElement("contact",
                              new XAttribute("phone", c.Phone),
                              new XElement("firstName", c.FirstName),
                              new XElement("lastName", c.LastName))
                    );
            Console.WriteLine(xml);
        }

        public static List<Contact> ListContact = new List<Contact>
        {
            new Contact{ FirstName="Barney", LastName="Gottshall", DateOfBirth=new DateTime(1945,10,19), Phone="885 983 8858", State="CA"},
            new Contact{ FirstName="Armando", LastName="Valdes", DateOfBirth=new DateTime(1973,12,9), Phone="848 553 8487", State="WA"},
            new Contact{ FirstName="Adam", LastName="Gauwain", DateOfBirth=new DateTime(1959,10,3), Phone="115 999 1154", State="AK"},
            new Contact{ FirstName="Jeffery", LastName="Deane", DateOfBirth=new DateTime(1950,12,16), Phone="677 602 6774", State="CA"},
            new Contact{ FirstName="Collin", LastName="Zeeman", DateOfBirth=new DateTime(1935,2,10), Phone="603 303 6030", State="FL"},
            new Contact{ FirstName="Stewart", LastName="Kagel", DateOfBirth=new DateTime(1950,2,20), Phone="546 607 5462", State="WA"},
            new Contact{ FirstName="Chance", LastName="Lard", DateOfBirth=new DateTime(1951,10,21), Phone="278 918 2789", State="WA"},
            new Contact{ FirstName="Blaine", LastName="Reifsteck", DateOfBirth=new DateTime(1946,5,18), Phone="715 920 7157", State="TX"},
            new Contact{ FirstName="Mack", LastName="Kamph", DateOfBirth=new DateTime(1977,9,17), Phone="364 202 3644", State="TX"},
            new Contact{ FirstName="Ariel", LastName="Hazelgrove", DateOfBirth=new DateTime(1922,5,23), Phone="165 737 1656", State="OR"}
        };

        public class Contact
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime DateOfBirth { get; set; }
            public string Phone { get; set; }
            public string State { get; set; }
        }

        public static List<CallLog> ListCallLog = new List<CallLog>
        {
            new CallLog{Phone = "885 983 8858", Duration = 2, Incoming = true, Dated = new DateTime(2006,8,7,8,12,0)},
            new CallLog{Phone = "165 737 1656", Duration = 15, Incoming = true, Dated = new DateTime(2006,8,7,9,23,0)},
            new CallLog{Phone = "364 202 3644", Duration = 1, Incoming = false, Dated = new DateTime(2006,8,7,10,5,0)},
            new CallLog{Phone = "603 303 6030", Duration = 2, Incoming = false, Dated = new DateTime(2006,8,7,10,35,0)},
            new CallLog{Phone = "546 607 5462", Duration = 4, Incoming = true, Dated = new DateTime(2006,8,7,11,15,0)},
            new CallLog{Phone = "885 983 8858", Duration = 15, Incoming = false, Dated = new DateTime(2006,8,7,13,12,0)},
            new CallLog{Phone = "885 983 8858", Duration = 3, Incoming = true, Dated = new DateTime(2006,8,7,13,47,0)},
            new CallLog{Phone = "546 607 5462", Duration = 1, Incoming = false, Dated = new DateTime(2006,8,7,20,34,0)},
            new CallLog{Phone = "546 607 5462", Duration = 3, Incoming = false, Dated = new DateTime(2006,8,8,10,10,0)},
            new CallLog{Phone = "603 303 6030", Duration = 23, Incoming = false, Dated = new DateTime(2006,8,8,10,40,0)},
            new CallLog{Phone = "848 553 8487", Duration = 3, Incoming = false, Dated = new DateTime(2006,8,8,14,00,0)},
            new CallLog{Phone = "848 553 8487", Duration = 7, Incoming = true, Dated = new DateTime(2006,8,8,14,37,0)},
            new CallLog{Phone = "278 918 2789", Duration = 6, Incoming = true, Dated = new DateTime(2006,8,8,15,23,0)},
            new CallLog{Phone = "364 202 3644", Duration = 20, Incoming = true, Dated = new DateTime(2006,8,8,17,12,0)}
        };

        public class CallLog
        {
            public string Phone { get; set; }
            public int Duration { get; set; }
            public bool Incoming { get; set; }
            public DateTime Dated { get; set; }
        }

        public static void LambdaExpression()
        {
            int[] nums = new int[] { 0, 4, 2, 6, 3, 8, 3, 1 };

            var result = nums
             .Where(n => n < 5)
             .OrderBy(n => n)
             .Distinct();

            foreach (int i in result)
                Console.WriteLine(i);
        }
    }
}
