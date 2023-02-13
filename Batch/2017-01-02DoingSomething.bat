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
DBCC CHECKIDENT ('URI..UriWordEngineering', RESEED, 60540);

DBCC CHECKIDENT ('WordEngineering..ActToGod', RESEED, 1246);
DBCC CHECKIDENT ('WordEngineering..APass', RESEED, 4323);
DBCC CHECKIDENT ('WordEngineering..CaseBasedReasoning', RESEED, 16629);
DBCC CHECKIDENT ('WordEngineering..ClassAssociates', RESEED, 22952);
DBCC CHECKIDENT ('WordEngineering..Contact', RESEED, 13040);
DBCC CHECKIDENT ('WordEngineering..ContactURI', RESEED, 5015);
DBCC CHECKIDENT ('WordEngineering..Dream', RESEED, 5138);
DBCC CHECKIDENT ('WordEngineering..Event', RESEED, 1454);
       
DBCC CHECKIDENT ('WordEngineering..QuestionAndAnswer', RESEED, 2963);
DBCC CHECKIDENT ('WordEngineering..Remember', RESEED, 151904);
DBCC CHECKIDENT ('WordEngineering..SacredText', RESEED, 586);
DBCC CHECKIDENT ('WordEngineering..Software', RESEED, 3595);
DBCC CHECKIDENT ('WordEngineering..StreetAddress', RESEED, 4517);
DBCC CHECKIDENT ('WordEngineering..Telephone', RESEED, 7197); 
DBCC CHECKIDENT ('WordEngineering..TerminologyOfTheDay', RESEED, 50); 
DBCC CHECKIDENT ('WordEngineering..TheComingAdventOfTime', RESEED, 1782);
DBCC CHECKIDENT ('WordEngineering..ToDo', RESEED, 1541);
DBCC CHECKIDENT ('WordEngineering..WhatAreTheStepsYouGoThroughInAJobInterview', RESEED, 2);
DBCC CHECKIDENT ('WordEngineering..WordOfTheDay', RESEED, 24);
DBCC CHECKIDENT ('WordEngineering..WordsInTheBible', RESEED, 481);

SET IDENTITY_INSERT ClassAssociates ON
SET IDENTITY_INSERT ClassAssociates OFF

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
KenAdeniji@hotmail.com

2023-01-21T18:45:00 URIMaintenanceWebForm.aspx SequenceOrderID  47654
2023-01-27T19:49:00 SELECT BookID, ChapterID, VerseID, AmericanStandardBible, BibleInBasicEnglish, DarbyEnglishBible, KingJamesVersion, WebsterBible, WorldEnglishBible, YoungLiteralTranslation, ChapterIDSequence, VerseIDSequence,                           AccordingToManyIHaveSpokenID, Testament, BookTitle, ScriptureReference, ChapterIDSequencePercent, VerseIDSequencePercent, BibleReference, BookGroup, BookAuthor FROM Scripture_View ORDER BY VerseIDSequence
2023-01-30T12:43:00 github.com/ept/ddia-references

2023-02-01T13:32:00

TITLE: Microsoft SQL Server Management Studio
------------------------------

Exception has been thrown by the target of an invocation. (mscorlib)

------------------------------
ADDITIONAL INFORMATION:

Index was out of range. Must be non-negative and less than the size of the collection.
Parameter name: index (mscorlib)

------------------------------
BUTTONS:

OK
------------------------------

===================================

Exception has been thrown by the target of an invocation. (mscorlib)

