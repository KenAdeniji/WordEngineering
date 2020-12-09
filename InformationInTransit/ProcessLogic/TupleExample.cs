using System;

public static partial class TupleExample
{
    public static void Main(string[] argv)
    {
        var tupleTriple = new Tuple<int, string, double>(1, "Hello", 3.1415927);
        var t4 = Tuple.Create(42, 3.1415927, "Love", 'X');
        System.Console.WriteLine(tupleTriple.Item2);

        // for octuples and above, use Rest to retrieve nested tuple
        var t9 = new Tuple<int, int, int, int, int, int, int,
            Tuple<int, int>>(1, 2, 3, 4, 5, 6, 7, Tuple.Create(8, 9));
        Console.WriteLine("The 8th item is {0}", t9.Rest.Item1);
    }
}