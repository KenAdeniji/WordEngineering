@ECHO OFF
dotnet new sln -n ProCSharp10WithNET6
dotnet new classlib -lang c# -n ProCSharp10WithNET6Library -o .\ProCSharp10WithNET6Library
dotnet sln .\ProCSharp10WithNET6.sln add .\ProCSharp10WithNET6Library

REM 2023-04-14T20:35:00 http://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-new-sdk-templates#webapi

REM 2023-04-14T20:53:00 http://dotnettutorials.net/lesson/creating-asp-net-core-web-api-project-using-net-core-cli/

dotnet new webapi -o .\ProCSharp10WithNET6WebAPI

REM 2023-04-15T04:49:00
REM dotnet sln .\ProCSharp10WithNET6.sln add .\ProCSharp10WithNET6WebAPI

dotnet build

cd ProCSharp10WithNET6WebAPI
REM 2023-04-15T05:12:00 http://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-add-reference
REM dotnet add reference lib1/lib1.csproj lib2/lib2.csproj
dotnet add reference ..\ProCSharp10WithNET6Library
dotnet run

http://localhost:5078/swagger

http://localhost:5078/WeatherForecast

http://localhost:5078/HowITryToBeAsIHaveAssociated?word=how are you

REM 2023-04-15T08:12:00 http://stackoverflow.com/questions/75439874/build-wpf-application-with-net-from-the-command-line
REM 2023-04-15T08:28:00	github.com/github.com/punker76/kaxaml
cd ..
dotnet new wpf --name "ProCSharp10WithNET6WPF" -lang "C#"
cd ProCSharp10WithNET6WPF
dotnet add reference ..\ProCSharp10WithNET6Library
dotnet run

REM 2023-04-15T20:05:00 Console application
cd ..
dotnet new console --name "ProCSharp10WithNET6Console" -lang "C#"
cd ProCSharp10WithNET6Console
dotnet add reference ..\ProCSharp10WithNET6Library
dotnet run "how are you" "I am fine"

REM 2023-04-17T11:35:00 Create WebAppMVC
REM http://learn.microsoft.com/en-us/aspnet/core/getting-started/?view=aspnetcore-5.0&tabs=windows
dotnet new webapp -o ProCSharp10WithNET6WebAppMVC
dotnet dev-certs https --trust

cd ProCSharp10WithNET6WebAppMVC
dotnet watch run

http://localhost:5014/

Open Pages/Index.cshtml


