using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InformationInTransit.ProcessLogic
{
    /// <summary>
    /// Constrained Types
    /// Base class constraint           where T : MyBaseClass
    /// Naked type constraint           class MyGenericClass <T, V> where V : T {}
    /// Interface constraint            where T : interface name
    /// new() constructor constraint    new()
    /// Reference type constraint       where T : class
    /// Value type constraint           where T : struct
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial class HerbSchildtGeneric<T>
    {
        T obj;

        public HerbSchildtGeneric(T obj)
        {
            this.obj = obj;
        }

        public T GetObj()
        {
            return obj;
        }
    }

    public partial class HerbSchildtGenericHelper
    {
        public static void Main(string[] argv)
        {
            HerbSchildtGeneric<int> myGeneric = new HerbSchildtGeneric<int>(88);
            System.Console.WriteLine(myGeneric.GetObj());
        }
    }
}
