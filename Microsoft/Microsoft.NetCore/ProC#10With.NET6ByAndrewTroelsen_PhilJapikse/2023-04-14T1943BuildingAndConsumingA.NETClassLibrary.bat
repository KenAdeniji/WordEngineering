@ECHO OFF
dotnet new sln -n ProCSharp10With.NET6
dotnet new classlib -lang c# -n ProCSharp10With.NET6Library -o .\ProCSharp10With.NET6Library
dotnet sln .\ProCSharp10With.NET6.sln add .\ProCSharp10With.NET6Library

REM 2023-04-14T20:35:00 http://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-new-sdk-templates#webapi

REM 2023-04-14T20:53:00 https://dotnettutorials.net/lesson/creating-asp-net-core-web-api-project-using-net-core-cli/

dotnet new webapi -o .\ProCSharp10WithNET6WebAPI
dotnet build

cd ProCSharp10WithNET6WebAPI
dotnet run

http://localhost:5063/swagger

http://localhost:5063/WeatherForecast
