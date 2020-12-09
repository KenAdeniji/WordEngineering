using System;
using System.ComponentModel;
 
namespace InformationInTransit.ProcessLogic
{
	///<example>
	///string a = "1234";
	///int b = a.ChangeType<int>(); //Successful conversion to int (b=1234)
	///string c = b.ChangeType<string>(); //Successful conversion to string (c="1234")
	///string d = "foo";
	///int e = d.ChangeType<int>(); //Exception System.InvalidCastException
	////int f = d.ChangeType(0); //Successful conversion to int (f=0)
	///<remarks>
	///http://extensionmethod.net/csharp/changetype/piero-alvarez-fuentes
	///</remarks>
	public static partial class GenericHelper
	{
		public static void Main(string[] argv)
		{
			string a = "1234";
			int b = a.ChangeType<int>(); //Successful conversion to int (b=1234)
			string c = b.ChangeType<string>(); //Successful conversion to string (c="1234")
			string d = "foo";
			int e = d.ChangeType<int>(); //Exception System.InvalidCastException
			int f = d.ChangeType(0); //Successful conversion to int (f=0)
		}
		
		public static U ChangeType<U>(this object source, U returnValueIfException)
		{
			try
			{
				return source.ChangeType<U>();
			}
			catch
			{
				return returnValueIfException;
			}
		}
		 
		public static U ChangeType<U>(this object source)
		{
			if (source is U)
				return (U)source;
		 
			var destinationType = typeof(U);
			if (destinationType.IsGenericType && destinationType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
				destinationType = new NullableConverter(destinationType).UnderlyingType;
		 
			return (U)Convert.ChangeType(source, destinationType);
		}
	}
}
