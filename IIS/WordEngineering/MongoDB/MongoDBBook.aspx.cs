using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml.Linq; 

using MongoDB.Bson; 
using MongoDB.Driver; 
using MongoDB.Driver.Builders;

namespace WordEngineering
{
	public partial class MongoDBBookPage : Page
	{
		protected void Page_Load
		(
			object     sender, 
			EventArgs  e
		) 
		{
			if( !Page.IsPostBack )
			{
				BindData();
			}
		}

		protected String FeedBack
		{
			get
			{
				return ( feedBack.Text);
			} 
			set
			{
				feedBack.Text = value;
			}
		}

		protected String Question
		{
			get
			{
				return ( question.Text.Trim() );
			} 
			set
			{
				question.Text = value;
			}
		}

		/// <summary>
		/// 	db.books.insert({author: 'Wole Soyinka', title: 'The man died'});
		///		MongoCollection<Book> books = database.GetCollection<Book>("books");
		///		Book book = new Book {
		///		Author = "Wole Soyinka",
		///		Title = "The man died"
		///		};
		///		books.Insert(book);
		/// </summary>
		protected void BookGridView_Insert(Object sender, EventArgs e)
		{
			string author = (( System.Web.UI.WebControls.TextBox ) BookGridView.FooterRow.FindControl("TextBoxBookGridViewFooterTemplateAuthor")).Text;
			string title = (( System.Web.UI.WebControls.TextBox ) BookGridView.FooterRow.FindControl("TextBoxBookGridViewFooterTemplateTitle")).Text;
			
			BsonDocument book = new BsonDocument() 
                //.Add("_id", BsonValue.Create(BsonType.ObjectId)) 
                .Add("author", author) 
                .Add("title", title); 
 
            MongoDB.Driver.MongoCollection<MongoDB.Bson.BsonDocument> collection = DatabaseConnect();
			collection.Insert(book);
			BindData();
		}
					
		protected void BookGridView_PageIndexChanging(Object sender, GridViewPageEventArgs e)
		{
            BookGridView.PageIndex = e.NewPageIndex;
            FetchData();
		}

		protected void BookGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e) 
		{ 
			BookGridView.EditIndex = -1;  
			FetchData();
		}
		
		/// <summary>
		///		db.books.remove({_id:7});
		///  	db.books.remove({});    // removes all
		/// </summary>
		protected void BookGridView_RowDeleting(Object sender, GridViewDeleteEventArgs e)
		{
			List<Book> books = FetchData();
			if (books.Count == 1)
			{
				e.Cancel = true;
				FeedBack = "Not allowed.";
			}	
			GridViewRow row = (GridViewRow)BookGridView.Rows[e.RowIndex];
			String _id = ((Label)row.FindControl("LabelBookGridViewItemTemplate_Id")).Text;
			MongoDB.Driver.MongoCollection<MongoDB.Bson.BsonDocument> collection = DatabaseConnect();
			//var query = Query.EQ("_id", _id);
			var query = new QueryDocument("_id", _id);
			collection.Remove(query);
			BindData();
		}
		
		protected void BookGridView_RowEditing(object sender, GridViewEditEventArgs e)
		{
			BookGridView.EditIndex = e.NewEditIndex;  
			FetchData();
		}

		protected void BookGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
		{
			GridViewRow row = (GridViewRow)BookGridView.Rows[e.RowIndex];
			String _id = ((Label)row.FindControl("LabelBookGridViewEditItemTemplate_Id")).Text;
			String author = ((TextBox)row.FindControl("TextBoxBookGridViewEditItemTemplateAuthor")).Text;
			String title = ((TextBox)row.FindControl("TextBoxBookGridViewEditItemTemplateTitle")).Text;
			
			MongoDB.Driver.MongoCollection<MongoDB.Bson.BsonDocument> collection = DatabaseConnect();
			//var query = Query.EQ("_id", _id);

			var query = new QueryDocument("_id", _id);
			
			BsonDocument book = new BsonDocument() 
                .Add("author", author) 
                .Add("title", title); 

			var update = new UpdateDocument { {	"$set", book } };
			
			//BsonDocument updatedBook = collection.Update(query, book);
		
			BookGridView.EditIndex = -1;
			BindData();
		}
		
