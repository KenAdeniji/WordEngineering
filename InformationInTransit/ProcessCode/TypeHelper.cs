using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;

/*
	Date Created:	2020-10-01	https://stackoverflow.com/questions/10261824/how-can-i-get-all-constants-of-a-type-by-reflection
	2021-11-11T10:33:00 Created. https://docs.microsoft.com/en-us/dotnet/api/system.reflection.assembly.createinstance?view=net-5.0	
*/
namespace InformationInTransit.ProcessLogic
{
	public static class TypeHelper
	{
		public static IEnumerable<FieldInfo> GetConstants(this Type type)
		{
			var fieldInfos = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
			return fieldInfos.Where(fi => fi.IsLiteral && !fi.IsInitOnly);
		}

		public static IEnumerable<T> GetConstantNames<T>(this Type type) where T : class
		{
			var fieldInfos = GetConstants(type);

			return fieldInfos
				.Select(fi => fi.Name as T)
				.OrderBy(x => x);
		}

		public static IEnumerable<T> GetConstantsValues<T>(this Type type) where T : class
		{
			var fieldInfos = GetConstants(type);

			return fieldInfos.Select(fi => fi.GetRawConstantValue() as T);
		}
	
		public static List<T> GetAllPublicConstantValues<T>(this Type type)
		{
			return type
				.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
				.Where(fi => fi.IsLiteral && !fi.IsInitOnly && fi.FieldType == typeof(T))
				.Select(x => (T)x.GetRawConstantValue())
				.ToList();
		}
		
		public static object Instantiate(String typeName)
		{
			Assembly assem = typeof(TypeHelper).Assembly;
			return assem.CreateInstance("InformationInTransit.ProcessCode.GroupOfPeople." + typeName);
			
			ObjectHandle handle = Activator.CreateInstance("InformationInTransit", "InformationInTransit.ProcessCode.GroupOfPeople." + typeName);
			return (handle.Unwrap());
		}		
	}
}
