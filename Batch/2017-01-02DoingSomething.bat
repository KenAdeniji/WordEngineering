@echo off
:BeginAgain
echo 1=BCP, 2=Node.js, 3=Rust, 4=SQLServerBackup, 5=SQLServerDataDefinitionLanguageDDL, 6=SQLServerDataFiles, 7=SQLServerDataManipulationLanguageDML, 8=SQLServerExport, 9=WebAssembly, 10=WinScp, 11=WordEngineering, 12=WordOfGod
set /p id=Enter Choice: 

IF %id% == 1 GOTO BCP
IF %id% == 2 GOTO Node.js
IF %id% == 3 GOTO Rust
IF %id% == 4 GOTO SQLServerBackup
IF %id% == 5 GOTO SQLServerDataDefinitionLanguageDDL
IF %id% == 6 GOTO SQLServerDataFiles
IF %id% == 7 GOTO SQLServerDataManipulationLanguageDML
IF %id% == 8 GOTO SQLServerExport
IF %id% == 9 GOTO WebAssembly
IF %id% == 10 GOTO WinScp
IF %id% == 11 GOTO WordEngineering
IF %id% == 12 GOTO WordOfGod
GOTO Exit

:BCP
xcopy e:\BCP c:\BCP /d /e /s /y
xcopy e:\BCP d:\BCP /d /e /s /y
xcopy e:\BCP f:\BCP /d /e /s /y
xcopy e:\BCP \\Noor\e$\BCP /d /e /s /y
REM xcopy e:\BCP \\Harvest\e$\BCP /d /e /s /y
xcopy e:\BCP C:\Users\KAdeniji\OneDrive\BCP /d /e /s /y
GOTO Exit

:Node.js
xcopy e:\Node.js c:\Node.js /d /e /s /y
xcopy e:\Node.js d:\Node.js /d /e /s /y
xcopy e:\Node.js f:\Node.js /d /e /s /y
xcopy e:\Node.js \\Noor\e$\Node.js /d /e /s /y
REM xcopy e:\Node.js C:\Users\KAdeniji\OneDrive\Node.js /d /e /s /y
GOTO Exit

:Rust
xcopy e:\Rust c:\Rust /d /e /s /y
xcopy e:\Rust d:\Rust /d /e /s /y
xcopy e:\Rust f:\Rust /d /e /s /y
xcopy e:\Rust \\Noor\e$\Rust /d /e /s /y
xcopy e:\Rust \\Harvest\e$\Rust /d /e /s /y
xcopy e:\Rust C:\Users\KAdeniji\OneDrive\Rust /d /e /s /y
GOTO Exit

:SQLServerBackup
xcopy e:\SQLServerBackup c:\SQLServerBackup /d /e /s /y
xcopy e:\SQLServerBackup d:\SQLServerBackup /d /e /s /y
xcopy e:\SQLServerBackup f:\SQLServerBackup /d /e /s /y
xcopy e:\SQLServerBackup \\Noor\e$\SQLServerBackup /d /e /s /y
xcopy e:\SQLServerBackup \\Harvest\e$\SQLServerBackup /d /e /s /y
xcopy e:\SQLServerBackup C:\Users\KAdeniji\OneDrive\SQLServerBackup /d /e /s /y
GOTO Exit

:SQLServerDataDefinitionLanguageDDL
xcopy e:\SQLServerDataDefinitionLanguageDDL c:\SQLServerDataDefinitionLanguageDDL /d /e /s /y
xcopy e:\SQLServerDataDefinitionLanguageDDL d:\SQLServerDataDefinitionLanguageDDL /d /e /s /y
xcopy e:\SQLServerDataDefinitionLanguageDDL f:\SQLServerDataDefinitionLanguageDDL /d /e /s /y
xcopy e:\SQLServerDataDefinitionLanguageDDL \\Noor\e$\SQLServerDataDefinitionLanguageDDL /d /e /s /y
xcopy e:\SQLServerDataDefinitionLanguageDDL \\Harvest\e$\SQLServerDataDefinitionLanguageDDL /d /e /s /y
xcopy e:\SQLServerDataDefinitionLanguageDDL C:\Users\KAdeniji\OneDrive\SQLServerDataDefinitionLanguageDDL /d /e /s /y
GOTO Exit

:SQLServerDataFiles
setlocal
set "_service=MSSQLSERVER"
rem net pause  %_service% /y
net stop  %_service% /y
xcopy E:\SQLServerDataFiles C:\sqlserverdatafiles /d /e /s /y
xcopy E:\SQLServerDataFiles D:\sqlserverdatafiles /d /e /s /y
xcopy E:\SQLServerDataFiles F:\sqlserverdatafiles /d /e /s /y
xcopy E:\SQLServerDataFiles \\noor\e$\sqlserverdatafiles /d /e /s /y
xcopy E:\SQLServerDataFiles C:\Users\KAdeniji\OneDrive\sqlserverdatafiles /d /e /s /y
rem  net continue %_service% 
net start  %_service% /y
endlocal
GOTO Exit