		protected void BookGridView_Sorting(object sender, GridViewSortEventArgs e)
		{
			//Retrieve the books from the session object.
			List<Book> books = FetchData();

			if (books != null)
			{
				//Sort the data.
				string sortDirection = RetrieveSortDirection(e.SortExpression);

				//books.Sort((x, y) => x.AuthorName.CompareTo(y.AuthorName));

				//System.Linq.Enumerable.OrderByDescending();
				//books = books.OrderyBy(d => d.AuthorName); 

				BookGridView.DataSource = books;
				BookGridView.DataBind();
			}
		}
		
		protected void Search_Click
		(
			Object sender, 
			EventArgs e
		)
		{
			BindData();
		}
		
		protected void BindData()
		{
			BookGridView.DataSource = RetrieveData();
			BookGridView.DataBind();
		}
		
		protected MongoDB.Driver.MongoCollection<MongoDB.Bson.BsonDocument> DatabaseConnect()
		{
			MongoServer mongo = MongoServer.Create();
			var db = mongo.GetDatabase("MongoDB10GenTutorial");
			MongoDB.Driver.MongoCollection<MongoDB.Bson.BsonDocument> collection = db.GetCollection<BsonDocument>("books");
			
			return collection;
		}

		protected List<Book> FetchData()
		{
			List<Book> books = (List<Book>) Session["Books"];
			BookGridView.DataSource = books;
			BookGridView.DataBind();
			return books;
		}

		/// <summary>
		/// 	db.users.find({});
		///		booksCount = db.books.find({}).count();
		//		db.books.find({}).sort({author: 1});
		//		db.foo.find( { name : "bob" , $or : [ { a : 1 } , { b : 2 } ] } )
		//		foreach (BsonDocument item in collection.FindAll())
		/// </summary>
		protected List<Book> RetrieveData()
		{
			MongoDB.Driver.MongoCollection<MongoDB.Bson.BsonDocument> collection = DatabaseConnect();
			var query = new QueryDocument("author", Question);
			
			Book book;
			
			List<Book> Books = new List<Book>();
			
			MongoDB.Driver.MongoCursor<MongoDB.Bson.BsonDocument> dataOriginal = null;
			if (Question == "")
			{
				dataOriginal = collection.FindAll();
			}
			else
			{
				dataOriginal = collection.Find(query);
			}
			
			foreach (BsonDocument item in dataOriginal)
			{ 
				BsonElement _id = item.GetElement("_id");
				BsonElement author = item.GetElement("author"); 
				BsonElement title = item.GetElement("title"); 
	 
				book = new Book
				{
					_Id = _id.Value.ToString(),
					Author = author.Value.ToString(), 
					Title = title.Value.ToString()
				};
				Books.Add(book);
				/*
				string bookDump = String.Format
				(
					BookFormat,
					_id.Value, 
					author.Value,
					title.Value
				);
				Response.Write(bookDump);
				*/

				/*
				foreach (BsonElement element in item.Elements) 
                { 
					string value = String.Format(ValueFormat, element.Name, element.Value);
					Response.Write(value); 
                }
				*/	
			}
			//Response.Write(Books.Count);
			
			//Persist the Books in the Session object.
			Session["Books"] = Books;
			
			return Books;
		}

		protected string RetrieveSortDirection(string column)
		{

			// By default, set the sort direction to ascending.
			string sortDirection = "ASC";

			// Retrieve the last column that was sorted.
			string sortExpression = ViewState["SortExpression"] as string;

			if (sortExpression != null)
			{
			  // Check if the same column is being sorted.
			  // Otherwise, the default value can be returned.
			  if (sortExpression == column)
			  {
				string lastDirection = ViewState["SortDirection"] as string;
				if ((lastDirection != null) && (lastDirection == "ASC"))
				{
				  sortDirection = "DESC";
				}
			  }
			}

			// Save new values in ViewState.
			ViewState["SortDirection"] = sortDirection;
			ViewState["SortExpression"] = column;

			return sortDirection;
		}
		
		protected const string BookFormat = "_id: {0}, Author: {1}, Title: {2}";
		protected const string ValueFormat = "Name: {0}, Value: {1}";
		//protected const string ConnectionString = @"key="connectionString" value="Server=localhost:27017"";
		protected const string ConnectionString = @"mongodb://localhost:27017";
		
		public partial class Book
		{
			public String _Id { get; set; }
			public String Author { get; set; }
			public String Title { get; set; }
		}
	}
}
