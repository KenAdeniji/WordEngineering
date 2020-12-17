using System;
using System.Collections.Generic;

/*
	2018-11-02	Created.	apress.com/us/book/9781484213339
*/
namespace InformationInTransit.ProcessCode
{
	public static partial class GarbageCollectorHelper
	{
		public static void Collect()
		{
			// Force a garbage collection and wait for
			// each object to be finalized.
			GC.Collect();
			GC.WaitForPendingFinalizers();
		}
		
		public static Dictionary<string, object> Query()
		{
			Dictionary<string, object> features = 
				new Dictionary<string, object>
			{
				{"Estimated bytes on heap", GC.GetTotalMemory(false)},
				{"Operating System (OS) object generations", (GC.MaxGeneration + 1)}
			};
			return features;
		}
	}	
}
