CSC /reference:..\Bin\CommandLineArguments.dll,..\Bin\InformationInTransit.dll,..\Bin\Newtonsoft.Json.dll GrowingWithSchool.cs 
REM "E:\Program Files (x86)\Microsoft\ILMerge\ILMerge.exe" /lib:..\Bin /out:GrowingWithSchoolILMerge.exe GrowingWithSchool.exe
GrowingWithSchool.exe /sqlQuery:"SELECT * FROM Bible..BibleBook ORDER BY BookId" /filenameJson:"BibleBook.Json"
REM 2014-12-30 
GrowingWithSchool.exe /sqlQuery:"SELECT * FROM WordEngineering..GodTitle ORDER BY SequenceOrderId" /filenameJson:"GodTitle.Json"