------------------------------
Program Location:

   at System.RuntimeMethodHandle.InvokeMethod(Object target, Object[] arguments, Signature sig, Boolean constructor)
   at System.Reflection.RuntimeMethodInfo.UnsafeInvokeInternal(Object obj, Object[] parameters, Object[] arguments)
   at System.Delegate.DynamicInvokeImpl(Object[] args)
   at System.Windows.Forms.Control.InvokeMarshaledCallbackDo(ThreadMethodEntry tme)
   at System.Windows.Forms.Control.InvokeMarshaledCallbackHelper(Object obj)
   at System.Threading.ExecutionContext.RunInternal(ExecutionContext executionContext, ContextCallback callback, Object state, Boolean preserveSyncCtx)
   at System.Threading.ExecutionContext.Run(ExecutionContext executionContext, ContextCallback callback, Object state, Boolean preserveSyncCtx)
   at System.Threading.ExecutionContext.Run(ExecutionContext executionContext, ContextCallback callback, Object state)
   at System.Windows.Forms.Control.InvokeMarshaledCallback(ThreadMethodEntry tme)
   at System.Windows.Forms.Control.InvokeMarshaledCallbacks()
   at System.Windows.Forms.Control.WndProc(Message& m)
   at System.Windows.Forms.Control.ControlNativeWindow.OnMessage(Message& m)
   at System.Windows.Forms.Control.ControlNativeWindow.WndProc(Message& m)
   at System.Windows.Forms.NativeWindow.DebuggableCallback(IntPtr hWnd, Int32 msg, IntPtr wparam, IntPtr lparam)
   at System.Windows.Forms.UnsafeNativeMethods.DispatchMessageW(MSG& msg)
   at System.Windows.Forms.Application.ComponentManager.System.Windows.Forms.UnsafeNativeMethods.IMsoComponentManager.FPushMessageLoop(IntPtr dwComponentID, Int32 reason, Int32 pvLoopData)
   at System.Windows.Forms.Application.ThreadContext.RunMessageLoopInner(Int32 reason, ApplicationContext context)
   at System.Windows.Forms.Application.ThreadContext.RunMessageLoop(Int32 reason, ApplicationContext context)
   at System.Windows.Forms.Application.RunDialog(Form form)
   at System.Windows.Forms.Form.ShowDialog(IWin32Window owner)
   at System.Windows.Forms.Form.ShowDialog()
   at Microsoft.SqlServer.Management.SqlMgmt.RunningFormsTable.RunningFormsTableImpl.ThreadStarter.StartThread()

===================================

Index was out of range. Must be non-negative and less than the size of the collection.
Parameter name: index (mscorlib)

------------------------------
Program Location:

   at System.Collections.ArrayList.get_Item(Int32 index)
   at System.Windows.Forms.DataGridViewRowCollection.SharedRow(Int32 rowIndex)
   at System.Windows.Forms.DataGridViewRowCollection.get_Item(Int32 index)
   at Microsoft.SqlServer.Management.SqlScriptPublish.GeneratePublishPage.UpdateActionStatus(Int32 actionId, String action, ResultType result, Exception exception)
   at Microsoft.SqlServer.Management.SqlScriptPublish.GeneratePublishPage.worker_RunWorkerCompleted(Object sender, RunWorkerCompletedEventArgs e)
   at System.ComponentModel.BackgroundWorker.OnRunWorkerCompleted(RunWorkerCompletedEventArgs e)
   at System.ComponentModel.BackgroundWorker.AsyncOperationCompleted(Object arg)

12:59 Dizzy sleepy (Gbogbo eyan so fun wa). Either 2023-01-31 or 2023-02-01 I put my finger inside twin sibling's asshole. 13:40 2023-02-01T13:32:00

TITLE: Microsoft SQL Server Management Studio
------------------------------

Exception has been thrown by the target of an invocation. (mscorlib)

------------------------------
ADDITIONAL INFORMATION:

Index was out of range. Must be non-negative and less than the size of the collection.
Parameter name: index (mscorlib)

------------------------------
BUTTONS:

OK
------------------------------

===================================

Exception has been thrown by the target of an invocation. (mscorlib)

------------------------------
Program Location:

   at System.RuntimeMethodHandle.InvokeMethod(Object target, Object[] arguments, Signature sig, Boolean constructor)
   at System.Reflection.RuntimeMethodInfo.UnsafeInvokeInternal(Object obj, Object[] parameters, Object[] arguments)
   at System.Delegate.DynamicInvokeImpl(Object[] args)
   at System.Windows.Forms.Control.InvokeMarshaledCallbackDo(ThreadMethodEntry tme)
   at System.Windows.Forms.Control.InvokeMarshaledCallbackHelper(Object obj)
   at System.Threading.ExecutionContext.RunInternal(ExecutionContext executionContext, ContextCallback callback, Object state, Boolean preserveSyncCtx)
   at System.Threading.ExecutionContext.Run(ExecutionContext executionContext, ContextCallback callback, Object state, Boolean preserveSyncCtx)
   at System.Threading.ExecutionContext.Run(ExecutionContext executionContext, ContextCallback callback, Object state)
   at System.Windows.Forms.Control.InvokeMarshaledCallback(ThreadMethodEntry tme)
   at System.Windows.Forms.Control.InvokeMarshaledCallbacks()
   at System.Windows.Forms.Control.WndProc(Message& m)
   at System.Windows.Forms.Control.ControlNativeWindow.OnMessage(Message& m)
   at System.Windows.Forms.Control.ControlNativeWindow.WndProc(Message& m)
   at System.Windows.Forms.NativeWindow.DebuggableCallback(IntPtr hWnd, Int32 msg, IntPtr wparam, IntPtr lparam)
   at System.Windows.Forms.UnsafeNativeMethods.DispatchMessageW(MSG& msg)
   at System.Windows.Forms.Application.ComponentManager.System.Windows.Forms.UnsafeNativeMethods.IMsoComponentManager.FPushMessageLoop(IntPtr dwComponentID, Int32 reason, Int32 pvLoopData)
   at System.Windows.Forms.Application.ThreadContext.RunMessageLoopInner(Int32 reason, ApplicationContext context)
   at System.Windows.Forms.Application.ThreadContext.RunMessageLoop(Int32 reason, ApplicationContext context)
   at System.Windows.Forms.Application.RunDialog(Form form)
   at System.Windows.Forms.Form.ShowDialog(IWin32Window owner)
   at System.Windows.Forms.Form.ShowDialog()
   at Microsoft.SqlServer.Management.SqlMgmt.RunningFormsTable.RunningFormsTableImpl.ThreadStarter.StartThread()

