using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using System.Linq;
using System.Reflection;

/*
	Date Created:	2020-10-01	https://stackoverflow.com/questions/10261824/how-can-i-get-all-constants-of-a-type-by-reflection
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
	}
}

