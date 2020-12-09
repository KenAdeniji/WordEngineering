using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using System.Data.Linq;
using System.Diagnostics;
using System.IO;
using System.Xml.Linq;

namespace InformationInTransit.ProcessLogic
{
    public partial class LinqExample
    {
        public static List<AddressInfo> AddressBook;

        public static void Main(string[] argv)
        {
            DisplayProcesses();
            //GenerateXmlDataFromListOfCustomers();
        }

        public static void AllSimple()
        {
           int[] numbers = { 1, 11, 3, 19, 41, 65, 19 };
           bool onlyOdd = numbers.All(n => n % 2 == 1);
           Console.WriteLine("The list contains only odd numbers: {0}", onlyOdd);
        }

        /*
        public static void AnyLambda()
        {
            int[] numbers = { -9, -4, -8, -3, -5, -2, -1, -6, -7 };

            bool negativeMatch = numbers.Any((n, index) => n == -index);

            Console.WriteLine("There is a number that is the negative of its index: {0}", negativeMatch);
        }
        */

        public static void AnySimple()
        {
            string[] words = { "believe", "relief", "receipt", "field" };

            bool iAfterE = words.Any(w => w.Contains("ei"));

            Console.WriteLine("There is a word that contains in the list that contains 'ei': {0}", iAfterE);
        }

        public static void Concat()
        {
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };

            var allNumbers = numbersA.Concat(numbersB);

            Console.WriteLine("All numbers from both arrays:");
            foreach (var n in allNumbers)
            {
                Console.WriteLine(n);
            }
        }

        public static void CountConditional()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            int oddNumbers = numbers.Count(n => n % 2 == 1);

