﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InformationInTransit.ProcessLogic
{
    /// <summary>
    /// http://code.msdn.microsoft.com/LINQ-Simple-Lambdas-e3640635/sourcecode?fileId=24064&pathId=1841004270
    /// </summary>
    class LinqLambdasBibleBook
    {
        public static void Main(string[] argv)
        {
            SampleTestamentGroupMinimumMaximumBookId();
        }

        public static void SampleLessThanEqualTo()
        {
            // use Where() to filter out elements matching a particular condition        
            var booksOfMoses = BibleBook.BibleBooks.Where(bibleBook => bibleBook.ID <= 5);

            Console.WriteLine("Id <= 5");
            ObjectDumper.Write(booksOfMoses);
        }

        public static void SampleFirst()
        {
            // use First() to find the one element matching a particular condition        
            BibleBook book = BibleBook.BibleBooks.First(bibleBook => bibleBook.Title[0] == 'O');

            Console.WriteLine("Title starting with 'o': {0}", book.Title);
        }

        public static void SampleAnonymousType()
        {
            var anonymousTypes = BibleBook.BibleBooks.Select
                                                    (
                                                        bibleBook => 
                                                        new
                                                        {
                                                            Head = bibleBook.Title.Substring(0, 1),
                                                            Tail = bibleBook.Title.Substring(1)
                                                        }
                                                    );
            foreach (var anonymousType in anonymousTypes)
            {
                Console.WriteLine("Head = {0}, Tail = {1}", anonymousType.Head, anonymousType.Tail);
            }
        }

        public static void SampleGroup()
        {
            var q = BibleBook.BibleBooks.GroupBy(bibleBook => bibleBook.Testament);

            foreach(var g in q) { 
                System.Console.WriteLine("Group: {0}", g.Key);
                ObjectDumper.Write(g);
            } 
        }

        public static void SampleGroupCount()
        {
            var q = BibleBook.BibleBooks.GroupBy(bibleBook => bibleBook.Testament).
                Select(g => new {Testament = g.Key, Count = g.Count() });

            foreach (var v in q)
            {
                System.Console.WriteLine
                (
                    "{0} testament count: {1}",
                    v.Testament,
                    v.Count
                );
            }
        }

        public static void SampleOrderBy()
        {
            var q = BibleBook.BibleBooks.OrderBy(bibleBook => bibleBook.Title);

            ObjectDumper.Write(q);
        }


        public static void SampleOrderByThenBy()
        {
            var q = BibleBook.BibleBooks.OrderBy(bibleBook => bibleBook.Testament).ThenBy(bibleBook => bibleBook.Title);

            ObjectDumper.Write(q);
        }

        public static void SampleExpressionGroupBy()
        {
            var bookGroups = from book in BibleBook.BibleBooks
                group book by book.Testament into bookGroup
                select new { Testament = bookGroup.Key, Books = bookGroup };

            foreach(var bookGroup in bookGroups)
            {
                Console.WriteLine("Testament: {0}", bookGroup.Testament);
                foreach(var book in bookGroup.Books)
                {
                    Console.WriteLine
                    (
                        "Book ID: {0} | Title: {1}",
                        book.ID,
                        book.Title
                    );
                }
            }
        }

        public static void SampleIndexLength()
        {
            var shortTitles = BibleBook.BibleBooks.Where((book, index) => book.Title.Length < index);

            Console.WriteLine("Short book's length:"); 
            foreach (var shortTitle in shortTitles) 
            { 
                Console.WriteLine("The word {0} is shorter than its index.", shortTitle.Title); 
            } 
        }

        public static void SampleCollectionIndex()
        {
            var index = from book in BibleBook.BibleBooks
                        select book.ID - 1;
            ObjectDumper.Write(index);
        }

        public static void SampleTitles()
        {
            var titles = from book in BibleBook.BibleBooks
                         select book.Title;
            ObjectDumper.Write(titles);
        }

        public static void SampleToUpperToLower()
        {
            var titles = from book in BibleBook.BibleBooks
                         select new { Upper = book.Title.ToUpper(), Lower = book.Title.ToLower() };
            ObjectDumper.Write(titles);
        }

        public static void SampleToFirstBookReverse()
        {
            var firstBook = (from book in BibleBook.BibleBooks
                         where book.Title[0] == '1'
                         select book).Reverse();
            ObjectDumper.Write(firstBook);
        }

        public static void SampleGroupByFirstLetter()
        {
            var bookGroups = from book in BibleBook.BibleBooks
                             group book by book.Title[0] into bookGroup
                             select new { titleFirstLetter = bookGroup.Key, Books = bookGroup };

            foreach (var bookGroup in bookGroups)
            {
                Console.WriteLine("Title's first letter: {0}", bookGroup.titleFirstLetter);
                foreach (var book in bookGroup.Books)
                {
                    Console.WriteLine
                    (
                        "Book ID: {0} | Title: {1}",
                        book.ID,
                        book.Title
                    );
                }
            }
        }

        public static void SampleGroupByTestament()
        {
            var bookGroups = from book in BibleBook.BibleBooks
                group book by book.Testament into bookGroup
                select new { Testament = bookGroup.Key, Books = bookGroup };

            ObjectDumper.Write(bookGroups, 1);
        }

        public static void SampleDistinctTestament()
        {
            var testaments = (from book in BibleBook.BibleBooks
                             select book.Testament).Distinct();
            ObjectDumper.Write(testaments);
        }

        /// <summary>
        /// This sample uses the Union method to create one sequence that contains the unique first letter
        ///     from both sources.
        /// </summary>
        public static void SampleUnionTitleFirstLetter()
        {
            var bookTitlesFirstLetter = OldTestamentBookTitleFirstLetter.Union(NewTestamentBookTitleFirstLetter);
            ObjectDumper.Write(bookTitlesFirstLetter);
        }

        /// <summary>
        /// This sample uses Intersect to create one sequence that contains the common values
        ///     shared by both arrays.
        /// </summary>
        public static void SampleIntersectTitleFirstLetter()
        {
            var bookTitlesFirstLetter = OldTestamentBookTitleFirstLetter.Intersect(NewTestamentBookTitleFirstLetter);
            ObjectDumper.Write(bookTitlesFirstLetter);
        }

        /// <summary>
        /// This sample uses Except to create a sequence that contains the values from setA
        ///     that are not also in setB.
        /// </summary>
        public static void SampleExceptTitleFirstLetter()
        {
            var bookTitlesFirstLetter = OldTestamentBookTitleFirstLetter.Except(NewTestamentBookTitleFirstLetter);
            ObjectDumper.Write(bookTitlesFirstLetter);
        }

        public static void SampleToArray()
        {
            var books = BibleBook.BibleBooks.ToArray();
            ObjectDumper.Write(books);
        }

        public static void SampleToList()
        {
            var books = BibleBook.BibleBooks.ToList();
            ObjectDumper.Write(books);
        }

        public static void SampleToDictionary()
        {
            var books = BibleBook.BibleBooks.ToDictionary(book => book.Title);
            ObjectDumper.Write(books["James"]);
        }

        public static void SampleFirstNewTestament()
        {
            var firstNewTestament = BibleBook.BibleBooks.Where(book => book.Testament == "New").First();
            ObjectDumper.Write(firstNewTestament);
        }

        public static void SampleFirstNewTestamentThirdBookInASeries()
        {
            var firstNewTestamentThirdBookInASeries = BibleBook.BibleBooks.Where(book => book.Testament == "New").First(book => book.Title[0] == '3');
            ObjectDumper.Write(firstNewTestamentThirdBookInASeries);
        }

        public static void SampleFirstOrDefaultOldTestamentThirdBookInASeries()
        {
            var firstOrDefault = BibleBook.BibleBooks.FirstOrDefault(book => book.Testament == "Old" && book.Title[0] == '3');
            ObjectDumper.Write(firstOrDefault);
        }

        public static void SampleFourthBookInTheNewTestament()
        {
            var fourthBookInTheNewTestament = BibleBook.BibleBooks.Where(book => book.Testament == "New").ElementAt(3);
            ObjectDumper.Write(fourthBookInTheNewTestament);
        }

        public static void SampleOddOrEven()
        {
            var sample = from book in BibleBook.BibleBooks
                         select new
                             {
                                 ID = book.ID,
                                 Testament = book.Testament,
                                 Title = book.Title,
                                 OddOrEven = book.ID % 2 == 1 ? "Odd" : "Even"
                             }; 
            ObjectDumper.Write(sample);
        }

        public static void SampleSeries()
        {
            bool series = BibleBook.BibleBooks.Any(book => book.Title[0] == '1');
            Console.WriteLine(series);
        }

        public static void SampleNoSeries()
        {
            bool series = BibleBook.BibleBooks.All(book => book.Title[0] != '1');
            Console.WriteLine(series);
        }

        public static void SampleCount()
        {
            int count = BibleBook.BibleBooks.Count(book => book.Testament == "New");
            Console.WriteLine(count);
        }

        public static void SampleTestamentGroupCount()
        {
            var testamentCounts =
                from book in BibleBook.BibleBooks
                group book by book.Testament into bookGroup
                select new {Testament = bookGroup.Key, bookCount = bookGroup.Count()};
            ObjectDumper.Write(testamentCounts);
        }


        public static void SampleSumTitleWordLength()
        {
            int sum = BibleBook.BibleBooks.Sum(book => book.Title.Length);
            Console.WriteLine(sum);
        }

        public static void SampleMinimumId()
        {
            int minimumID = BibleBook.BibleBooks.Min(book => book.ID);
            Console.WriteLine(minimumID);
        }

        public static void SampleMinimumBookTitleLength()
        {
            int minimumBookTitleLength = BibleBook.BibleBooks.Min(book => book.Title.Length);
            Console.WriteLine(minimumBookTitleLength);
        }

        public static void SampleTestamentGroupMinimumMaximumBookId()
        {
            var testaments =
                from book in BibleBook.BibleBooks
                group book by book.Testament into bookGroup
                select new
                { 
                    Testament = bookGroup.Key,
                    MinimumId = bookGroup.Min(book => book.ID),
                    MaximumId = bookGroup.Max(book => book.ID) 
                };

            ObjectDumper.Write(testaments);
        }

        static LinqLambdasBibleBook()
        {
            OldTestamentBookTitleFirstLetter = (from book in BibleBook.BibleBooks
                                                    where book.Testament == "Old"
                                                    select book.Title[0]).Distinct();

            NewTestamentBookTitleFirstLetter = (from book in BibleBook.BibleBooks
                                                    where book.Testament == "New"
                                                    select book.Title[0]).Distinct();
        }

        public static readonly IEnumerable<char> OldTestamentBookTitleFirstLetter;
        public static readonly IEnumerable<char> NewTestamentBookTitleFirstLetter;
    }
}
