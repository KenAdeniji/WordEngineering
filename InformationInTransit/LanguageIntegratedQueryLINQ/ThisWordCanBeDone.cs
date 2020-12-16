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

using InformationInTransit.SacredText;

namespace InformationInTransit.LanguageIntegratedQueryLINQ
{
/*
	2019-12-10	Created.
		SqlMetal /server:Comfort /database:Bible /code:Bible.cs /namespace:InformationInTransit.SacredText
	2018-11-04	https://books.google.com/books/about/Pro_LINQ.html?id=438nCgAAQBAJ&printsec=frontcover&source=kp_read_button&hl=en#v=onepage&q&f=false
		Pro LINQ: Language Integrated Query in C# 2008 is different as it demonstrates the overwhelming majority of LINQ operators and prototypes. It is a veritable treasury of LINQ examples. The book cuts right to the chase of each LINQ operator, method, or class. ... Google Books Originally published: November 27, 2007 Author: Joseph C. Rattz
	2019-12-10	https://stackoverflow.com/questions/847066/group-by-multiple-columns
*/
	public partial class ThisWordCanBeDone
	{
		public static void Main(String[] argv)
		{
			GroupByBookSeries();
		}
		
		public static object GroupByBookSeries()
		{
			// DataContext takes a connection string. 
			Bible db = new Bible(ConnectionStringBible);

			// Query for Scripture
			var query = 
			(
				from scripture in db.Scripture
					//where scripture.BookTitle.Any(c => char.IsDigit(c))
					//where "abc3def".Any(c => char.IsDigit(c))
					//where scripture.BookTitle == "Genesis"
					where
						scripture.BookTitle.Contains("1")
					|| 	scripture.BookTitle.Contains("2")
					|| 	scripture.BookTitle.Contains("3")
					//where scripture.BookTitle like '%[0-9]%'
					orderby scripture.BookId
					group scripture by new {scripture.BookId, scripture.BookTitle} into grp
                    select new
                    {
                        grp.Key.BookId,
                        grp.Key.BookTitle,
                        Chapters = grp.Max(t => t.ChapterId)
                    }
			).ToList();
					
			//Console.WriteLine(query.GetType());	

			foreach (var item in query)
			{
				Console.WriteLine("{0} - {1} - {2}", item.BookId, item.BookTitle, item.Chapters);	
			}
			
			return query;
		}
		
		public const string ConnectionStringBible = @"Data Source=(local);Initial Catalog=Bible;Persist Security Info=True;Integrated Security=SSPI;Connect Timeout=36000;";
	}	
}
