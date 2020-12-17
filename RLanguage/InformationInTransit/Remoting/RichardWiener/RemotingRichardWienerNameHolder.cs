using System;
using System.Collections;

/*
	2020-04-19T10:00:00	jot.fm/issues/issue_2004_01/column8.pdf
	2020-04-20T10:05:00	error CS0006: Metadata file 'system.remoting.dll' could not be found
	
*/
namespace RichardWiener
{
    [Serializable]  
	public class RemotingRichardWienerNameHolder
	{ 
		//   Fields
		private ArrayList names = new ArrayList(); 
		//   Commands
		public void AddName(String newName)
		{ 
			names.Add(newName);  
		}
		//   Queries
		public   ArrayList   GetNames() 
		{
			return   names;  
		}
	}
}
