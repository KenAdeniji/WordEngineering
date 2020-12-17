using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Script;
using System.Web.Script.Serialization; 

namespace InformationInTransit.ProcessCode
{
	//2018-09-08 Created.	https://www.codementor.io/andrewbuchan/how-to-parse-json-into-a-c-object-4ui1o0bx8
	public static partial class JsonHelper
	{
		public static void Main(string[] argv)
		{
			DeserializeJohnDoe();
			DeserializeOrderItem();
		}
		
		public static void DeserializeJohnDoe()
		{
			var example1 = @"{""name"":""John Doe"",""age"":20}";
			var example1Model = new JavaScriptSerializer().Deserialize<Example1Model>(example1);
			System.Console.WriteLine(example1Model.name);
		}
		
		public static void DeserializeOrderItem()
		{
			var example2 = @"{""custId"": 123, ""ordId"": 4567, ""items"":[{""prodId"":1, ""price"":9.99, ""title"":""Product 1""},{""prodId"":78, ""price"":95.99, ""title"":""Product 2""},{""prodId"":1985, ""price"":3.01, ""title"":""Product 3""}] }";
			var example2Model = new JavaScriptSerializer().Deserialize<CustomerOrderSummary>(example2);
			System.Console.WriteLine(example2Model.custId);
		}
		
		class Example1Model
		{
			public string name { get; set; }
			public int age { get; set; }
		}		
		
		class Item
		{
			public int prodId { get; set; }
			public double price { get; set; }
			public string title { get; set; }
		}
		
		class CustomerOrderSummary
		{
			public int custId { get; set; }
			public int ordId { get; set; }
			public List<Item> items { get; set; }
		}		
	}	
}