:SQLServerDataManipulationLanguageDML
xcopy e:\SQLServerDataManipulationLanguageDML c:\SQLServerDataManipulationLanguageDML /d /e /s /y
xcopy e:\SQLServerDataManipulationLanguageDML d:\SQLServerDataManipulationLanguageDML /d /e /s /y
xcopy e:\SQLServerDataManipulationLanguageDML f:\SQLServerDataManipulationLanguageDML /d /e /s /y
xcopy e:\SQLServerDataManipulationLanguageDML \\Noor\e$\SQLServerDataManipulationLanguageDML /d /e /s /y
xcopy e:\SQLServerDataManipulationLanguageDML \\Harvest\e$\SQLServerDataManipulationLanguageDML /d /e /s /y
xcopy e:\SQLServerDataManipulationLanguageDML C:\Users\KAdeniji\OneDrive\SQLServerDataManipulationLanguageDML /d /e /s /y
GOTO Exit

:SQLServerExport
xcopy e:\SQLServerExport c:\SQLServerExport /d /e /s /y
xcopy e:\SQLServerExport d:\SQLServerExport /d /e /s /y
xcopy e:\SQLServerExport f:\SQLServerExport /d /e /s /y
xcopy e:\SQLServerExport \\Noor\e$\SQLServerExport /d /e /s /y
xcopy e:\SQLServerExport C:\Users\KAdeniji\OneDrive\SQLServerExport /d /e /s /y
GOTO Exit

:WebAssembly
xcopy e:\WebAssembly c:\WebAssembly /d /e /s /y
xcopy e:\WebAssembly d:\WebAssembly /d /e /s /y
xcopy e:\WebAssembly f:\WebAssembly /d /e /s /y
xcopy e:\WebAssembly \\Noor\e$\WebAssembly /d /e /s /y
xcopy e:\WebAssembly \\Harvest\e$\WebAssembly /d /e /s /y
xcopy e:\WebAssembly C:\Users\KAdeniji\OneDrive\WebAssembly /d /e /s /y
GOTO Exit

:WinScp
WinScp.com -script=2021-06-15T2015WinScp.txt -log=2021-06-15T2015WinScp.log
GOTO Exit

:WordEngineering
xcopy e:\WordEngineering c:\WordEngineering /d /e /s /y
xcopy e:\WordEngineering d:\WordEngineering /d /e /s /y
xcopy e:\WordEngineering f:\WordEngineering /d /e /s /y
xcopy e:\WordEngineering \\Noor\e$\WordEngineering /d /e /s /y
xcopy e:\WordEngineering \\Harvest\e$\WordEngineering /d /e /s /y
xcopy e:\WordEngineering C:\Users\KAdeniji\OneDrive\WordEngineering /d /e /s /y
GOTO Exit

:WordOfGod
xcopy e:\WordOfGod c:\WordOfGod /d /e /s /y
xcopy e:\WordOfGod d:\WordOfGod /d /e /s /y
xcopy e:\WordOfGod f:\WordOfGod /d /e /s /y
xcopy e:\WordOfGod \\Noor\e$\WordOfGod /d /e /s /y
xcopy e:\WordOfGod \\Harvest\e$\WordOfGod /d /e /s /y
xcopy e:\WordOfGod C:\Users\KAdeniji\OneDrive\WordOfGod /d /e /s /y
GOTO Exit

:Backup
BACKUP DATABASE Account TO DISK = 'e:\SQLServerBackup\Account\Account_2018-04-30.bak' WITH INIT
BACKUP DATABASE ASPNetDB TO DISK = 'e:\SQLServerBackup\ASPNetDB\ASPNetDB_2017-11-03.bak' WITH INI
BACKUP DATABASE Bible TO DISK = 'e:\SQLServerBackup\Bible\Bible_2020-03-23.bak' WITH INIT
BACKUP DATABASE BibleDictionary TO DISK = 'e:\SQLServerBackup\BibleDictionary\BibleDictionary_2017-03-02T1518.bak' WITH INIT
BACKUP DATABASE CodingSample TO DISK = 'e:\SQLServerBackup\CodingSample\CodingSample_2019-06-23.bak' WITH INIT
BACKUP DATABASE ElectronicCopy TO DISK = 'e:\SQLServerBackup\ElectronicCopy\ElectronicCopy_2017-11-02T2114.bak' WITH INIT
BACKUP DATABASE HomeAbroad TO DISK = 'e:\SQLServerBackup\HomeAbroad\HomeAbroa2018-06-25.bak' WITH INIT
BACKUP DATABASE IHaveDecidedToWorkOnAGradualImprovingSystem TO DISK = 'e:\SQLServerBackup\IHaveDecidedToWorkOnAGradualImprovingSystem\IHaveDecidedToWorkOnAGradualImprovingSystem_2019-04-12.bak' WITH INIT
BACKUP DATABASE IShallBeTheirInheritance TO DISK = 'e:\SQLServerBackup\IShallBeTheirInheritance\IShallBeTheirInheritance_2019-08-17.bak' WITH INIT
BACKUP DATABASE Nortdwind TO DISK = 'e:\SQLServerBackup\Nortdwind\Northwin2018-01-01.bak' WITH INIT
BACKUP DATABASE RatingRank TO DISK = 'e:\SQLServerBackup\RatingRank\RatingRank_2018-01-01.bak' WITH INIT
BACKUP DATABASE SQLSharp TO DISK = 'e:\SQLServerBackup\SQLSharp\SQLSharp_2020-05-08.bak' WITH INIT
BACKUP DATABASE URI TO DISK = 'e:\SQLServerBackup\URI\URI_2019-04-12.bak' WITH INIT
BACKUP DATABASE WordEngineering TO DISK = 'e:\SQLServerBackup\WordEngineering\WordEngineering_2020-02-18.bak' WITH INIT

