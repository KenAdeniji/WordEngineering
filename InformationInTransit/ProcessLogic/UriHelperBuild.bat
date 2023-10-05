@ECHO OFF
REM 2023-0925T16:31:00 http://learn.microsoft.com/en-us/sql/relational-databases/user-defined-functions/create-clr-functions?view=sql-server-ver16
csc /define:DEBUG /debug:full /out:\WordOfGod\bin\UriHelper.cs /target:library UriHelper.cs
