using System;
using System.Collections.Generic;
using System.Linq;

public static partial class LinqQueryExpression
{
    // Specify the data source.
    public static readonly int[] Scores = new int[] { 97, 92, 81, 60 };

    public static readonly string[] Names = { "Svetlana Omelchenko", "Claire O'Donnell", "Sven Mortensen", "Cesar Garcia" };

    public static readonly List<int> Numbers = new List<int>() { 1, 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 };

    public static void Main()
	{
        IEnumerable<int> scores = ScoreQuery();
        HighScores();
        HighScoreCount();
        FirstNames();
        FactorsOfFour();
	}
	
    public static IEnumerable<int> ScoreQuery()
    {
        // Define the query expression.
        IEnumerable<int> scoreQuery =
            from score in Scores
            where score > 80
            select score;

        // Execute the query.
        foreach (int i in scoreQuery)
        {
            System.Console.Write(i + " ");
        }

        return scoreQuery;
    }

    public static IEnumerable<string> HighScores()
    {
        IEnumerable<string> highScoresQuery2 =
        from score in Scores
        where score > 80
        orderby score descending
        select String.Format("The score is {0}", score);

        foreach (string s in highScoresQuery2)
        {
            System.Console.Write(s + " ");
        }

        return highScoresQuery2;
    }

    public static int HighScoreCount()
    {
        int highScoreCount = (from score in Scores
            where score > 80
            select score)
            .Count();

        System.Console.WriteLine(highScoreCount);

        return highScoreCount;
    }

    public static IEnumerable<string> FirstNames()
    {
        IEnumerable<string> queryFirstNames =
        from name in Names
        let firstName = name.Split(new char[] { ' ' })[0]
        select firstName;

        foreach (string s in queryFirstNames)
            Console.Write(s + " ");

        return queryFirstNames;
    }

    public static IEnumerable<int> FactorsOfFour()
    {
        IEnumerable<int> queryFactorsOfFour =
            from num in Numbers
            where num % 4 == 0
            select num;

        foreach (int i in queryFactorsOfFour)
            Console.Write(i + " ");

        return queryFactorsOfFour;
    }
}
