@ECHO OFF
REM Create a solution
dotnet new sln
REM Create the Console app
dotnet new console -o App
CD App
dotnet add package GraphQL
dotnet run