BACKUP DATABASE Master TO DISK = 'e:\SQLServerBackup\Master\Master_2017-01-02.bak' WITH INIT
BACKUP DATABASE Model TO DISK = 'e:\SQLServerBackup\Model\Model_2017-01-02.bak' WITH INIT
BACKUP DATABASE Msdb TO DISK = 'e:\SQLServerBackup\Msdb\Msdb_2017-01-02.bak' WITH INIT

BACKUP DATABASE AManDevelopedInAll TO DISK = 'e:\SQLServerBackup\AManDevelopedInAll\AManDevelopedInAll_2018-02-25.bak' WItd INIT

:DbccCheckIdent
DBCC CHECKIDENT ('IHaveDecidedToWorkOnAGradualImprovingSystem..Contact', RESEED, 24539);
DBCC CHECKIDENT ('IHaveDecidedToWorkOnAGradualImprovingSystem..EmailAddress', RESEED, 22139);
DBCC CHECKIDENT ('IHaveDecidedToWorkOnAGradualImprovingSystem..PhoneNumber', RESEED, 24539);
DBCC CHECKIDENT ('IHaveDecidedToWorkOnAGradualImprovingSystem..UriAddress', RESEED, 12588);

DBCC CHECKIDENT ('URI..UriBenediction', RESEED, 1188);
DBCC CHECKIDENT ('URI..UriBook', RESEED, 1);
DBCC CHECKIDENT ('URI..UriChrist', RESEED, 17865);
DBCC CHECKIDENT ('URI..UriEconomy', RESEED, 2);
DBCC CHECKIDENT ('URI..URIGoogleNews', RESEED, 8477);
DBCC CHECKIDENT ('URI..UriEntertainment', RESEED, 24711);
DBCC CHECKIDENT ('URI..UriPolitics', RESEED, 35);	
DBCC CHECKIDENT ('URI..UriTechnology', RESEED, 2);
DBCC CHECKIDENT ('URI..UriWordEngineering', RESEED, 62606);

DBCC CHECKIDENT ('WordEngineering..ActToGod', RESEED, 1408);
DBCC CHECKIDENT ('WordEngineering..APass', RESEED, 6180);
DBCC CHECKIDENT ('WordEngineering..CaseBasedReasoning', RESEED, 16629);
DBCC CHECKIDENT ('WordEngineering..ClassAssociates', RESEED, 22952);
DBCC CHECKIDENT ('WordEngineering..Contact', RESEED,13325);
DBCC CHECKIDENT ('WordEngineering..ContactURI', RESEED, 5074);
DBCC CHECKIDENT ('WordEngineering..Dream', RESEED, 5138);
DBCC CHECKIDENT ('WordEngineering..Event', RESEED, 1454);
DBCC CHECKIDENT ('WordEngineering..HisWord', RESEED, 154962);
DBCC CHECKIDENT ('WordEngineering..QuestionAndAnswer', RESEED, 2963);
DBCC CHECKIDENT ('WordEngineering..Remember', RESEED, 156052);
DBCC CHECKIDENT ('WordEngineering..SacredText', RESEED, 606);
DBCC CHECKIDENT ('WordEngineering..Software', RESEED, 3595);
DBCC CHECKIDENT ('WordEngineering..StreetAddress', RESEED, 4517);
DBCC CHECKIDENT ('WordEngineering..Telephone', RESEED, 7197); 
DBCC CHECKIDENT ('WordEngineering..TerminologyOfTheDay', RESEED, 50); 
DBCC CHECKIDENT ('WordEngineering..TheComingAdventOfTime', RESEED, 1782);
DBCC CHECKIDENT ('WordEngineering..ToDo', RESEED, 1541);
DBCC CHECKIDENT ('WordEngineering..WhatAreTheStepsYouGoThroughInAJobInterview', RESEED, 2);
DBCC CHECKIDENT ('WordEngineering..WordOfTheDay', RESEED, 24);
DBCC CHECKIDENT ('WordEngineering..WordsInTheBible', RESEED, 481);

--2023-02-19T23:01:00
SET IDENTITY_INSERT URI..URIWordEngineering ON
INSERT URI.[dbo].[URIWordEngineering] ([SequenceOrderId], [Dated], [Title], [URI], [Keyword], [Commentary]) VALUES (57064, CAST(N'2021-08-15T20:22:53.920' AS DateTime), N'Missing Manuals by Dave McFarland', N'sawmac.com', NULL, NULL)
SET IDENTITY_INSERT URI..URIWordEngineering OFF

:Restore
RESTORE DATABASE [AManDevelopedInAll] FROM  DISK = N'E:\SQLServerBackup\AManDevelopedInAll\AManDevelopedInAll_2018-02-25.bak'

