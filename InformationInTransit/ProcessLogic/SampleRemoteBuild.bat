csc /t:library /debug SampleRemoteClass.cs
csc /debug /r:SampleRemoteClass.dll /r:System.Runtime.Remoting.dll SampleRemoteServer.cs
csc /debug /r:SampleRemoteClass.dll /r:System.Runtime.Remoting.dll SampleRemoteClient.cs