            Console.WriteLine("There are {0} odd numbers in the list.", oddNumbers);
        }

        public static void CountSimple()
        {
            int[] factorsOf300 = { 2, 2, 3, 5, 5 };

            int uniqueFactors = factorsOf300.Distinct().Count();

            Console.WriteLine("There are {0} unique factors of 300.", uniqueFactors);
        }

        /// <summary>
        /// This sample uses an indexed Where clause to print the name of each number, from 0-9,
        /// where the length of the number's name is shorter than its value. In this case, the
        /// code is passing a lamda expression which is converted to the appropriate delegate type.
        /// The body of the lamda expression tests whether the length of the string is less than
        /// its index in the array.
        /// </summary>
        /// <see cref="http://msdn2.microsoft.com/en-us/vcsharp/aa336760.aspx#WhereSimple1"/>
        public static void DigitLengthValue()
        {
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var shortDigits = digits.Where((digit, index) => digit.Length < index);

            Console.WriteLine("Short digits:");
            foreach (var d in shortDigits)
            {
                Console.WriteLine("The word {0} is shorter than its value.", d);
            }
        }

        public static void DisplayProcesses()
        {
            /*
             * var processes =
                from process in Process.GetProcesses()
                where process.WorkingSet64 > 20*1024*1024
                orderby process.WorkingSet64 descending
                select new { process.Id, Name=process.ProcessName };
            */
            var processes =
            Process.GetProcesses()
            .Where(process => process.WorkingSet64 > 20 * 1024 * 1024)
            .OrderByDescending(process => process.WorkingSet64)
            .Select(process => new
            {
                process.Id,
                Name = process.ProcessName
            });
            ObjectDumper.Write(processes);
        }

        public static void Distinct()
        {
            int[] factorsOf300 = { 2, 2, 3, 5, 5 };

            var uniqueFactors = factorsOf300.Distinct();

            Console.WriteLine("Prime factors of 300:");
            foreach (var f in uniqueFactors)
            {
                Console.WriteLine(f);
            }
        }

        public static void ElementAt()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            int fourthLowNum = (
                from n in numbers
                where n < 5
                select n)
                .ElementAt(3); // 3 because sequences use 0-based indexing

            Console.WriteLine("Fourth number < 5: {0}", fourthLowNum);
        }

        /*
        public void EqualAll()
        {
            var wordsA = new string[] { "cherry", "apple", "blueberry" };
            var wordsB = new string[] { "cherry", "apple", "blueberry" };

            bool match = wordsA.EqualAll(wordsB);

            Console.WriteLine("The sequences match: {0}", match);
        }
        */ 

        public static void Except()
        {
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };

            IEnumerable<int> aOnlyNumbers = numbersA.Except(numbersB);

            Console.WriteLine("Numbers in first array but not second array:");
            foreach (var n in aOnlyNumbers)
            {
                Console.WriteLine(n);
            }
        }

        public static void EulerProblem1()
        {
            long range = Enumerable.Range(1, 999).Where(n => n % 3 == 0 || n % 5 == 0).Sum();
            System.Console.WriteLine
            (
                "Add all the natural numbers below one thousand that are multiples of 3 or 5: {0}",
                range
            );
        }

        public static void EulerProblem3()
        {
            long largeNumber = 600851475143;
            var allPrimeFactors = from p in Primes.PrimeFactors(largeNumber)
                                  orderby p descending
                                  select p;
            System.Console.WriteLine("What is the largest prime factor of the number 600,851,475,143?");
            foreach (var f in allPrimeFactors)
                Console.WriteLine(f);
        }

        public static void EulerProblem6()
        {
            var aggregate = (from number in Enumerable.Range(1, 100)
                               select new { number, square = number * number }).
                                Aggregate(new { Sum = 0, SumOfSquares = 0 },
                                (sums, val) => new { Sum = sums.Sum+val.number,
                             SumOfSquares = sums.SumOfSquares + val.square});
    
            int SquareOfSums = aggregate.Sum * aggregate.Sum;
     
            System.Console.WriteLine
            (
                "Euler Problem six asks you to find the difference between the sum of squares and the square of the sum for the natural numbers 1 through 100."
            );

            Console.WriteLine("{0} - {1} = {2}", SquareOfSums, aggregate.SumOfSquares,
                SquareOfSums - aggregate.SumOfSquares);
        }

        public static void EulerProblem6B()
        {
            int sum = Enumerable.Range(1, 100).Sum();

            int sumOfSquare = Enumerable.Range(1, 100).Select(i => i * i).Sum();

            int diff = (sum * sum) - sumOfSquare;

            System.Console.WriteLine
            (
                "Euler Problem six asks you to find the difference between the sum of squares and the square of the sum for the natural numbers 1 through 100."
            );

            Console.WriteLine("{0} - {1} = {2}", sum * sum, sumOfSquare, diff);
        }

        public static void FillDataSetUsingDataAdapter(DataSet dataSet)
        {
            // Create the DataAdapter
            var dataAdapter = new SqlDataAdapter(
            @"
                SELECT ContactID, Title, FirstName, MiddleName, LastName, EmailAddress, Phone, ModifiedDate FROM AdventureWorks.Person.Contact;
                SELECT ProductID, Name, ProductNumber, MakeFlag, FinishedGoodsFlag, Color, SafetyStockLevel, ReorderPoint, StandardCost, ListPrice, Size, SizeUnitMeasureCode, WeightUnitMeasureCode, Weight, DaysToManufacture, ProductLine, Class, Style, ProductSubcategoryID, ProductModelID, SellStartDate, SellEndDate , DiscontinuedDate, ModifiedDate FROM AdventureWorks.Production.Product 
            ",
            "Data Source=(local);Initial Catalog=AdventureWorks;Persist Security Info=True;Integrated Security=SSPI;");
            // Map the results to tables in the DataSet
            dataAdapter.TableMappings.Add("Table", "Contact");
            dataAdapter.TableMappings.Add("Table1", "Product");
            // Execute the SQL queries and load the data into the DataSet
            dataAdapter.Fill(dataSet);
        }

        public static void FillDataSetUsingDataAdapterLinq(DataSet dataSet)
        {
            /*
            DataContext dataContext = new DataContext();
            // Prepare the LINQ to SQL DataContext
            var adventureWorks =
            new dataContext("AdventureWorks");
            */ 
        }

        public static void First()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //int evenNum = numbers.First((num, index) => (num % 2 == 0) && (index % 2 == 0));
            int evenNum = numbers.First((num) => (num % 2 == 0));

            //Console.WriteLine("{0} is an even number at an even position within the list.", evenNum);
            Console.WriteLine("{0} is an even number:", evenNum);
        }

        public static void FirstOrDefault()
        {
            double?[] doubles = { 1.7, 2.3, 4.1, 1.9, 2.9 };

            /*
            double? num = doubles.FirstOrDefault((n, index) => (n >= index - 0.5 && n <= index + 0.5));
            if (num != null)
                Console.WriteLine("The value {1} is within 0.5 of its index position.", num);
            else
                Console.WriteLine("There is no number within 0.5 of its index position.", num);
            */
            double? num = doubles.FirstOrDefault();
            Console.WriteLine("The value {0} is first position.", num);
        }

        public static void GenerateXmlDataFromListOfCustomers()
        {
            var xml =
                new XElement
                    (
                        "contacts",
                        from address in AddressBook
                        select new XElement
                        (
                            "contact",
                            new XAttribute("City", address.City),
                            new XAttribute("FirstName", address.FirstName),
                            new XAttribute("LastName", address.LastName),
                            new XAttribute("Phone", address.Phone)
                        )
                    );
            System.Console.WriteLine(xml);
        }

        public static void GroupFirstLetter()
        {
            string[] words = { "blueberry", "chimpanzee", "abacus", "banana", "apple", "cheese" };

            var wordGroups =
                from w in words
                group w by w[0] into g
                select new { FirstLetter = g.Key, Words = g };

            foreach (var g in wordGroups)
            {
                Console.WriteLine("Words that start with the letter '{0}':", g.FirstLetter);
                foreach (var w in g.Words)
                {
                    Console.WriteLine(w);
                }
            }
        }

        public static void GroupRemainder()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var numberGroups =
                from n in numbers
                group n by n % 5 into g
                select new { Remainder = g.Key, Numbers = g };

            foreach (var g in numberGroups)
            {
                Console.WriteLine("Numbers with a remainder of {0} when divided by 5:", g.Remainder);
                foreach (var n in g.Numbers)
                {
                    Console.WriteLine(n);
                }
            }
        }

        public static void Intersect()
        {
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };

            var commonNumbers = numbersA.Intersect(numbersB);

            Console.WriteLine("Common numbers shared by both arrays:");
            foreach (var n in commonNumbers)
            {
                Console.WriteLine(n);
            }
        }

        /// <summary>
        /// A predicate is a Boolean expression that is intended to indicate
        /// membership of an element in a group. For example, it is used to
        /// define how to filter items inside a loop.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="names"></param>
        /// <param name="filter"></param>
        /// <example>
        /// string[] names = { "Marco", "Paolo", "Tom" };
        /// LambdaExpressionPredicateDisplay(names, s => s.Length > 4);
        /// </example>
        public static void LambdaExpressionPredicateDisplay<T>
        (
            T[] names,
            Func<T, bool> filter
        )
        {
            foreach (T s in names)
            {
                if (filter(s)) System.Console.WriteLine(s);
            }
        }

        public static void MinimumProjection()
        {
            string[] words = { "cherry", "apple", "blueberry" };

            int shortestWord = words.Min(w => w.Length);

            Console.WriteLine("The shortest word is {0} characters long.", shortestWord);
        }

        /// <summary>
        /// Select - Indexed
        /// For each element in an input integer array, this sample prints the value of the integer and whether it matches its index in the
        /// array. The sample uses an indexed Select clause to create a sequence of an anonymous type, each element of which has two 
        /// properties: the number itself, and a boolean value to indicate whether the number matches its position.
        /// </summary>
        public static void NumberIndex()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var numsInPlace = numbers.Select((num, index) => new { Num = num, InPlace = (num == index) });

            Console.WriteLine("Number: In-place?");
            foreach (var n in numsInPlace)
            {
                Console.WriteLine("{0}: {1}", n.Num, n.InPlace);
            }
        }

        /// <summary>
        /// This sample prints all of the elements of an array that are of type double. 
        /// The sample uses OfType to test the element's type.
        /// </summary>
        public static void OfType()
        {
            object[] numbers = { null, 1.0, "two", 3, 4.0f, 5, "six", 7.0 };
            var doubles = numbers.OfType<double>();
            Console.WriteLine("Numbers stored as doubles:");
            foreach (var d in doubles) {
                Console.WriteLine(d);
            }
        }

        /// <summary>
        /// This sample prints an array of strings, sorted according to a case insensitive alphanumeric sort. The sample uses OrderBy, passing a lambda function that performs the comparison.
        /// </summary>
        public static void OrderByLambdaComparer() 
        {
            string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry"};
    
            var sortedWords = words.OrderBy(a => a.Length)
                            .ThenByDescending(a => a, new CaseInsensitiveComparer());

            Console.WriteLine("Words sorted by length, and in descending order:");
            foreach(string sortedWord in sortedWords)
            {
                System.Console.WriteLine(sortedWord);   
            }
        }

        public static void OrderByWordLength()
        {
            string[] words = { "cherry", "apple", "blueberry" };

            var sortedWords =
                from w in words
                orderby w.Length
                select w;

            Console.WriteLine("The sorted list of words (by length):");
            foreach (var w in sortedWords)
            {
                Console.WriteLine(w);
            }
        }

        /// <summary>
        /// Using LINQ to Filter a File List by Date
        /// </summary>
        public static void OutputLogFileList(string FileDir, DateTime NewFileDate)
        {
            // get the list of all log files in FileDir
            List<string> LogFiles = System.IO.Directory.GetFiles(FileDir, "*.log").ToList();

            // filter the list to only include files older than NewFileDate
            List<string> OutputList = LogFiles.Where(x => System.IO.File.GetCreationTime(x) < NewFileDate).ToList();

            // output the list
            foreach (string logFile in OutputList)
                Console.WriteLine(logFile);
        }

        public static void RemoveAll()
        {
            int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var numbersList = numbers.ToList();
            numbersList.RemoveAll((n) => n > 2);
            Console.WriteLine("Remove all numbers greater than 2:");
            numbersList.ForEach((n) => Console.WriteLine(n));

            numbersList = numbers.ToList();
            numbersList.RemoveAll((n) => n > numbersList.IndexOf(n));
            Console.WriteLine("Remove all numbers from a list of integers where the number is greater than its index in the list:");
            numbersList.ForEach((n) => Console.WriteLine(n));
        }

        /// <summary>
        /// This sample prints a list strings from an input string array where each element has the second letter 'i'.
        /// The output list is printed in reverse order.
        /// The sample uses a query operator to gather the elements that have 'i' as the second letter and then 
        /// reverses the sequence using the Reverse method.
        /// </summary>
        /// <see cref="http://msdn2.microsoft.com/en-us/vcsharp/aa336756#reverse"/>
        public static void ReverseIDigits()
        {
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var reversedIDigits = (
                from d in digits
                where d[1] == 'i'
                select d)
                .Reverse();

            Console.WriteLine("A backwards list of the digits with a second character of 'i':");
            foreach (var d in reversedIDigits)
            {
                Console.WriteLine(d);
            }
        }

        /*
        public static void SequenceRange()
        {
            var numbers =
                from n in Sequence.Range(100, 50)
                select new {Number = n, OddEven = n % 2 == 1 ? "odd" : "even"};

            foreach (var n in numbers) {
                Console.WriteLine("The number {0} is {1}.", n.Number, n.OddEven);
            }
        }

        public static void SequenceRepeat()
        {
            var numbers = Sequence.Repeat(7, 10);

            foreach (var n in numbers)
            {
                Console.WriteLine(n);
            }
        }
        */
 
        ///<summary>
        /// This sample uses Skip to get all but the first 4 elements of the array.
        ///</summary>
        ///<see>http://msdn2.microsoft.com/en-us/vcsharp/aa336757.aspx#SkipSimple</see>
        public static void Skip() 
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            
            var allButFirst4Numbers = numbers.Skip(4);
            
            Console.WriteLine("All but first 4 numbers:");
            foreach (var n in allButFirst4Numbers) {
                Console.WriteLine(n);
            }
        }

        /// <summary>
        /// This sample prints all of the elements of an integer array, skipping elements until the element's value is less that its position in the array. 
        /// The sample uses SkipWhile to get the array elements.
        /// </summary>
        /// <see cref="http://msdn2.microsoft.com/en-us/vcsharp/aa336757#SkipWhileIndexed"/>
        public static void SkipWhileIndexed()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            
            var laterNumbers = numbers.SkipWhile((n, index) => n >= index);
            
            Console.WriteLine("All elements starting from first element less than its position:");
            foreach (var n in laterNumbers) {
                Console.WriteLine(n);
            }
        }

        public static void SumProjection()
        {
            string[] words = { "cherry", "apple", "blueberry" };

            double totalChars = words.Sum(w => w.Length);

            Console.WriteLine("There are a total of {0} characters in these words.", totalChars);
        }

        public static void SumSimple()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            double numSum = numbers.Sum();

            Console.WriteLine("The sum of the numbers is {0}.", numSum);
        }

        ///<summary>
        ///This sample uses Take to generate a sequence of the first three elements of an integer array.
        ///It then iterates through the sequence to print the results.
        ///</summary>
        ///<see cref="http://msdn2.microsoft.com/en-us/vcsharp/aa336757.aspx#TakeSimple"/>
        public static void Take()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            
            var first3Numbers = numbers.Take(3);
            
            Console.WriteLine("First 3 numbers:");
            foreach (var n in first3Numbers) {
                Console.WriteLine(n);
            }
        }

        /// <summary>
        /// This sample steps through an integer array printing values until a number is reached that is not less than six.
        /// The sample uses TakeWhile to generate the sequence, then iterates over the sequence to print the values.
        /// </summary>
        /// <see cref="http://msdn2.microsoft.com/en-us/vcsharp/aa336757.aspx#TakeWhileSimple"/>
        public static void TakeWhile()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var firstNumbersLessThan6 = numbers.TakeWhile(n => n < 6);

            Console.WriteLine("First numbers less than 6:");
            foreach (var n in firstNumbersLessThan6)
            {
                Console.WriteLine(n);
            }
        }

        public static void TemporaryFilesGreaterThan10000OrderedBySize()
        {
            string tempPath = Path.GetTempPath();
            DirectoryInfo dirInfo = new DirectoryInfo(tempPath);
            var query =
                from f in dirInfo.GetFiles()
                where f.Length > 10000
                orderby f.Length descending
                select f;
            foreach (FileInfo fileInfo in query)
            {
                System.Console.WriteLine(fileInfo.FullName);
            }
        }

        public static void ToArray()
        {
            double[] doubles = { 1.7, 2.3, 1.9, 4.1, 2.9 };
            var sortedDoubles =
                from d in doubles
                orderby d descending
                select d;
            var doublesArray = sortedDoubles.ToArray();

            Console.WriteLine("Every other double from highest to lowest:");
            for (int d = 0; d < doublesArray.Length; d += 2)
            {
                Console.WriteLine(doublesArray[d]);
            }
        }

        /// <summary>
        /// This sample uses anonymous types to create a data structure of people and their scores.
        /// It then uses ToDictionary to generate a dictionary from the sequence and its key expression.
        /// </summary>
        public static void ToDictionary()
        {
            var scoreRecords = new[] { new {Name = "Alice", Score = 50},
                                new {Name = "Bob" , Score = 40},
                                new {Name = "Cathy", Score = 45}
                              };
            var scoreRecordsDict = scoreRecords.ToDictionary(sr => sr.Name);
            Console.WriteLine("Bob's score: {0}", scoreRecordsDict["Bob"]);
        }

        public static void ToList()
        {
            string[] words = { "cherry", "apple", "blueberry" };
            var sortedWords =
                from w in words
                orderby w
                select w;
            var wordList = sortedWords.ToList();
            Console.WriteLine("The sorted word list:");
            foreach (var w in wordList)
            {
                Console.WriteLine(w);
            }
        }

        public static void Union()
        {
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };

            var uniqueNumbers = numbersA.Union(numbersB);

            Console.WriteLine("Unique numbers from both arrays:");
            foreach (var n in uniqueNumbers)
            {
                Console.WriteLine(n);
            }
        }

        public static void UpperAndLowerCases()
        {
            string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };

            var upperLowerWords =
                from w in words
                select new { Upper = w.ToUpper(), Lower = w.ToLower() };

            foreach (var ul in upperLowerWords)
            {
                Console.WriteLine("Uppercase: {0}, Lowercase: {1}", ul.Upper, ul.Lower);
            }
        }

        static LinqExample()
        {
            AddressBook = new List<AddressInfo>();
            AddressBook.Add(new AddressInfo() {FirstName="John",LastName="Doe",Phone="602-123-1234",City="Phoenix"} );
            AddressBook.Add(new AddressInfo() { FirstName = "Mary", LastName = "James", Phone = "510-123-1234", City = "Fremont" });
            AddressBook.Add(new AddressInfo() { FirstName = "James", LastName = "Taylor", Phone = "704-123-1234", City = "Charlotte" });
            AddressBook.Add(new AddressInfo() { FirstName = "Rita", LastName = "Smith", Phone = "770-123-1234", City = "Atlanta" });
            AddressBook.Add(new AddressInfo() { FirstName = "Larry", LastName = "Peters", Phone = "916-123-1234", City = "Atlanta" });
        }

        public class AddressInfo
        {
            public string City { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Phone { get; set; }
        }
    }

    public class CaseInsensitiveComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return string.Compare(x, y, true);
        }
    }
}