:WindowsToCentOS
pscp -pw LinuxPassword e:\SQLServerBackup\IHaveDecidedToWorkOnAGradualImprovingSystem\IHaveDecidedToWorkOnAGradualImprovingSystem_2020-02-13.bak kadeniji@10.0.4.101:/home/kadeniji/SQLServerBackup/IHaveDecidedToWorkOnAGradualImprovingSystem/IHaveDecidedToWorkOnAGradualImprovingSystem_2020-02-13.bak
pscp -pw LinuxPassword e:\SQLServerBackup\URI\URI_2020-02-17.bak kadeniji@10.0.4.101:/home/kadeniji/SQLServerBackup/URI/URI_2020-02-17.bak
pscp -pw LinuxPassword e:\SQLServerBackup\WordEngineering\WordEngineering_2020-02-18.bak kadeniji@10.0.4.101:/home/kadeniji/SQLServerBackup/WordEngineering/WordEngineering_2020-02-18.bak

:SQLScript

:ErrorMessage
http://kenadeniji.wordpress.com
http://kenadeniji.wordpress.com/2015/11/20/ken-adenijis-resume
http://kenadeniji.wordpress.com/2015/12/06/2015-10-23doctoraldissertation
E:\WordEngineering\IIS\WordEngineering\Resume\KenAdenijiResume.pdf
E:\WordEngineering\IIS\WordEngineering\WordUnion\2015-10-23DoctoralDissertation.pdf
C:\Users\kadeniji\OneDrive\WordEngineering\IIS\WordEngineering\WordUnion
KenAdeniji@hotmail.com

2023-04-14T13:25:00 drive.google.com
2023-04-16T13:23:00 "Don't be evil" is a phrase used in Google's corporate code of conduct, which it also formerly preceded as a motto. Following Google's corporate restructuring under the conglomerate Alphabet Inc. in October 2015, Alphabet took "Do the right thing" as its motto, also forming the opening of its corporate code of conduct.
2023-04-16T22:49:00	... 2023-04-16T23:00:00
Microsoft SQL Server Management Studio
No row was updated.
The data in row 1 was not committed.
Error Source: .NET SQL Client Data Provider.
Error Message Execution Timeout Expired:
The timeout perior elapsed prior to completion
of the operation or the server is not responding.
Correct the errors and retry or press
ESC to cancel the changes.
OK Cancel

UriChrist
	LauraStoryMusic.com/#video 				2020-03-06 	17594
2023-04-14T13:25:00 Drive.Google.com Google Drive Almost out of storage.
2023-04-14T14:17:00	Microsoft Windows Operating System clipboard copy paste.
2023-04-14T14:35:00 Dizzy sleepy.
2023-04-15T12:34:00	http://sfbay.craigslist.org
2023-04-16T04:08:00	Lie heard while I slept. Acts 12:23.
Record sufficient in a story that is able to be your word of the day. Associable with you that day. If you only have one space for a story. Like in the creation account there is each day and the work performed that day. You may other data that is related or specific to you, but when you do Remember or a APass data entry it is date specific.
2023-05-23 02:08:43.763	AQ processing ... role. A man is explaining about food role. 04:28 Saliva secretion ... mouth water. 04:34 Saliva secretion ... mouth water.
For the dates columns to be accurate, the author has to be consistent with time. When is the entry made, has consistent to the date has possible. In Genesis 1, the events are recorded according to the days. When is the actual event, when is it written, when is its data entry?
2021-02-06
2023-06-04T16:36:00 	javascriptweekly.com/issues 	JavaScript Weekly 		JavaScript 	2021-02-06
2023-06-04T21:00:00	... 2023-06-04T21:05:00
Microsoft SQL Server Management Studio
No row was updated.
The data in row 1 was not committed.
Error Source: .NET SQL Client Data Provider.
Error Message Execution Timeout Expired:
The timeout perior elapsed prior to completion
of the operation or the server is not responding.
Correct the errors and retry or press
ESC to cancel the changes.
OK Cancel
RightingSoftware.org 	Righting Software by Juval Löwy of IDesign. To my father, Thomas Charles (Tommy) Löwy. Wife, Dina. Originally published: November 27, 2019. For the beginner architect, there are many options; for the master architect, there are but a few. Software Legend, six people, so far. Juval Lowy is 51 years old and was born on 01/01/1969. 		Software Legend, Jew 	2020-01-03 	52631
2023-06-05T16:16:00 Place of Birth: Greece, Greek.
joshclose.github.io/CsvHelper 				2019-04-12 	52237
19:39 EthanMarcotte Responsive Design

Server Error in '/InformationInTransit' Application.
Error: 8645, Severity: 17, State: 1. (Params:). The error is printed in terse mode because there was error during formatting. Tracing, ETW, notifications etc are skipped.
Description: An unhandled exception occurred during the execution of the current web request. Please review the stack trace for more information about the error and where it originated in the code.

Exception Details: System.Data.SqlClient.SqlException: Error: 8645, Severity: 17, State: 1. (Params:). The error is printed in terse mode because there was error during formatting. Tracing, ETW, notifications etc are skipped.


Source Error:

An unhandled exception was generated during the execution of the current web request. Information regarding the origin and location of the exception can be identified using the exception stack trace below.

Stack Trace:


