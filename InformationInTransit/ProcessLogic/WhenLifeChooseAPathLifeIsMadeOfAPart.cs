using System;
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
using System.Text.RegularExpressions;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;

namespace InformationInTransit.ProcessLogic
{
	/*
		2017-09-29	Created.
		2017-09-29	asp-net-example.blogspot.com/2013/10/c-example-stringbuilder-prepend.html	
	*/
	public static partial class WhenLifeChooseAPathLifeIsMadeOfAPartHelper
	{

		public static DataSet Query
		(
			string	bibleVersion,
			string	direction,
			string	location,
			string	logic
		)
		{
			StringBuilder sbWhereClauseDirection = new StringBuilder();
			StringBuilder sbWhereClauseLocation = new StringBuilder(); 
			StringBuilder sbWhereClause = new StringBuilder(); 
			
			if (!String.IsNullOrEmpty(direction))
			{
				sbWhereClauseDirection.Append( StringHelper.CombineLogic(bibleVersion, direction, " or ") );
			}		
			
			if (!String.IsNullOrEmpty(location))
			{
				sbWhereClauseLocation.Append( StringHelper.CombineLogic(bibleVersion, location, " or ") );
			}
			
			if (sbWhereClauseDirection.Length > 0)
			{
				sbWhereClause.Append( "(" + sbWhereClauseDirection + ")" );
			}

			if (sbWhereClauseDirection.Length > 0 && sbWhereClauseLocation.Length > 0)
			{
				sbWhereClause.Append( logic );
			}
			
			if (sbWhereClauseLocation.Length > 0)
			{
				sbWhereClause.Append( "(" + sbWhereClauseLocation + ")" );
			}	

			if (sbWhereClause.Length > 0)
			{
				sbWhereClause.Insert(0, " WHERE ");
			}
			
			string sqlStatement = String.Format
			( 
				BibleQueryFormatVersions,
				bibleVersion,
				sbWhereClause
			);
			
			DataSet dataSet = null;
			dataSet = (DataSet)DataCommand.DatabaseCommand
			(
				sqlStatement.ToString(),
				CommandType.Text,
				DataCommand.ResultType.DataSet
			);

			return dataSet;
		}	

		public const string BibleQueryFormatVersions = "SELECT bookId, chapterId, verseId, verseText = {0}, verseIdSequence FROM Bible..Scripture {1} ORDER BY bookId, chapterId, verseId;";
		
	}
}
	