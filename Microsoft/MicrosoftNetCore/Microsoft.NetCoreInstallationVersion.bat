@ECHO OFF
REM 2023-04-14T19:00:00
REM docs.microsoft.com/en-us/dotnet/core
REM docs.microsoft.com/en-us/dotnet/csharp
dotnet --version
dotnet --list-runtimes
dotnet --list-sdks
dotnet sdk check
REM dotnet new globaljson -sdk-version 5.0.400
