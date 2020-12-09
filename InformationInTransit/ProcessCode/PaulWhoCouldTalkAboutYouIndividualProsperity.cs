using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

using InformationInTransit.ProcessCode;
using InformationInTransit.ProcessLogic;
using InformationInTransit.DataAccess;	

namespace InformationInTransit.ProcessCode
{
	/*
		2018-11-29	https://webstyleguide.com/1-strategy.html
		2018-12-01	Paul who could talk about you individual prosperity.
	*/
    public static partial class PaulWhoCouldTalkAboutYouIndividualProsperity
    {
		public static DataSet Query
		(
			int	contactID,		
			String	word,
			String	logic
		)
		{
			String[] words = null;
			
			if (logic == "phrase")
			{
				words = new String[] { word };
			}
			else
			{
				words = word.Split(BibleWordHelper.SplitSeparator, StringSplitOptions.RemoveEmptyEntries);
			}
			
			StringBuilder sbOuter = new StringBuilder();
			StringBuilder sbInner = new StringBuilder();
			
			for
			(
				int outerIndex = 0, outerLength = 2; //SelectQuery.Length;
				outerIndex < outerLength;
				++outerIndex
			)
			{
				sbOuter.AppendFormat
				(
					"SELECT Dated, {1} FROM {0} ",
					SelectQuery[outerIndex, 0],
					SelectQuery[outerIndex, 1]
				);
				sbInner = new StringBuilder();
				sbInner.AppendFormat
				(
					" WHERE ContactID = {0} ",
					contactID
				);
				if (word == "") { sbOuter.Append(sbInner + " ORDER BY Dated DESC;"); continue; }
				sbInner.Append( "AND (" );
				bool firstTime = true;
				foreach (String currentWord in words)
				{
					if (!firstTime)
					{
						sbInner.Append( logic );
					}	
					firstTime = false;
					sbInner.AppendFormat
					(
						" {0} LIKE '%{1}%' ",
						SelectQuery[outerIndex, 1],
						currentWord
					);
				}
				if (words.Length > 0) { sbInner.Append( ") ORDER BY Dated DESC;" ); }
				sbOuter.Append(sbInner);
			}
			DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
			(
				sbOuter.ToString(),
				System.Data.CommandType.Text,
				DataCommand.ResultType.DataSet
			);
			return dataSet;
		}
		
		public static readonly String[,] SelectQuery = new String[2,2]
        {
            {"WordEngineering..HisWord", "Commentary"},
            //{"WordEngineering..Dream", "Commentary"},
            {"WordEngineering..CaseBasedReasoning", "Commentary"}
        };
    }
}
