using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Linq.Dynamic;
using System.Windows.Forms;
using NorthwindMapping;

namespace InformationInTransit.ProcessLogic
{
    class DynamicQueryableStub
    {
        static void Main(string[] args)
        {
            // For this sample to work, you need an active database server or SqlExpress.
            // Here is a connection to the Data sample project that ships with Microsoft Visual Studio 2008.
            /*
            string dbPath = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\..\..\Data\NORTHWND.MDF"));
            string sqlServerInstance = @".\SQLEXPRESS";
            string connString = "AttachDBFileName='" + dbPath + "';Server='" + sqlServerInstance + "';user instance=true;Integrated Security=SSPI;Connection Timeout=60";
            */
            // Here is an alternate connect string that you can modify for your own purposes.
            string connString = "server=(local);database=northwind;Integrated Security=SSPI";

            LinkToSqlNorthWind db = new LinkToSqlNorthWind(connString); 
            db.Log = Console.Out;

            /*
            var query = db.Customers.Where("City == @0 and Orders.Count >= @1", "London", 10).
        	OrderBy("CompanyName").
	        Select new(CompanyName as Name, Phone);
            */

            string condition1 = "FirstName.StartsWith(\"" + "J" + "\")";
            string condition2 = "FirstName.StartsWith(\"" + "A" + "\")";
            var query = db.Employees.
                Where(condition1 + " or " + condition2).
                Select("new(FirstName, LastName)");
            ObjectDumper.Write(query);

            System.Console.ReadLine();
        }
    }
}
