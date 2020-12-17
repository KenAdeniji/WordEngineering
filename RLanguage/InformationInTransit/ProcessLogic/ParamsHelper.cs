using System;
using System.Text;

namespace InformationInTransit.ProcessLogic
{
	/*
		2018-01-13	https://msdn.microsoft.com/en-us/library/ms229008%28v=vs.100%29.aspx?f=255&MSPPError=-2147217396
	*/
	public class ParamsHelper
	{
		public static StringBuilder Append(params string[] list) 
		{
			StringBuilder sb = new StringBuilder();
			for ( int i = 0 ; i < list.Length ; i++ )
			{
				if (!String.IsNullOrEmpty(list[i]))
				{
					if (sb.Length > 0)
					{
						sb.Append(", ");
					}
					sb.Append(list[i]);	
				}
			}
			return sb;
		}
	}
}	