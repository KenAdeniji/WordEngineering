using System;
using System.Linq;
using System.Reflection;
using System.Text;

/*
	2018-11-02	Created.	apress.com/us/book/9781484213339
*/
namespace InformationInTransit.ProcessCode
{
	public static partial class TypeViewerHelper
	{
		public static void Main(string[] argv)
		{
			Query(argv);
		}
		
		public static StringBuilder Query(String[] argv)
		{
			StringBuilder sb = new StringBuilder();
			foreach(string typeName in argv)
			{
				Type t = Type.GetType(typeName);
				sb.Append(ListVariousStats(t));
				sb.Append(ListMethods(t));
				sb.Append(ListFields(t));
				sb.Append(ListProperties(t));
				sb.Append(ListInterfaces(t));
			}
			return sb;
		}
		
		public static StringBuilder ListFields(Type t)
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("***** Fields *****");
			var fieldNames = from f in t.GetFields() select f.Name;
			foreach (var name in fieldNames)
			{
				sb.AppendFormat("->{0}{1}", name, System.Environment.NewLine);
			}	
			sb.AppendLine();
			return sb;
		}

		public static StringBuilder ListInterfaces(Type t)
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("***** Interfaces *****");
			var interfaceNames = from i in t.GetInterfaces() select i.Name;
			foreach (var name in interfaceNames)
			{
				sb.AppendFormat("->{0}{1}", name, System.Environment.NewLine);
			}	
			sb.AppendLine();
			return sb;
		}
		
		public static StringBuilder ListMethods(Type t)
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("***** Methods *****");
						
			MethodInfo[] mi = t.GetMethods();
			foreach (MethodInfo m in mi)
			{
				// Get return type.
				string retVal = m.ReturnType.FullName;
				string paramInfo = "( ";
				// Get params.
				foreach (ParameterInfo pi in m.GetParameters())
				{
					paramInfo += string.Format("{0} {1} ", pi.ParameterType, pi.Name);
				}
				paramInfo += " )";
				// Now display the basic method sig.
				sb.AppendFormat("->{0} {1} {2} {3}", retVal, m.Name, paramInfo, System.Environment.NewLine);
			}	
			sb.AppendLine();
			return sb;
		}

		public static StringBuilder ListProperties(Type t)
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("***** Properties *****");
			var propertyNames = from p in t.GetProperties() select p.Name;
			foreach (var name in propertyNames)
			{
				sb.AppendFormat("->{0}{1}", name, System.Environment.NewLine);
			}	
			sb.AppendLine();
			return sb;
		}
		
		public static StringBuilder ListVariousStats
		(
			Type t
		)
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("***** Various Statistics *****");
			sb.AppendFormat("Type is: {0}{1}", t, System.Environment.NewLine);
			sb.AppendFormat("Base class is: {0}{1}", t.BaseType, System.Environment.NewLine);
			sb.AppendFormat("Is type abstract? {0}{1}", t.IsAbstract, System.Environment.NewLine);
			sb.AppendFormat("Is type sealed? {0}{1}", t.IsSealed, System.Environment.NewLine);
			sb.AppendFormat("Is type generic? {0}{1}",
			t.IsGenericTypeDefinition, System.Environment.NewLine);
			sb.AppendFormat("Is type a class type? {0}{1}", t.IsClass, System.Environment.NewLine);
			sb.AppendLine();
			return sb;
		}
	}	
}