[SqlException (0x80131904): Error: 8645, Severity: 17, State: 1. (Params:). The error is printed in terse mode because there was error during formatting. Tracing, ETW, notifications etc are skipped.
]
   System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction) +3331072
   System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose) +334
   System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady) +4289
   System.Data.SqlClient.SqlDataReader.TryHasMoreRows(Boolean& moreRows) +255
   System.Data.SqlClient.SqlDataReader.TryReadInternal(Boolean setTimeout, Boolean& more) +298
   System.Data.SqlClient.SqlDataReader.Read() +43
   System.Data.Common.DataAdapter.FillLoadDataRow(SchemaMapping mapping) +166
   System.Data.Common.DataAdapter.FillFromReader(DataSet dataset, DataTable datatable, String srcTable, DataReaderContainer dataReader, Int32 startRecord, Int32 maxRecords, DataColumn parentChapterColumn, Object parentChapterValue) +219
   System.Data.Common.DataAdapter.Fill(DataSet dataSet, String srcTable, IDataReader dataReader, Int32 startRecord, Int32 maxRecords) +492
   System.Data.Common.DbDataAdapter.FillInternal(DataSet dataset, DataTable[] datatables, Int32 startRecord, Int32 maxRecords, String srcTable, IDbCommand command, CommandBehavior behavior) +289
   System.Data.Common.DbDataAdapter.Fill(DataSet dataSet, Int32 startRecord, Int32 maxRecords, String srcTable, IDbCommand command, CommandBehavior behavior) +180
   System.Data.Common.DbDataAdapter.Fill(DataSet dataSet, String srcTable) +123
   System.Web.UI.WebControls.SqlDataSourceView.ExecuteSelect(DataSourceSelectArguments arguments) +2947
   System.Web.UI.DataSourceView.Select(DataSourceSelectArguments arguments, DataSourceViewSelectCallback callback) +26
   System.Web.UI.WebControls.BaseDataBoundControl.EnsureDataBound() +134
   System.Web.UI.WebControls.GridView.OnPreRender(EventArgs e) +45
   System.Web.UI.Control.PreRenderRecursiveInternal() +132
   System.Web.UI.Control.PreRenderRecursiveInternal() +227
   System.Web.UI.Control.PreRenderRecursiveInternal() +227
   System.Web.UI.Page.ProcessRequestMain(Boolean includeStagesBeforeAsyncPoint, Boolean includeStagesAfterAsyncPoint) +3671


Version Information: Microsoft .NET Framework Version:4.0.30319; ASP.NET Version:4.8.4330.0 


Server Error in '/InformationInTransit' Application.
There is insufficient system memory in resource pool 'internal' to run this query.
Error: 596, Severity: 21, State: 1. (Params:). The error is printed in terse mode because there was error during formatting. Tracing, ETW, notifications etc are skipped.

A severe error occurred on the current command.  The results, if any, should be discarded.
Description: An unhandled exception occurred during the execution of the current web request. Please review the stack trace for more information about the error and where it originated in the code.

Exception Details: System.Data.SqlClient.SqlException: There is insufficient system memory in resource pool 'internal' to run this query.
Error: 596, Severity: 21, State: 1. (Params:). The error is printed in terse mode because there was error during formatting. Tracing, ETW, notifications etc are skipped.

A severe error occurred on the current command.  The results, if any, should be discarded.

Source Error:

An unhandled exception was generated during the execution of the current web request. Information regarding the origin and location of the exception can be identified using the exception stack trace below.

Stack Trace:


[SqlException (0x80131904): There is insufficient system memory in resource pool 'internal' to run this query.
Error: 596, Severity: 21, State: 1. (Params:). The error is printed in terse mode because there was error during formatting. Tracing, ETW, notifications etc are skipped.

A severe error occurred on the current command.  The results, if any, should be discarded.]
   System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction) +3331072
   System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose) +334
   System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady) +4289
   System.Data.SqlClient.SqlDataReader.TryConsumeMetaData() +89
   System.Data.SqlClient.SqlDataReader.get_MetaData() +101
   System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString, Boolean isInternal, Boolean forDescribeParameterEncryption, Boolean shouldCacheForAlwaysEncrypted) +624
   System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, Boolean inRetry, SqlDataReader ds, Boolean describeParameterEncryptionRequest) +3392
   System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry) +725
   System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method) +84
   System.Data.SqlClient.SqlCommand.ExecuteReader(CommandBehavior behavior, String method) +312
   System.Data.Common.DbDataAdapter.FillInternal(DataSet dataset, DataTable[] datatables, Int32 startRecord, Int32 maxRecords, String srcTable, IDbCommand command, CommandBehavior behavior) +214
   System.Data.Common.DbDataAdapter.Fill(DataSet dataSet, Int32 startRecord, Int32 maxRecords, String srcTable, IDbCommand command, CommandBehavior behavior) +180
   System.Data.Common.DbDataAdapter.Fill(DataSet dataSet, String srcTable) +123
   System.Web.UI.WebControls.SqlDataSourceView.ExecuteSelect(DataSourceSelectArguments arguments) +2947
   System.Web.UI.WebControls.ListControl.OnDataBinding(EventArgs e) +389
   System.Web.UI.WebControls.ListControl.PerformSelect() +44
   System.Web.UI.WebControls.BaseDataBoundControl.EnsureDataBound() +134
   System.Web.UI.WebControls.ListControl.OnPreRender(EventArgs e) +36
   System.Web.UI.Control.PreRenderRecursiveInternal() +132
   System.Web.UI.Control.PreRenderRecursiveInternal() +227
   System.Web.UI.Control.PreRenderRecursiveInternal() +227
   System.Web.UI.Control.PreRenderRecursiveInternal() +227
   System.Web.UI.Page.ProcessRequestMain(Boolean includeStagesBeforeAsyncPoint, Boolean includeStagesAfterAsyncPoint) +3671


