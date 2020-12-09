using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InformationInTransit.ProcessLogic
{
    public static partial class DerivedOrImplementedHelper
    {
        public static void Main(string[] argv)
        {
        }

		///<example>
		///if(typeof(UserEntity).IsDerived<IExtend>())
		///{
		///	// do something..
		///}
		///<remarks>
		///http://extensionmethod.net/csharp/type/isderived
		///</remarks>
		public static bool IsDerived<T>(this Type type)
		{
			Type baseType = typeof(T);
		 
			if(baseType.FullName == type.FullName)
			{
				return true;
			}
		 
			if(type.IsClass)
			{
				return baseType.IsClass
					? type.IsSubclassOf(baseType)
					: baseType.IsInterface 
						? IsImplemented(type, baseType) 
						: false;
			}
			else if(type.IsInterface && baseType.IsInterface)
			{
				return IsImplemented(type, baseType);
			}
			return false;
		}
		 
		public static bool IsImplemented(Type type, Type baseType)
		{
			Type[] faces = type.GetInterfaces();
			foreach(Type face in faces)
			{
				if(baseType.Name.Equals(face.Name))
				{
					return true;
				}
			}
			return false;
		}
    }
}
