@ECHO OFF
csc /out:CalculatorWindowsServiceServer.exe /target:exe /reference:System.ServiceModel.dll,System.ServiceProcess.dll,System.Configuration.Install.dll CalculatorWindowsServiceServer.cs 
InstallUtil CalculatorWindowsServiceServer.exe
services.msc
net start WCFWindowsServiceSample
net stop WCFWindowsServiceSample
InstallUtil /u CalculatorWindowsServiceServer.exe