Version Information: Microsoft .NET Framework Version:4.0.30319; ASP.NET Version:4.8.4330.0

PaulAngone.com 	Millennial generation 			2018-06-30 	16341

<h5 id="ScriptureTableChapterIDColumn">The Scripture Table's ChapterID Column</h5>

2023-06-08 How do you anticipate people as others?

2023-06-17T20:43:00 Microsoft Windows operating system, Mozilla Firefox browser
2023-06-30 Sleeping period. For example, from 12:02 to 13:16. Between 12:02 ... 13:16. Date created: 2023-06-05. Date updated: 2023-06-30. FromUntil: 25 days.
2023-07-01T20:25:00 ObjectPlayGround.com 	James Shore 		UML, JavaScript 	2022-07-16 	59379
2023-07-09T20:38:00 ... 2023-07-09T20:43:00 Microsoft SQL Server Management Studio data loss error.
19:55 ... 20:39 contact@enhanceit.com
20:57 Microsoft SQL Server Management Studio database restore WordEngineering
21:08 Urine.
19:55 ... 20:36 contact@enhanceit.com 19:26 ... 21:27 Microsoft SQL Server Management Studio user interface (UI) grid data loss error. 20:57 ... 21:27 Microsoft SQL Server WordEngineering restore.
2023-07-10T05:23:00
Since 2023-07-08T23:30:00 I have not been able to login to adriel nor copy files using WinSCP.
2023-07-10T12:07:00 ... 2023-07-10T12:46:00
Database Engineer - job post
Total Entertainment Network (TEN)
500 Howard Street, San Francisco, CA 94105
Profile insights
Here’s how your profile
aligns with the job description
Skills

    UNIX

Data modeling
Windows
Do you have experience in UNIX?
Education

    Bachelor's degree

In this role you will be responsible for supporting the analysis, design and deployment of projects related to TEN's Server Engineering Group. You will be required to provide input to the logical data modeling and architecture team, analyze and document corporate application requirements, provide applications performance and optimization recommendations and occasionally lead small project teams. Other responsibilities include ongoing application development and maintenance, develop stored procedures, provide 2nd level support to the Operation team, participate in design and architecture decisions providing alternatives and input relative to existing application and systems. A BS in Computer Science or equivalent, 2-3 years of client-server development (Sybase or MS SQL Server preferred), working knowledge of high-level development environments like Powerbuilder or Visual Basic, and high level languages like C and C++ is a plus. Proven experience with Sybase CT-LIB or other RDBMS client libraries, working knowledge of Win95 and/or Windows NT, knowledge of UNIX concepts. General knowledge of logical data modeling techniques and understanding of object-oriented technologies. Strong interpersonal and communication skills as well proven success working in a fast-paced and growing industry.

To apply for this position e-mail resumes@ten.net, fax to (415)778-3512 or mail to: TEN Human Resources Dept., 500 Howard Street, Suite 300, San Francisco, CA 94105.
If you require alternative methods of application or screening, you must approach the employer directly to request this as Indeed is not responsible for the employer's application process.

2023-07-10T12:47:00 ... 2023-07-10T12:49:00
.Net Developer - job post
DISH
8,340 reviews
United States
$65,800 a year
Salary meets cost of livingBased on surveys from Indeed users
Profile insights
Here’s how your profile
aligns with the job description
Skills

    PL/SQL

CI/CD
XML
Do you have experience in PL/SQL?
Education

    Master's degree

Bachelor's degree
Department Summary
DISH is a Fortune 200 company that continues to redefine the communications industry. Our legacy is innovation and a willingness to challenge the status quo, including reinventing ourselves. We disrupted the pay-TV industry in the mid-90s with the launch of the DISH satellite TV service, taking on some of the largest U.S. corporations in the process, and grew to be the fourth-largest pay-TV provider. We are doing it again with the first live, internet-delivered TV service – Sling TV – that bucks traditional pay-TV norms and gives consumers a truly new way to access and watch television.

Now we have our sights set on upending the wireless industry and unseating the entrenched incumbent carriers.

We are driven by curiosity, pride, adventure, and a desire to win – it’s in our DNA. We’re looking for people with boundless energy, intelligence, and an overwhelming need to achieve to join our team as we embark on the next chapter of our story.

Opportunity is here. We are DISH.


Job Duties and Responsibilities

