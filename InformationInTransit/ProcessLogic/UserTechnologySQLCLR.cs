using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

using Microsoft.SqlServer.Server;

/*
	2016-03-01	UserTechnologySQLCLR.cs	
	2016-03-02	https://msdn.microsoft.com/en-us/library/ms131103.aspx
	2016-03-03	http://stackoverflow.com/questions/493010/how-to-print-a-message-from-sql-clr-function/32221863#32221863
	2016-03-06	http://www.dotnetperls.com/palindrome
	
--"C:\WINDOWS\Microsoft.NET\Framework\v3.5\csc.exe" /target:library /reference:C:\Windows\Microsoft.NET\Framework\v2.0.50727\mscorlib.dll,C:\Windows\Microsoft.NET\Framework\v2.0.50727\System.Data.dll UserTechnologySQLCLR.cs

DROP FUNCTION FindMatchingDates
GO

DROP ASSEMBLY UserTechnologySQLCLR
GO

CREATE ASSEMBLY UserTechnologySQLCLR from 'E:\WordEngineering\InformationInTransit\ProcessLogic\UserTechnologySQLCLR.dll' WITH PERMISSION_SET = SAFE --EXTERNAL_ACCESS
GO

CREATE FUNCTION FindMatchingDates(@datedUntil DateTime)
RETURNS TABLE 
(
	UserTechnologyID		int,
	Dated				DateTime,
	Occasion			nvarchar(255),
	ContactID			int,
	URI					nvarchar(255),
	ScriptureReference	nvarchar(MAX),
	DebugInfo			nvarchar(255)
)
AS EXTERNAL NAME UserTechnologySQLCLR.[InformationInTransit.ProcessLogic.UserTechnology].FindMatchingDates
GO

SELECT * FROM FindMatchingDates('2016-02-14')	--Jasmine, Valentine's Day
GO

SELECT * FROM FindMatchingDates('2016-06-01')	--en.wikipedia.org/wiki/Joseph_Nanven_Garba Dead
GO

SELECT * FROM FindMatchingDates('2016-03-20')	--Jasmine, Biblical Calendar
GO

SELECT * FROM FindMatchingDates('2016-03-01')	--en.wikipedia.org/wiki/Joseph_Nanven_Garba Dead
GO

SELECT * FROM FindMatchingDates('2016-01-18')	--Jasmine, Valentine's Day
GO
*/
namespace InformationInTransit.ProcessLogic
{
	public partial class UserTechnology 
	{
		private class DateDifferenceResult {
			public 	SqlInt32 		UserTechnologyID;
			public 	SqlDateTime 	Dated;
			public 	SqlString 		Occasion;	
			public 	SqlInt32 		ContactID;
			public 	SqlString 		Uri;
			public 	SqlString 		ScriptureReference;
			public	SqlString		DebugInfo;
			
			public DateDifferenceResult
			(
				SqlInt32 		userTechnologyID,
				SqlDateTime 	dated,
				SqlString 		occasion,	
				SqlInt32 		contactID,
				SqlString 		URI,
				SqlString		scriptureReference,
				SqlString		message
			) 
			{
				UserTechnologyID 	=	userTechnologyID;
				Dated 				= 	dated;
				Occasion			=	occasion;
				ContactID			=	contactID;
				Uri					=	URI;
				ScriptureReference	=	scriptureReference;
				DebugInfo			=	message;
			}
		}

		public static bool DateDifference
		(
				SqlDateTime		datedFrom,
				SqlDateTime		datedUntil,
			ref	SqlString		message
		)
		{
 			DateTime from		=	((DateTime) datedFrom).Date;
			int	datedFromYear	=	from.Year;
			int	datedFromMonth	=	from.Month;
			int	datedFromDay	=	from.Day;
			
			DateTime until		=	((DateTime) datedUntil).Date;
			int	datedUntilYear	=	until.Year;
			int	datedUntilMonth	=	until.Month;
			int	datedUntilDay	=	until.Day;
			
			message = "";
			if (datedFromMonth == datedUntilMonth && datedFromDay == datedUntilDay)
			{
				return true;
			}

			int interval = (until - from).Days;
			message = interval.ToString();
			
			if (interval % 30 == 0)
			{
				return true;
			}		
			
			string session = interval.ToString().Trim();
			bool isPalindrome = IsPalindrome(session);

			return isPalindrome;
	   }

		public static bool IsPalindrome(string value)
		{
			int min = 0;
			int max = value.Length - 1;
			while (true)
			{
				if (min > max)
				{
					return true;
				}
				char a = value[min];
				char b = value[max];
				if (char.ToLower(a) != char.ToLower(b))
				{
					return false;
				}
				min++;
				max--;
			}
		}
	
	   [SqlFunction(
		   DataAccess = DataAccessKind.Read,
		   FillRowMethodName = "FindNonMatchingDates_FillRow",
		   TableDefinition="UserTechnologyID int, Dated DateTime2, Occasion nvarchar(255), ContactID int, URI nvarchar(255)")]
	   public static IEnumerable FindMatchingDates(SqlDateTime datedUntil) {
		  ArrayList resultCollection = new ArrayList();

		  using (SqlConnection connection = new SqlConnection("context connection=true")) {
			 connection.Open();

			 using (SqlCommand selectDates = new SqlCommand(
				 "SELECT " +
				 "[UserTechnologyID], [Dated], [Occasion], [ContactID], [URI],  " +
				 "[scriptureReference] " +
				 "FROM [WordEngineering].[dbo].[UserTechnology] " +
				 "WHERE [dated] <= @datedUntil",
				 connection)) {
				SqlParameter datedUntilParam = selectDates.Parameters.Add(
					"@datedUntil",
					SqlDbType.DateTime);
				datedUntilParam.Value = datedUntil;

				using (SqlDataReader datesReader = selectDates.ExecuteReader()) {
					while (datesReader.Read()) 
					{
						SqlInt32		UserTechnologyID		=	datesReader.GetSqlInt32(0);
						SqlDateTime		dated 				= 	datesReader.GetSqlDateTime(1);
						SqlString		occasion 			=	datesReader.GetSqlString(2);
						SqlInt32		contactID			=	datesReader.GetSqlInt32(3);
						SqlString		URI		 			=	datesReader.GetSqlString(4);
						SqlString		scriptureReference	=	datesReader.GetSqlString(5);
						
						SqlString		message				=	"";
						
						if (DateDifference(dated, datedUntil, ref message)) 
						{
							resultCollection.Add
							(
								new DateDifferenceResult
								(
									UserTechnologyID,
									dated,
									occasion,
									contactID,
									URI,
									scriptureReference,
									message
								)
							);
						}
					}
				}
			 }
		  }

		  return resultCollection;
	   }

		public static void FindNonMatchingDates_FillRow
		(
					object			dateResultObj,
			out 	SqlInt32 		UserTechnologyID,
			out		SqlDateTime		dated,
			out 	SqlString 		occasion,
			out		SqlInt32		contactID,
			out 	SqlString 		URI,
			out		SqlString		scriptureReference,
			out		SqlString		message
		)
		{
			DateDifferenceResult	dateDifferenceResult = (DateDifferenceResult)dateResultObj;
			
			UserTechnologyID		=	dateDifferenceResult.UserTechnologyID;
			dated				=	dateDifferenceResult.Dated;
			occasion			=	dateDifferenceResult.Occasion;
			contactID			=	dateDifferenceResult.ContactID;
			URI					=	dateDifferenceResult.Uri;
			scriptureReference	=	dateDifferenceResult.ScriptureReference;
			message				=	dateDifferenceResult.DebugInfo;
	   }
	};
}
 