﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

using System.Data;
using System.Data.SqlClient;

using InformationInTransit.DataAccess;

/*
	2018-09-28	Created.
*/
namespace InformationInTransit.ProcessCode
{
    public static partial class SacredTextHelper
    {
		public static string Query
		(
			string title
		)
		{

			String bookTitle = (string) DataCommand.DatabaseCommand
			(
				String.Format
				(
					"SELECT TOP 1 BookTitle FROM Bible..Scripture_View WHERE BookTitle = '{0}'",
					title
				),
				System.Data.CommandType.Text,
				DataCommand.ResultType.Scalar
			);
			if (!string.IsNullOrEmpty(bookTitle))
			{
				return null;
			}	
			
			String scriptureReference = (string) DataCommand.DatabaseCommand
			(
				String.Format
				(
					"SELECT TOP 1 scriptureReference FROM WordEngineering..SacredText WHERE Title LIKE '%{0}%'",
					title
				),
				System.Data.CommandType.Text,
				DataCommand.ResultType.Scalar
			);
			System.Console.WriteLine
			(
				"Title: {0} | scriptureReference: {1}",
				title,
				scriptureReference
			);
			return scriptureReference; 
		}
	}	
}