In the position of Senior .Net Developer, you will work with IT Internal Web Applications and external Support and Delivery teams and internal clients. Employees will provide support, technical design and development solutions and best practices within the IT development team to deliver coordinated software solutions. The developer will provide Information Technology solutions in the areas of .Net Core technologies. The developer from this position will also provide a variety of services ranging from application architecture, development, day-to-day support, maintenance and trouble-shooting to improve, advance and simplify the development process.
More specifically, Employee , will perform the following duties:

    Provide information system technology solutions by adhering to Dish Network prescribed life-cycle tools and methodologies
    Analyze information system requirements, create designs, and provide documentation by utilizing Dish Network specified tools and methodologies
    Create applications from scratch, maintain existing systems and provide user support.
    Maintains existing functionality and develops new features in web based in-house custom applications.
    Leads projects by providing level of efforts of assignments, coordinating resources for development, analyzing complex business requirements and producing high quality design documents and code.
    Maintains and develops backend integration services interacting with other Dish systems.
    Work with the IT Project Managers to understand the deadlines and migrate the code to TEST and PROD environments
    Work with Business Analysts / Product Owners to ensure the requirements align with the end user perspective.
    Research prod issues by knowing the existing code. Provide a variety of services ranging from day-to-day support, maintenance and trouble-shooting to improve, advance, or simplify Dish Network business processes
    Provide leadership or project management within application development teams to deliver coordinated software solutions
    Update PCI audit documentation yearly as required and perform design/architecture documentation as required.


Skills, Experience and Requirements

Skills, Experience and Requirements

    Required to be familiar with web application development and .Net core expertise.
    6+ years of relevant experience.
    Minimum of 5 years .Net C# object oriented programming experience in web based environment.
    Minimum 5 years of .Net Core, ASP.NET MVC5, jQuery, Angular, Angular JS, Bootstrap, HTML5, CSS3, XML, JavaScript, JSON, AJAX, SOAP, Web API, REST Services, WCF experience.
    Proficient with ReactJS.
    AWS, CI/CD experience preferred .
    Solid knowledge of one RDBMS system such as SQL Server.
    Oracle PLSQL, Database Triggers and Stored Procedures
    VS code, Visual Studio 2019/2022 and .Net Framework 4.5+
    Experienced in a fast paced Agile Development Environment
    Security OWASP Top 10 Vulnerability Mitigation.
    Okta authentication process.
    Source Control in Git Lab.
    Ability to debug and quickly diagnose production issues
    Basic F5 load balancing understanding.
    Ability to learn modern technologies faster and need to understand how these technologies will help Dish to improve customer experience is an important requirement of the Senior Engineer – Software.
    It is also very important to understand the business process to implement appropriate technologies in the customer service organizations.
    Good knowledge of design patterns, programming and process knowledge required to work in a fast-paced environment which is indicative of a specialty occupation in the telecommunications and IT industry.
    Bachelor’s degree or Master’s degree in a computer Science field such as Computer Applications or Computer Information Systems, or the equivalent in education and work experience.

#LI-CS5

Salary Range

Compensation: $65,800.00/Year
Compensation and Benefits

We also offer versatile health perks, including flexible spending accounts, HSA, a 401(k) Plan with company match, ESPP, career opportunities, and a flexible time away plan; all benefits can be viewed here: DISH Benefits.

The base pay range shown is a guideline. Individual total compensation will vary based on factors such as qualifications, skill level, and competencies; compensation is based on the role's location and is subject to change based on work location. Candidates need to successfully complete a pre-employment screen, which may include a drug test and DMV check.

.Net Developer

    United States
    Information Technology
    78537

mail_outline

Get future jobs matching this search
or
Job Description
Department Summary

DISH is a Fortune 200 company that continues to redefine the communications industry. Our legacy is innovation and a willingness to challenge the status quo, including reinventing ourselves. We disrupted the pay-TV industry in the mid-90s with the launch of the DISH satellite TV service, taking on some of the largest U.S. corporations in the process, and grew to be the fourth-largest pay-TV provider. We are doing it again with the first live, internet-delivered TV service – Sling TV – that bucks traditional pay-TV norms and gives consumers a truly new way to access and watch television.


Now we have our sights set on upending the wireless industry and unseating the entrenched incumbent carriers.

We are driven by curiosity, pride, adventure, and a desire to win – it’s in our DNA. We’re looking for people with boundless energy, intelligence, and an overwhelming need to achieve to join our team as we embark on the next chapter of our story.

Opportunity is here. We are DISH.

Job Duties and Responsibilities

In the position of Senior .Net Developer, you will work with IT Internal Web Applications and external Support and Delivery teams and internal clients. Employees will provide support, technical design and development solutions and best practices within the IT development team to deliver coordinated software solutions. The developer will provide Information Technology solutions in the areas of  .Net Core technologies. The developer from this position will also provide a variety of services ranging from application architecture, development, day-to-day support, maintenance and trouble-shooting to improve, advance and simplify the development process.

 More specifically, Employee , will perform the following duties: 

    Provide information system technology solutions by adhering to Dish Network prescribed life-cycle tools and methodologies
    Analyze information system requirements, create designs, and provide documentation by utilizing Dish Network specified tools and methodologies
    Create applications from scratch, maintain existing systems and provide user support.
    Maintains existing functionality and develops new features in web based in-house custom applications.
    Leads projects by providing level of efforts of assignments, coordinating resources for development, analyzing complex business requirements and producing high quality design documents and code.
    Maintains and develops backend integration services interacting with other Dish systems.
    Work with the IT Project Managers to understand the deadlines and migrate the code to TEST and PROD environments
    Work with Business Analysts / Product Owners to ensure the requirements align with the end user perspective.
    Research prod issues by knowing the existing code. Provide a variety of services ranging from day-to-day support, maintenance and trouble-shooting to improve, advance, or simplify Dish Network business processes
    Provide leadership or project management within application development teams to deliver coordinated software solutions 
    Update PCI audit documentation yearly as required and perform design/architecture documentation as required.


