/*
	2020-08-13	https://softchris.github.io/pages/dotnet-graphql.html#hello-graphql
*/	

using System;
using System.Collections.Generic;
using System.Linq;

using GraphQL;
using GraphQL.Types;

namespace App
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			var schema = Schema.For(@"
				type Book {
					id: ID,
					title: String,
					author: String
				}
				type Query {
					hello: String
					books: [Book]
					book(id: ID): Book
				}
				", _ =>
				{
					_.Types.Include<Query>();
				}
			);

			var root = new { Hello = "Hello World!" };

			var json = schema.Execute(_ =>
			{
				_.Query = "{ hello }";
				_.Root = root;
			});

			Console.WriteLine(json);

			json = schema.Execute(_ =>
			{
				_.Query = "{ books { id, title, author } }";
				_.Root = root;
			});

			Console.WriteLine(json);

			json = schema.Execute(_ =>
			{
				_.Query = "{ book(id: 45) { title, author } }";
				_.Root = root;
			});
			
			Console.WriteLine(json);
		}
	}
	
	public class Query 
	{
		[GraphQLMetadata("books")]
		public IEnumerable<Book> GetBooks() 
		{
			return BooksDB.GetBooks();
		}

		[GraphQLMetadata("book")]
		public Book GetBook(int id)
		{
			return BooksDB.GetBooks().SingleOrDefault(b => b.Id == id);
		}

		[GraphQLMetadata("hello")]
		public string GetHello() 
		{
			return "Hello Query class";
		}
	}
	
	public class BooksDB
	{
		public static IEnumerable<Book> GetBooks() 
		{
			return new List<Book>() {
				new Book(){ Id=1, Title="Genesis", Author="Moses"},
				new Book(){ Id=45, Title="Romans", Author="Paul"},
				new Book(){ Id=66, Title="Revelation", Author="John"}
			};
		}
	}

	public class Book
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Author { get; set; }
	}
}
