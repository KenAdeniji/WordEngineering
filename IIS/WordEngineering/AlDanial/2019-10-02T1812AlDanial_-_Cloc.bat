@ECHO OFF
REM E:\Software\AlDanial\cloc-1.84.exe \WordEngineering\InformationInTransit\ProcessCode\*.cs >AlDanial_-_Cloc_-_ProcessCode.txt
REM E:\Software\AlDanial\cloc-1.84.exe \WordEngineering\InformationInTransit\ProcessLogic\*.cs >AlDanial_-_Cloc_-_ProcessLogic.txt

REM E:\Software\AlDanial\cloc-1.84.exe \WordEngineering\IIS\WordEngineering\WordUnion\9432.js >AlDanial_-_Cloc_-_9432.txt

COPY /Y AlDanial_-_Cloc_-_ProcessCode.txt + AlDanial_-_Cloc_-_ProcessLogic.txt + AlDanial_-_Cloc_-_9432.txt AlDanial_-_Cloc_-_All.txt
