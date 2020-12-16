@ECHO OFF
csc /out:TemperatureServer.exe /target:exe /reference:System.ServiceModel.dll TemperatureServer.cs 
REM svcutil.exe /language:cs /out:TemperatureGeneratedProxy.cs /config:TemperatureCaller.exe.config http://localhost:8000/InformationInTransit.AirDrop.Temperature
csc /out:TemperatureCaller.exe /target:exe /reference:System.ServiceModel.dll TemperatureCaller.cs TemperatureGeneratedProxy.cs