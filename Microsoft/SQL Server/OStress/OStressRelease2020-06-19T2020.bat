@ECHO OFF
REM 2020-06-19 Created.
setlocal

set "_app=E:\Program Files\Microsoft Corporation\RMLUtils\ostress.exe"

rem -n number of threads
rem -r number of repetitions
rem -q supresss query output

"%_app%" -E -Q"set nocount on; select top 1 name from sys.databases" -n5 -r2 -q

endlocal

