#region Using directives
using System;
#endregion

namespace InformationInTransit.ProcessLogic
{
	/*
		2017-04-20	Created.	apress.com/us/book/9781484213339
					All value types implicitly inherit from the class System.ValueType , which, in turn, inherits from class object.
	*/
    #region ValueTypeHelper definition
    public static partial class ValueTypeHelper
    {
        #region Methods
		public static void Main(string[] argv)
		{
			Stub();
		}

		public static void Stub()
		{
			int usable = 30;
			System.Console.WriteLine
			(
				"GetHashCode(): {0} Equals(): {1} ToString(): {2} GetType(): {3}", 
				usable.GetHashCode(),
				usable.Equals(usable),
				usable.ToString(),
				usable.GetType()
			);
			
		}	
        #endregion
    }
    #endregion
}
