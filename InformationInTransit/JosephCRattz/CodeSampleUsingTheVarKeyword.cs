using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.SqlServer.Server;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.Web;

using System.Data.Linq;
using System.Linq;

using nwind;

namespace JosephRattz.ProLINQLanguageIntegratedQueryInCSharp2008
{
/*
	2019-12-09	Created.
		SqlMetal /server:Comfort /database:northwind /code:nwind.cs /namespace:nwind
	2018-11-04	https://books.google.com/books/about/Pro_LINQ.html?id=438nCgAAQBAJ&printsec=frontcover&source=kp_read_button&hl=en#v=onepage&q&f=false
		Pro LINQ: Language Integrated Query in C# 2008 is different as it demonstrates the overwhelming majority of LINQ operators and prototypes. It is a veritable treasury of LINQ examples. The book cuts right to the chase of each LINQ operator, method, or class. ... Google Books Originally published: November 27, 2007 Author: Joseph C. Rattz
*/
	public partial class CodeSampleUsingTheVarKeyword
	{
		public static void Main(String[] argv)
		{
			Stub();
		}
		
		public static void Stub()
		{
			// DataContext takes a connection string. 
			Northwind db = new Northwind(ConnectionStringNorthwind);

			// Query for customers and orders.
			var orders = db.Customers
				.Where(c => c.Country == "USA" && c.Region == "WA")
				.SelectMany(c => c.Orders);
				
			Console.WriteLine(orders.GetType());	

			foreach (var item in orders)
			{
				Console.WriteLine("{0} - {1} - {2}", item.OrderDate, item.OrderID, item.ShipName);	
			}
		}
		
		public const string ConnectionStringNorthwind = @"Data Source=(local);Initial Catalog=Northwind;Persist Security Info=True;Integrated Security=SSPI;Connect Timeout=36000;";
	}	
}
