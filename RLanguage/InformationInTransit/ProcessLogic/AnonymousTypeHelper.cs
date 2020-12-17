using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InformationInTransit.ProcessLogic
{
    public static partial class AnonymousTypeHelper
    {
        public static void Main(string[] argv)
        {
            foo();
        }

        public static void foo()
        {
            var user = AnonCast(GetUserTuple(), new { Name = default(string), Badges = default(int) });
            Console.WriteLine("Name: {0} Badges: {1}", user.Name, user.Badges);
        }

        public static object GetUserTuple()
        {
            return new { Name = "dp", Badges = 5 };
        }

        // Using the magic of Type Inference...
        public static T AnonCast<T>(object obj, T type)
        {
            return (T)obj;
        }
    }
}
