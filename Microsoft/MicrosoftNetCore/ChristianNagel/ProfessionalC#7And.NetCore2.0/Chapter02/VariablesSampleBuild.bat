@ECHO OFF
REM 2023-06-22T20:30:00 wiley.com/en-us/Professional+C%23+7+and+NET+Core+2+0-p-9781119449263
REM Professional C# 7 and .NET Core 2.0 Christian Nagel ISBN: 978-1-119-44926-3 March 2018 1440 Pages
dotnet new console --output VariablesSample
CD VariablesSample
dotnet build
dotnet run
