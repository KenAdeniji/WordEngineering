using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Web.Services;

using InformationInTransit.ProcessLogic;

namespace WordEngineering
{

	/// <summary>ServiceWorldRound</summary>
	[
	System.Web.Services.WebService
	(
		Description="An AlphabetSequence service.",
		Name="ServiceWorldRound"
	)
	]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]  
	[System.Web.Script.Services.ScriptService]   	
	public class ServiceWorldRound : System.Web.Services.WebService
	{
		[WebMethod]
		public string HelloWorld() {
			return "Hello World.";
		}
		
		///<summary>Index</summary>
		[
			System.Web.Services.WebMethod
			(
				BufferResponse=true,
				CacheDuration=60,
				Description="This method determines the index.",
				EnableSession=true,
				MessageName="Index",
				TransactionOption=TransactionOption.RequiresNew
			)
		]
		public int Index
		(
			String word
		)
		{
			word = word.ToUpper();
			int result = 0;
			for(int index = 0, length = word.Length; index < length; ++index)
			{
				char letter = word[index];
				if (Char.IsLetter(letter))
				{
					int ascii = Convert.ToInt32(letter);
					result += ascii - 64;
				}
			}
			return ( result );
		}

		///<summary>Index</summary>
		[
			System.Web.Services.WebMethod
			(
				BufferResponse=true,
				CacheDuration=60,
				Description="This method determines the scripture reference.",
				EnableSession=true,
				MessageName="ScriptureReference",
				TransactionOption=TransactionOption.RequiresNew
			)
		]
		public string ScriptureReference
		(
			String word
		)
		{
			int index = Index(word);
			string scriptureReference = InformationInTransit.ProcessLogic.AlphabetSequence.ScriptureReference(index);
			return (scriptureReference);
		}

	}
	
	public class WorldRound
	{
		protected int Index{ get; set; }
		protected string ScriptureReference{ get; set; }

		public WorldRound()
		{
		}

		public WorldRound(int index, string scriptureReference)
		{
			this.Index = index;
			this.ScriptureReference = scriptureReference;
		}
	}	
}
