using  System.Diagnostics;

namespace InformationInTransit.ProcessCode
{
	//https://docs.microsoft.com/en-us/visualstudio/debugger/assertions-in-managed-code?view=vs-2017
	public static partial class AssertHelper
	{
		public static void Main(string[] argv)
		{
			DebugAssert();
		}
		
		public static void DebugAssert()
		{
			int dividend = 21;
			int	divisor = 0;
			Debug.Assert( divisor != 0 );  
			int division =  ( dividend / divisor );
		}
	}	
}
