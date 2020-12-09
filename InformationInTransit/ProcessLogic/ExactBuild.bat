REM csc Exact.cs /reference:..\Bin\Debug\InformationInTransit.dll
csc /main:InformationInTransit.ProcessLogic.Exact /reference:mscorlib.dll,System.Core.dll Exact.cs ..\DataAccess\DataCommand.cs 