all: CommandLineArguments.dll

CommandLineArguments.dll: AssemblyInfo.cs CommandLineArguments.cs 
 REM sn -k "D:\GACKey\PeterHal.snk"
 csc /define:DEBUG /keyfile:"D:\GACKey\PeterHal.snk" /out:CommandLineArguments.dll /target:library AssemblyInfo.cs CommandLineArguments.cs
 gacutil /i CommandLineArguments.dll /f
 REM RegEdt32 [HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\.NETFramework\AssemblyFolders\CommandLineArguments]@="D:\\PeterHal\\CommandLineArguments"