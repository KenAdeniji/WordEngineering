@ECHO OFF
csc /target:exe /reference:System.ServiceModel.dll CalculatorServer.cs 
REM svcutil.exe /language:cs /out:CalculatorGeneratedProxy.cs /config:CalculatorCaller.exe.config http://localhost:8000/InformationInTransit.AirDrop.Calculator
csc /target:exe /reference:System.ServiceModel.dll CalculatorCaller.cs CalculatorGeneratedProxy.cs