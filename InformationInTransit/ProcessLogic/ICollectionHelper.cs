using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InformationInTransit.ProcessLogic
{
	public static partial class ICollectionHelper
	{
		public static void Main(string[] argv)
		{
			string html = BuildPersonCollection();
			System.Console.WriteLine(html);
		}
		
		public static string ToHtmlTable<T>
		(
			this ICollection<T> collection,
			string tableSyle,
			string headerStyle,
			string rowStyle,
			string alternateRowStyle
		)
		{
			var result = new StringBuilder();
			if (String.IsNullOrEmpty(tableSyle))
			{
				result.Append("<table id=\"" + typeof(T).Name + "Table\">");
			}
			else
			{
				result.Append("<table id=\"" + typeof(T).Name + "Table\" class=\"" + tableSyle + "\">");
			}
 
			var propertyArray = typeof(T).GetProperties();
			foreach (var prop in propertyArray)
			{
				if (String.IsNullOrEmpty(headerStyle))
				{
					result.AppendFormat("<th>{0}</th>", prop.Name);
				}
				else
				{
					result.AppendFormat("<th class=\"{0}\">{1}</th>", headerStyle, prop.Name);
				}
			}
		 
			for (int i = 0; i < collection.Count; i++)
			{
				if (!String.IsNullOrEmpty(rowStyle) && !String.IsNullOrEmpty(alternateRowStyle))
				{
					result.AppendFormat("<tr class=\"{0}\">", i % 2 == 0 ? rowStyle : alternateRowStyle);
				}
				else
				{
					result.AppendFormat("<tr>");
				}
		 
				foreach (var prop in propertyArray)
				{
					object value = prop.GetValue(collection.ElementAt(i), null);
					result.AppendFormat("<td>{0}</td>", value ?? String.Empty);
				}
				result.AppendLine("</tr>");
			}
			result.Append("</table>");
			return result.ToString();
		}

		public static string BuildPersonCollection()
        {
            var personList = new List<Person>();
            personList.Add(new Person
            {
                FirstName = "Alex",
                LastName = "Friedman",
                Age = 27
            });
            personList.Add(new Person
            {
                FirstName = "Jack",
                LastName = "Bauer",
                Age = 45
 
            });
 
            personList.Add(new Person
            {
                FirstName = "Cloe",
                LastName = "O'Brien",
                Age = 35
            });
            personList.Add(new Person
            {
                FirstName = "John",
                LastName = "Doe",
                Age = 30
            });
 
            string html = @"<style type = ""text/css""> .tableStyle{border: solid 5 green;}
th.header{ background-color:#FF3300} tr.rowStyle { background-color:#33FFFF;
border: solid 1 black; } tr.alternate { background-color:#99FF66;
border: solid 1 black;}</style>";

            html += personList.ToHtmlTable("tableStyle", "header", "rowStyle", "alternate");
            return html;
        }
		
		public class Person
		{
			public string FirstName { get; set; }
			public string LastName { get; set; }
			public int Age { get; set; }
		}
	}
}

