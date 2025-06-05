--http://www.sommarskog.se/Short%20Stories/generate_series.html

http://github.com/KenAdeniji/WordEngineering/blob/main/IIS/WordEngineering/2018-05-03Correspondence/2025-06-04T2345sommarskog.se_-_generate_series_-_2020-06-11JohnGeorgePsychiatricPavilion_-_Michael_Emergency.sql

--2020-06-11 John George Psychiatric Pavilion. Michael. Emergency.

SELECT DATEDIFF(DAY, '2020-06-11', '2025-06-04')

SELECT * FROM generate_series(1, 10);

DECLARE @startdate date  = '19971201',
        @enddate   date  = '19971231';

--Show Data for All Dates
WITH Dates AS (
  SELECT dateadd(DAY, value, @startdate) AS Date
  FROM   generate_series(0, datediff(DAY, @startdate, @enddate), 1)
)
SELECT D.Date AS OrderDate, COUNT(O.OrderID) AS [Count], 
       isnull(SUM(OD.Amount), 0) AS TotAmount
FROM   Dates D
LEFT   JOIN (dbo.Orders O
             JOIN   (SELECT OrderID, SUM(UnitPrice * Quantity) AS Amount
                     FROM   dbo.[Order Details] OD 
                     GROUP  BY OrderID) OD ON O.OrderID = OD.OrderID)
    ON O.OrderDate = D.Date
GROUP  BY D.Date
ORDER  BY D.Date;

--Finding Missing IDs
SELECT gs.value AS MissingID
FROM   generate_series((SELECT MIN(O.OrderID) FROM dbo.Orders O),
                       (SELECT MAX(O.OrderID) FROM dbo.Orders O), 1) AS gs
WHERE  NOT EXISTS (SELECT *
                   FROM   dbo.Orders O
                   WHERE  O.OrderID = gs.value);

--Picking Strings Apart
--Note: the purpose of the COLLATE clause is to ensure that a and z are really the first and last letters so that the BETWEEN operator works as intended. The alphabets of some languages have letters that come after z. Swedish is one example of this.
WITH chars AS (
  SELECT lower(substring(E.Notes, gs.value, 1)) COLLATE Latin1_General_CI_AS ch
  FROM   dbo.Employees E
  CROSS  APPLY generate_series(convert(bigint, 1), len(E.Notes), convert(bigint, 1)) AS gs
)
SELECT ch, COUNT(*) AS charfreq
FROM   chars
WHERE  ch BETWEEN 'a' AND 'z'
GROUP  BY ch
ORDER  BY charfreq DESC;

--datename(weekday, D.Date) NOT IN ('Saturday', 'Sunday')

--Note: I prefer to use datename over datepart here, since datepart is dependent on the SET DATEFIRST setting, and if you don't watch out, you could be filtering for Friday and Saturday when you wanted to filter for the weekend. True, the output from datename depends on the SET LANGUAGE setting and could return Samstag or domenica. But if so, you would not be filtering for anything at all, which is likely to stand out more than if you filter for the wrong days of the week. If nothing else, datename works with both SET LANGUAGE us_english and SET LANGUAGE British, whereas datepart does not.

--http://learn.microsoft.com/en-us/sql/t-sql/functions/datetrunc-transact-sql?view=sql-server-ver17

DECLARE @d datetime2 = '2021-12-08 11:30:15.1234567';
SELECT 'Year', DATETRUNC(year, @d);
SELECT 'Quarter', DATETRUNC(quarter, @d);
SELECT 'Month', DATETRUNC(month, @d);
SELECT 'Week', DATETRUNC(week, @d); -- Using the default DATEFIRST setting value of 7 (U.S. English)
SELECT 'Iso_week', DATETRUNC(iso_week, @d);
SELECT 'DayOfYear', DATETRUNC(dayofyear, @d);
SELECT 'Day', DATETRUNC(day, @d);
SELECT 'Hour', DATETRUNC(hour, @d);
SELECT 'Minute', DATETRUNC(minute, @d);
SELECT 'Second', DATETRUNC(second, @d);
SELECT 'Millisecond', DATETRUNC(millisecond, @d);
SELECT 'Microsecond', DATETRUNC(microsecond, @d);

--2025-06-05T00:28:00 They say English is your problem not the Indias or the Jews, but to get to forty-five percent they know what to do.
--2025-06-05T00:28:00 We can't differentiate where our people are... as we can't differentiate where our lives are.

