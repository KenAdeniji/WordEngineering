REM csc RelatedVerses.cs /reference:..\Bin\Debug\InformationInTransit.dll
csc /main:InformationInTransit.ProcessLogic.RelatedVerses /reference:mscorlib.dll,System.Core.dll RelatedVerses.cs ..\DataAccess\DataCommand.cs CommandLineArguments.cs