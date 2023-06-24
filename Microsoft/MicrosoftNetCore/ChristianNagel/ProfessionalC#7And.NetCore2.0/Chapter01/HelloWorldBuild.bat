@ECHO OFF
REM 2023-06-22T20:30:00 wiley.com/en-us/Professional+C%23+7+and+NET+Core+2+0-p-9781119449263
REM Professional C# 7 and .NET Core 2.0 Christian Nagel ISBN: 978-1-119-44926-3 March 2018 1440 Pages
REM The command below creates a HelloWorld directory and adds the source code file Program.cs and project file HelloWorld.csproj.
REM		It also includes a dortnet restore where all NuGet packages are downloaded.
dotnet new console --output HelloWorld
CD HelloWorld
dotnet build --configuration Release
dotnet run
dotnet bin/Release/net8.0/HelloWorld.dll