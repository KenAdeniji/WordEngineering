using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InformationInTransit.ProcessLogic
{
    public static partial class LinqGroupByExample
    {
        public static void Main(string[] argv)
        {
            PrintList();
            ListOfEmployeesGroupedByTheFirstLetterOfTheirFirstName();
            ListOfEmployeesGroupedByTheYearInWhichTheyWereBorn();
            ListOfEmployeesGroupedByTheYearAndMonthInWhichTheyWereBorn();
            TotalNumberOfBirthdaysEachYear();
            GenderRatio();
        }

        public static void PrintList()
        {
            Console.WriteLine
            (
                "\n{0,2} {1,10}  {2,10}    {3,10}   {4,10}   {5,6}",
                "ID", "FirstName", "MiddleName", "LastName", "Date Of Birth", "Gender"
            );

            EmployeeList.ForEach(delegate(Employee e)
            {
                Console.WriteLine
                (
                    "\n{0,2} {1,10}  {2,10}    {3,10}   {4:d}   {5,6}",
                    e.ID, e.FirstName, e.MiddleName, e.LastName, e.DateOfBirth, e.Gender
                );
            });
        }

        public static void ListOfEmployeesGroupedByTheFirstLetterOfTheirFirstName()
        {
            var groupOrderByFirstLetter = EmployeeList.GroupBy
            (
                //employee => new String(employee.FirstName[0], 1)
                employee => employee.FirstName.Substring(0, 1)
            )
            .OrderBy
            (
                employee => employee.Key
            );

            foreach (var employeesGroup in groupOrderByFirstLetter)
            {
                Console.WriteLine
                (
                    "Employees having First Letter {0}:",
                    employeesGroup.Key
                );
                foreach (var employee in employeesGroup)
                {
                    Console.WriteLine(employee.FirstName);
                }
            }
        }

        public static void ListOfEmployeesGroupedByTheYearInWhichTheyWereBorn()
        {
            var groupOrderByYearOfBirth = EmployeeList.GroupBy
            (
                employee => employee.DateOfBirth.Year
            )
            .OrderBy
            (
                employee => employee.Key
            );
            foreach (var employeesGroup in groupOrderByYearOfBirth)
            {
                Console.WriteLine
                (
                    "Employees born in the year {0}:",
                    employeesGroup.Key
                );
                foreach (var employee in employeesGroup)
                {
                    Console.WriteLine
                    (
                        "{0,2}, {1,10}",
                        employee.ID,
                        employee.FirstName
                    );
                }
            }
        }

        public static void ListOfEmployeesGroupedByTheYearAndMonthInWhichTheyWereBorn()
        {
            var groupOrderByDateOfBirthYearMonth = EmployeeList.GroupBy
            (
                employee => new DateTime
                    (
                        employee.DateOfBirth.Year,
                        employee.DateOfBirth.Month,
                        1
                    )
            ).OrderBy(employee => employee.Key);
            foreach (var employeesGroup in groupOrderByDateOfBirthYearMonth)
            {
                Console.WriteLine
                (
                    "Employees born in the year {0} and month {1}:",
                    employeesGroup.Key.Year,
                    employeesGroup.Key.Month
                );
                foreach (var employee in employeesGroup)
                {
                    Console.WriteLine
                    (
                        "{0,2}, {1,10}",
                        employee.ID,
                        employee.FirstName
                    );
                }
            }
        }

        public static void TotalNumberOfBirthdaysEachYear()
        {
            var groupByDateOfBirthYear = EmployeeList.GroupBy
            (
                employee => employee.DateOfBirth.Year
            ).OrderBy(employee => employee.Key)
            .Select
            (
                employeesGroup => new
                {
                    Year = employeesGroup.Key,
                    Count = employeesGroup.Count()
                }
            );

            foreach (var dateOfBirthYear in groupByDateOfBirthYear)
            {
                System.Console.WriteLine
                (
                    "In the year {0}, there was/were {1} birth(s).",
                    dateOfBirthYear.Year,
                    dateOfBirthYear.Count
                );
            }
        }

        public static void GenderRatio()
        {
            var genderRatio = EmployeeList.GroupBy
            (
                employee => employee.Gender
            ).OrderBy(employee => employee.Key)
            .Select
            (
                employeesGroup => new
                {
                    Gender = employeesGroup.Key,
                    Percentage = employeesGroup.Count() * 100  / EmployeeList.Count()
                }
            );

            foreach (var gender in genderRatio)
            {
                System.Console.WriteLine
                (
                    "Gender {0} {1}%",
                    gender.Gender,
                    gender.Percentage
                );
            }
        }

        public partial class Employee
        {
            public int ID { get; set; }
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public string LastName { get; set; }
            public DateTime DateOfBirth { get; set; }
            public char Gender { get; set; }
        }

        public static readonly List<Employee> EmployeeList = new List<Employee>
        {
            new Employee{ ID = 1, FirstName = "John", MiddleName = String.Empty, LastName = "Shields", DateOfBirth = DateTime.Parse("1971-12-11"), Gender = 'M' },
            new Employee{ ID = 2, FirstName = "Mary", MiddleName = "Medaline", LastName = "Jacobs", DateOfBirth = DateTime.Parse("1961-01-17"), Gender = 'F' },
            new Employee{ ID = 3, FirstName = "Amber", MiddleName = "Caroline", LastName = "Agar", DateOfBirth = DateTime.Parse("1971-12-23"), Gender = 'F' },
            new Employee{ ID = 4, FirstName = "Kathy", MiddleName = String.Empty, LastName = "Berry", DateOfBirth = DateTime.Parse("1976-11-15"), Gender = 'F' },
            new Employee{ ID = 5, FirstName = "Lena", MiddleName = "Ashco", LastName = "Bilton", DateOfBirth = DateTime.Parse("1978-05-11"), Gender = 'F' },
            new Employee{ ID = 6, FirstName = "Susanne", MiddleName = String.Empty, LastName = "Buck", DateOfBirth = DateTime.Parse("1965-03-07"), Gender = 'F' },
            new Employee{ ID = 7, FirstName = "Jim", MiddleName = String.Empty, LastName = "Brown", DateOfBirth = DateTime.Parse("1972-09-11"), Gender = 'M' },
            new Employee{ ID = 8, FirstName = "Jane", MiddleName = "G", LastName = "Hooks", DateOfBirth = DateTime.Parse("1972-12-11"), Gender = 'F' },
            new Employee{ ID = 9, FirstName = "Robert", MiddleName = String.Empty, LastName = String.Empty, DateOfBirth = DateTime.Parse("1964-06-28"), Gender = 'M' },
            new Employee{ ID = 10, FirstName = "Cindy", MiddleName = "Patricia", LastName = "Fox", DateOfBirth = DateTime.Parse("01/11/1978"), Gender = 'F' }
        };
    }
}