--2025-06-05T00:54:00
/*
Server Error in '/WordEngineering' Application.
The wait operation timed out
Description: An unhandled exception occurred during the execution of the current web request. Please review the stack trace for more information about the error and where it originated in the code.

Exception Details: System.ComponentModel.Win32Exception: The wait operation timed out

Source Error:

An unhandled exception was generated during the execution of the current web request. Information regarding the origin and location of the exception can be identified using the exception stack trace below.

Stack Trace:

----2025-06-05T01:07:00
/*
Server Error in '/WordEngineering' Application.
The wait operation timed out
Description: An unhandled exception occurred during the execution of the current web request. Please review the stack trace for more information about the error and where it originated in the code.

Exception Details: System.ComponentModel.Win32Exception: The wait operation timed out

Source Error:

An unhandled exception was generated during the execution of the current web request. Information regarding the origin and location of the exception can be identified using the exception stack trace below.

Stack Trace:


[Win32Exception (0x80004005): The wait operation timed out]

[SqlException (0x80131904): Execution Timeout Expired.  The timeout period elapsed prior to completion of the operation or the server is not responding.]
   System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction) +113
   System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose) +334
   System.Data.SqlClient.TdsParserStateObject.ReadSniError(TdsParserStateObject stateObj, UInt32 error) +857
   System.Data.SqlClient.TdsParserStateObject.ReadSniSyncOverAsync() +299
   System.Data.SqlClient.TdsParserStateObject.TryReadNetworkPacket() +126
   System.Data.SqlClient.TdsParserStateObject.TryPrepareBuffer() +97
   System.Data.SqlClient.TdsParserStateObject.TryReadByte(Byte& value) +47
   System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady) +704
   System.Data.SqlClient.SqlDataReader.TryConsumeMetaData() +89
   System.Data.SqlClient.SqlDataReader.get_MetaData() +101
   System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString, Boolean isInternal, Boolean forDescribeParameterEncryption, Boolean shouldCacheForAlwaysEncrypted) +624
   System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, Boolean inRetry, SqlDataReader ds, Boolean describeParameterEncryptionRequest) +3355
   System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry) +725
   System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method) +84
   System.Data.SqlClient.SqlCommand.ExecuteReader(CommandBehavior behavior, String method) +312
   System.Data.Common.DbDataAdapter.FillInternal(DataSet dataset, DataTable[] datatables, Int32 startRecord, Int32 maxRecords, String srcTable, IDbCommand command, CommandBehavior behavior) +214
   System.Data.Common.DbDataAdapter.Fill(DataSet dataSet, Int32 startRecord, Int32 maxRecords, String srcTable, IDbCommand command, CommandBehavior behavior) +180
   System.Data.Common.DbDataAdapter.Fill(DataSet dataSet, String srcTable) +123
   System.Web.UI.WebControls.SqlDataSourceView.ExecuteSelect(DataSourceSelectArguments arguments) +2947
   System.Web.UI.DataSourceView.Select(DataSourceSelectArguments arguments, DataSourceViewSelectCallback callback) +26
   System.Web.UI.WebControls.BaseDataBoundControl.EnsureDataBound() +134
   System.Web.UI.WebControls.GridView.OnPreRender(EventArgs e) +45
   System.Web.UI.Control.PreRenderRecursiveInternal() +132
   System.Web.UI.Control.PreRenderRecursiveInternal() +227
   System.Web.UI.Control.PreRenderRecursiveInternal() +227
   System.Web.UI.Control.PreRenderRecursiveInternal() +227
   System.Web.UI.Control.PreRenderRecursiveInternal() +227
   System.Web.UI.Page.ProcessRequestMain(Boolean includeStagesBeforeAsyncPoint, Boolean includeStagesAfterAsyncPoint) +4000


Version Information: Microsoft .NET Framework Version:4.0.30319; ASP.NET Version:4.8.9282.0 
*/

[Win32Exception (0x80004005): The wait operation timed out]

[SqlException (0x80131904): Execution Timeout Expired.  The timeout period elapsed prior to completion of the operation or the server is not responding.]
   System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction) +113
   System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose) +334
   System.Data.SqlClient.TdsParserStateObject.ReadSniError(TdsParserStateObject stateObj, UInt32 error) +857
   System.Data.SqlClient.TdsParserStateObject.ReadSniSyncOverAsync() +299
   System.Data.SqlClient.TdsParserStateObject.TryReadNetworkPacket() +126
   System.Data.SqlClient.TdsParserStateObject.TryPrepareBuffer() +97
   System.Data.SqlClient.TdsParserStateObject.TryReadByte(Byte& value) +47
   System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady) +704
   System.Data.SqlClient.SqlDataReader.TryConsumeMetaData() +89
   System.Data.SqlClient.SqlDataReader.get_MetaData() +101
   System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString, Boolean isInternal, Boolean forDescribeParameterEncryption, Boolean shouldCacheForAlwaysEncrypted) +624
   System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, Boolean inRetry, SqlDataReader ds, Boolean describeParameterEncryptionRequest) +3355
   System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry) +725
   System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method) +84
   System.Data.SqlClient.SqlCommand.ExecuteReader(CommandBehavior behavior, String method) +312
   System.Data.Common.DbDataAdapter.FillInternal(DataSet dataset, DataTable[] datatables, Int32 startRecord, Int32 maxRecords, String srcTable, IDbCommand command, CommandBehavior behavior) +214
   System.Data.Common.DbDataAdapter.Fill(DataSet dataSet, Int32 startRecord, Int32 maxRecords, String srcTable, IDbCommand command, CommandBehavior behavior) +180
   System.Data.Common.DbDataAdapter.Fill(DataSet dataSet, String srcTable) +123
   System.Web.UI.WebControls.SqlDataSourceView.ExecuteSelect(DataSourceSelectArguments arguments) +2947
   System.Web.UI.DataSourceView.Select(DataSourceSelectArguments arguments, DataSourceViewSelectCallback callback) +26
   System.Web.UI.WebControls.BaseDataBoundControl.EnsureDataBound() +134
   System.Web.UI.WebControls.GridView.OnPreRender(EventArgs e) +45
   System.Web.UI.Control.PreRenderRecursiveInternal() +132
   System.Web.UI.Control.PreRenderRecursiveInternal() +227
   System.Web.UI.Control.PreRenderRecursiveInternal() +227
   System.Web.UI.Control.PreRenderRecursiveInternal() +227
   System.Web.UI.Control.PreRenderRecursiveInternal() +227
   System.Web.UI.Page.ProcessRequestMain(Boolean includeStagesBeforeAsyncPoint, Boolean includeStagesAfterAsyncPoint) +4000


Version Information: Microsoft .NET Framework Version:4.0.30319; ASP.NET Version:4.8.9282.0 
*/