Skills, Experience and Requirements

Skills, Experience and Requirements

    Required to be familiar with web application development and .Net core expertise. 
    6+ years of relevant experience.
    Minimum of 5 years .Net C# object oriented programming experience in web based environment.
    Minimum 5 years of .Net Core, ASP.NET MVC5, jQuery, Angular, Angular JS, Bootstrap, HTML5, CSS3, XML, JavaScript, JSON, AJAX, SOAP, Web API, REST Services, WCF experience.
    Proficient with ReactJS.
    AWS, CI/CD experience preferred .
    Solid knowledge of one RDBMS system such as SQL Server.
    Oracle PLSQL, Database Triggers and Stored Procedures  
    VS code, Visual Studio 2019/2022 and .Net Framework 4.5+ 
    Experienced in a fast paced Agile Development Environment
    Security OWASP Top 10 Vulnerability Mitigation.
    Okta authentication process.
    Source Control in Git Lab.
    Ability to debug and quickly diagnose production issues
    Basic F5 load balancing understanding.
    Ability to learn modern technologies faster and need to understand how these technologies will help Dish to improve customer experience is an important requirement of the Senior Engineer – Software. 
    It is also very important to understand the business process to implement appropriate technologies in the customer service organizations. 
    Good knowledge of design patterns, programming and process knowledge required to work in a fast-paced environment which is indicative of a specialty occupation in the telecommunications and IT industry.
    Bachelor’s degree or Master’s degree in a computer Science field such as Computer Applications or Computer Information Systems, or the equivalent in education and work experience.

#LI-CS5

Salary Range

Compensation: $65,800.00/Year
Compensation and Benefits

We also offer versatile health perks, including flexible spending accounts, HSA, a 401(k) Plan with company match, ESPP, career opportunities, and a flexible time away plan; all benefits can be viewed here: DISH Benefits.   

The base pay range shown is a guideline. Individual total compensation will vary based on factors such as qualifications, skill level, and competencies; compensation is based on the role's location and is subject to change based on work location. Candidates need to successfully complete a pre-employment screen, which may include a drug test and DMV check.

Need help finding the right job?

We can recommend jobs specifically for you! Click here to get started.
logo Go back to the welcome page

DISH endeavors to make http://careers.dish.com accessible to any and all users. If you would like to contact us regarding the accessibility of our website or need assistance completing the application process, please contact accessibility@dish.com. This contact information is for accommodation requests only; you may not use this contact information to inquire about the status of applications.

We pride ourselves on developing and promoting talent as an Equal Employment Opportunity Employer - Veteran/Disability. All qualified applicants will receive consideration for employment without regard to race, color, religion, sex, sexual orientation, gender identity, national origin, disability, or protected veteran status. We are a true merit-based organization and work hard so there are no artificial barriers to one's potential success. DISH is committed to a workforce where everyone's opportunities are limitless.

Consistent with this commitment, DISH will endeavor to provide reasonable accommodation to otherwise qualified job applicants and employees with known physical or mental disabilities, unless doing so poses an undue hardship on the Company, poses a direct threat of substantial harm to the employee or others, or is otherwise not required by law.

http://jobs.dish.com/jobs/78537?iis=Job+Board&iisn=rd_indeed&lang=en-us&mode=job&p_sid=AwwmNOb&p_uid=SNCXDiG6nZ&ss=paid&utm_campaign=technology&utm_content=pj_board&utm_medium=jobad&utm_source=indeed&dclid=CNS50cr0hIADFQAJRAgdEPcIig

2023-07-10T13:09:00
Indeed.com C#
Teeth
(Ko look good)
Dizzy sleep
(O show ju)
(We are proving difficult)

2023-07-10T13:14:00
Indeed.com JavaScript

2023-07-10T13:25:00
Web Accessibility - job post
vebyond corp
Sunnyvale, CA
$120,000 - $130,000 a year - Full-time

Amwell Commons, 390 Amwell Road, Bldg #1, Suite #107 Hillsborough, New Jersey, USA – 088 44
+1 (908) 359-8416
usa@vbeyond.com

2023-07-10T13:31:00 ... 2023-07-10T13:33:00 Microsoft Windows clipboard copy and paste error. Web Accessibility - job post vebyond corp Sunnyvale, CA $120,000 - $130,000 a year - Full-time

2023-07-10T13:33:00 Teeth

2023-07-10T13:40:00 (Duro)

2023-07-10T13:48:00
https://www.google.com/ 

You're almost out of storage

Avoid interruptions to Gmail, Drive, and Google Photos by getting more storage with Google One
Storage (90% full)
13.58 GB of 15 GB used

13:54:00
http://192.168.1.254/cgi-bin/autodetect.ha


2023-07-10T13:46:00 ... 2023-07-10T14:00:00
Website Development Manager - job post
Crain Communications

careers@crain.com, referrals@crain.com


:Exit
