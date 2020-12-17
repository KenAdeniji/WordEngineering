using System;
using System.IO;	
using System.Linq;
using System.Reflection;
using System.Text;

/*
	2018-11-03	Created.	apress.com/us/book/9781484213339
*/
namespace InformationInTransit.ProcessCode
{
	public static partial class DynamicLoadAssemblyReflector
	{
		public static void Main(string[] argv)
		{
			Query(argv);
		}
		
		public static void DisplayTypesInAssembly(Assembly assembly)
		{
			Console.WriteLine("\n***** Types in Assembly *****");
			Console.WriteLine("->{0}", assembly.FullName);
			Type[] types = assembly.GetTypes();
			foreach (Type t in types)
			{
				Console.WriteLine("Type: {0}", t);
			}	
			Console.WriteLine("");
		}
		
		public static StringBuilder Query(String[] argv)
		{
			StringBuilder sb = new StringBuilder();
			Assembly assembly = null;
			foreach(String assemblyName in argv)
			{
				assembly = Assembly.LoadFrom(assemblyName);
				DisplayTypesInAssembly(assembly);
			}	
			return sb;
		}
	}	
}
