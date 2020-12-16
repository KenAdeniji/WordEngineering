@ECHO OFF
Xcopy ..\URI ..\WordOfGod /C /D /E /I /R /S /Y
Xcopy ..\URI\Comforter_-_URIWordEngineering.xml ..\WordOfGod\Comforter_-_URIWordEngineeringRelease20031114.xml /C /D /E /I /R /S /Y
CD ..\WordOfGod
TheWord ..\TheWord\Comforter_-_20031113DisagreeWithYourself.xml  ..\TheWord\Comforter_-_20031113DisagreeWithYourself.txt
TheWord ..\TheWord\Comforter_-_20031114YouGotToCutItLoose_EBaMiRetiIyawoMi_You'veDoneThisForMeIHaveDoneThisForYouToo.xml   ..\TheWord\Comforter_-_20031114YouGotToCutItLoose_EBaMiRetiIyawoMi_You'veDoneThisForMeIHaveDoneThisForYouToo.txt
TheWord ..\TheWord\Comforter_-_20031115JuniorSayOh.xml ..\TheWord\Comforter_-_20031115JuniorSayOh.txt
TheWord ..\TheWord\Comforter_-_20031115GoTheonissan.xml  ..\TheWord\Comforter_-_20031115GoTheonissan.txt
TheWord ..\TheWord\Comforter_-_20031115ItAllLookedLikeThisIsTheEventHeHopedHeWillBeThinkingHeWillBe.xml   Comforter_-_20031115ItAllLookedLikeThisIsTheEventHeHopedHeWillBeThinkingHeWillBe.txt
CD ..
