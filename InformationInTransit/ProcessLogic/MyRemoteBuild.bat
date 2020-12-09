csc /t:library /debug MyRemoteClass.cs
csc /debug /r:MyRemoteClass.dll /r:System.Runtime.Remoting.dll MyRemoteServer.cs
csc /debug /r:MyRemoteClass.dll /r:System.Runtime.Remoting.dll MyRemoteClient.cs
