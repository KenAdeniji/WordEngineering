﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;

namespace InformationInTransit.ProcessCode
{
	///<summary>
	/// 2018-04-17 	Created.
	///	2018-04-17	https://www.dotnetperls.com/convert-char-string
	///</summary>
	public partial class OurPeople
	{
		public static void Main(string[] argv)
		{
			List<String> returnList = Query(argv[0]);
			System.Console.WriteLine(returnList.Count());
		}
		
		public static List<String> Query(string wordToFind)
		{
			List<String>	resultList = new List<String>();
			bool			alphabetNotFound;
			String			wordToSearch;
			
			foreach (DataRow currentRow in ResultTable.Rows)
			{
				wordToSearch = (String) currentRow["BibleWord"];
				alphabetNotFound = false;
				foreach(char currentAlphabet in wordToFind)
				{
					if 
					(
						wordToSearch.Contains
						(
							currentAlphabet.ToString(),
							StringComparison.OrdinalIgnoreCase
						) == false
					)
					{
						alphabetNotFound = true;
						break;
					}	
				}
				if (alphabetNotFound == false)
				{	
					resultList.Add(wordToSearch);
				}	
			}	
			
			return resultList;
		}
		
		static OurPeople()
		{
			ResultTable = (DataTable) DataCommand.DatabaseCommand
			(
				"SELECT BibleWord FROM Bible..Exact ORDER BY BibleWord",
				System.Data.CommandType.Text,
				DataCommand.ResultType.DataTable
			);
		}
		
		public static readonly DataTable ResultTable;
	}
}
