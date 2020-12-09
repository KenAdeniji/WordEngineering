using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InformationInTransit.ProcessLogic
{
    public class Animal
    {
        public Func<string> Speak { get; set; }
        public Action Swim { get; set; }

        public static void Main(string[] argv)
        {
        }

        public static void Simulate()
        {
            var dog = new Animal
            {
                Speak = () => "Woof!",
                Swim = () => Console.WriteLine("Do the doggie paddle!")
            };

            var cat = new Animal
            {
                Speak = () => "Meow!",
                Swim = () => { throw new CantSwimException(); }
            };

            System.Console.WriteLine(dog.Speak());
            System.Console.WriteLine(cat.Speak());

            dog.Swim();

        }

        public class CantSwimException : Exception {}
        
    }
}