===================================

Index was out of range. Must be non-negative and less than the size of the collection.
Parameter name: index (mscorlib)

------------------------------
Program Location:

   at System.Collections.ArrayList.get_Item(Int32 index)
   at System.Windows.Forms.DataGridViewRowCollection.SharedRow(Int32 rowIndex)
   at System.Windows.Forms.DataGridViewRowCollection.get_Item(Int32 index)
   at Microsoft.SqlServer.Management.SqlScriptPublish.GeneratePublishPage.UpdateActionStatus(Int32 actionId, String action, ResultType result, Exception exception)
   at Microsoft.SqlServer.Management.SqlScriptPublish.GeneratePublishPage.worker_RunWorkerCompleted(Object sender, RunWorkerCompletedEventArgs e)
   at System.ComponentModel.BackgroundWorker.OnRunWorkerCompleted(RunWorkerCompletedEventArgs e)
   at System.ComponentModel.BackgroundWorker.AsyncOperationCompleted(Object arg)
 
2023-02-01T15:13:00 Microsoft Windows Explorer click on .sql file, Microsoft SQL Server Management Studio opens. 15:26 Microsoft Windows Explorer click on .sql file, Microsoft SQL Server Management Studio opens.
2023-02-04T18:33:00 https://learn.microsoft.com/en-us/sql/relational-databases/backup-restore/restore-a-database-to-a-new-location-sql-server?view=sql-server-ver16

2023-02-05T16:07:00
Microsoft Windows [Version 10.0.18363.1556]
(c) 2019 Microsoft Corporation. All rights reserved.

C:\Users\kadeniji>ipconfig

Windows IP Configuration


Ethernet adapter Internet:

   Connection-specific DNS Suffix  . : attlocal.net
   IPv4 Address. . . . . . . . . . . : 192.168.1.71
   Subnet Mask . . . . . . . . . . . : 255.255.255.0
   Default Gateway . . . . . . . . . : 192.168.1.254

Ethernet adapter Intranet:

   Connection-specific DNS Suffix  . :
   IPv4 Address. . . . . . . . . . . : 10.0.4.105
   Subnet Mask . . . . . . . . . . . : 255.255.255.0
   Default Gateway . . . . . . . . . : 10.0.4.70

C:\Users\kadeniji>ipconfig /release

Windows IP Configuration


Ethernet adapter Internet:

   Connection-specific DNS Suffix  . :
   Default Gateway . . . . . . . . . :

Ethernet adapter Intranet:

   Connection-specific DNS Suffix  . :
   IPv4 Address. . . . . . . . . . . : 10.0.4.105
   Subnet Mask . . . . . . . . . . . : 255.255.255.0
   Default Gateway . . . . . . . . . : 10.0.4.70

C:\Users\kadeniji>

C:\Users\kadeniji>ping harvest
Ping request could not find host harvest. Please check the name and try again.

C:\Users\kadeniji>ping noor

Pinging noor [10.0.4.7] with 32 bytes of data:
Reply from 10.0.4.7: bytes=32 time<1ms TTL=128
Reply from 10.0.4.7: bytes=32 time=2ms TTL=128
Reply from 10.0.4.7: bytes=32 time=2ms TTL=128
Reply from 10.0.4.7: bytes=32 time=2ms TTL=128

Ping statistics for 10.0.4.7:
    Packets: Sent = 4, Received = 4, Lost = 0 (0% loss),
Approximate round trip times in milli-seconds:
    Minimum = 0ms, Maximum = 2ms, Average = 1ms
:Exit
