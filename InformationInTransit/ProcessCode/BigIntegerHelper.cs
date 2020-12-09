using System;
using System.Collections.Generic;
using System.Numerics;

/*
	2018-11-01	Created.	apress.com/us/book/9781484213339
	2018-11-01	
		Dictionary<string, object> features = new Dictionary<string, object>();
		features.Add("Value", bigInteger);
		features.Add("IsEven", bigInteger.IsEven);
		features.Add("IsPowerOfTwo", bigInteger.IsPowerOfTwo);
		features.Add("Sign", bigInteger.Sign);
	
*/	
namespace InformationInTransit.ProcessCode
{
	public static partial class BigIntegerHelper
	{
		public static Dictionary<string, object> Query
		(
			string question
		)
		{
			BigInteger bigInteger = BigInteger.Parse(question);
			Dictionary<string, object> features = 
				new Dictionary<string, object>
			{
				{"Value", bigInteger},
				{"IsEven", bigInteger.IsEven},
				{"IsPowerOfTwo", bigInteger.IsPowerOfTwo},
				{"Sign", bigInteger.Sign}
			};
			return features;
		}
	}	
}	
