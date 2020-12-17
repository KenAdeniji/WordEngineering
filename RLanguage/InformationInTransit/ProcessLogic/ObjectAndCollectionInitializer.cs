using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InformationInTransit.ProcessLogic
{
    public partial class ObjectAndCollectionInitializer
    {
        Person PersonInfo = new Person { FirstName = "Paulo", LastName = "Morgado" };

        List<Person> Persons = new List<Person> 
        {
            new Person { FirstName = "Paulo", LastName = "Morgado" },
            new Person { FirstName = "Luís", LastName = "Abreu" }
        };

        Dictionary<string, Person> PersonDirectory = new Dictionary<string, Person>
        {
            { "Lisboa", new Person { FirstName = "Paulo", LastName = "Morgado" } },
            { "Funchal", new Person { FirstName = "Luís", LastName = "Abreu" } }
        };

        class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
}
