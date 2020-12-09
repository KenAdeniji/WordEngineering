using	System;
using	System.Collections.Generic;
using	System.Linq;
using	System.Reflection;

/*
	Date Created:	2020-03-22	https://extensionmethod.net/csharp/generic/list-t-areallsame
		https://stackoverflow.com/questions/14428084/ienumerable-cannot-be-used-with-type-arguments
*/
namespace InformationInTransit.ProcessCode
{
	static class IEnumerableExtensionMethods
	{
		public static void Main(string[] argv)
		{
			Stub();	
		}

		public static void Stub()
		{
			var animals = new List<string>() { "bird", "bird" };
			System.Console.WriteLine
			(
				"AreAllSame(): {0} {1} {2}",
				animals.AreAllSame(),
				!animals.Distinct().Skip(1).Any(),
				!animals.Any(o => o != animals[0])
			);
		}
		
		/// <summary>
		///   Checks whether all items in the enumerable are same (Uses <see cref="object.Equals(object)" /> to check for equality)
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="enumerable">The enumerable.</param>
		/// <returns>
		///   Returns true if there is 0 or 1 item in the enumerable or if all items in the enumerable are same (equal to
		///   each other) otherwise false.
		/// </returns>
		public static bool AreAllSame<T>(this System.Collections.Generic.IEnumerable<T> enumerable)
		{
			//if (enumerable == null) throw new ArgumentNullException(nameof(enumerable));

			using (var enumerator = enumerable.GetEnumerator())
			{
				var toCompare = default(T);
				if (enumerator.MoveNext())
				{
					toCompare = enumerator.Current;
				}

				while (enumerator.MoveNext())
				{
					if (toCompare != null && !toCompare.Equals(enumerator.Current))
					{
						return false;
					}
				}
			}

			return true;
		}
		
		///<summary>
		///	http://extensionmethod.net/csharp/ienumerable-t/orderby-string-sortexpression
		///	class Customer
		///	{
		///		public string Name{get;set;}
		///	}
		///	var list = new List<Customer>();
		///	list.OrderBy("Name desc");
		///</summary>
		public static IEnumerable<T> OrderBy<T>(this IEnumerable<T> list, string sortExpression)
		{
			sortExpression += "";
			string[] parts = sortExpression.Split(' ');
			bool descending = false;
			string property = "";

			if (parts.Length > 0 && parts[0] != "")
			{
				property = parts[0];

				if (parts.Length > 1)
				{
					descending = parts[1].ToLower().Contains("esc");
				}

				PropertyInfo prop = typeof(T).GetProperty(property);

				if (prop == null)
				{
					throw new Exception("No property '" + property + "' in + " + typeof(T).Name + "'");
				}

				if (descending)
					return list.OrderByDescending(x => prop.GetValue(x, null));
				else
					return list.OrderBy(x => prop.GetValue(x, null));
			}

			return list;
		}
	}
}
	