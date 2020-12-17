using System;
using System.Data;
using System.Text;

namespace InformationInTransit.ProcessCode
{
	/*
		2019-08-17T09:15:00
	*/	
	public static partial class SQLBuild
	{
		public static string WhereClause
		(
			String combination,
			String columnName,
			String logicJoinClause,
			String logicJoinBetween
		) 
		{
			StringBuilder sb = new StringBuilder();

			if (String.IsNullOrEmpty(combination))
			{
				return "";
			}	

			sb.Append(" " + logicJoinClause + " ( ");

			bool firstValue = false;

			string valueTrim = "";
			
			foreach (var columnValue in combination.Split(','))
			{
				if (!firstValue)
				{
					firstValue = true;
				}
				else
				{
					sb.Append(" " + logicJoinBetween + " ");
				}	
				
				valueTrim = columnValue.Trim();
				
				sb.Append(" " + columnName + " LIKE '%" + valueTrim + "%' ");
			}
			
			sb.Append(" ) ");
			
			return sb.ToString();
			
		}
	}
}
