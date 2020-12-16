REM 2020-04-19T10:00:00	jot.fm/issues/issue_2004_01/column8.pdf
REM csc /out:RemotingRichardWienerNameHolder.dll /target:library RemotingRichardWienerNameHolder.cs /reference:system.remoting.dll /nowarn:162,168,219,618,649 /unsafe
csc /out:RemotingRichardWienerNameHolder.dll /target:library RemotingRichardWienerNameHolder.cs /reference:System.Runtime.Remoting.dll /nowarn:162,168,219,618,649 /unsafe
csc /debug /reference:RemotingRichardWienerNameHolder.dll /reference:System.Runtime.Remoting.dll RemotingRichardWienerSingleHostSaveNamesServer.cs
csc /debug /reference:RemotingRichardWienerNameHolder.dll /reference:System.Runtime.Remoting.dll RemotingRichardWienerSingleHostClient.cs