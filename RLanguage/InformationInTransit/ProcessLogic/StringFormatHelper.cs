#region Using directives
using System;
#endregion

namespace InformationInTransit.ProcessLogic
{
	/*
		2017-04-20	Created.	apress.com/us/book/9781484213339
	*/
    #region StringFormatHelper definition
    public static partial class StringFormatHelper
    {
        #region Methods
		public static void Main(string[] argv)
		{
			Stub();
		}

		public static void Stub()
		{
			System.Console.WriteLine
			(
				"Currency: {0:c} {0:d9}", 
				99999
			);
		}	
        #endregion
    }
    #endregion
}
