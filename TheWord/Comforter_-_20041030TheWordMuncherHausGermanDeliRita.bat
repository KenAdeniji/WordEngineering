@ECHO OFF
TheWord  Comforter_-_20041030MuncherHausGermanDeliRita.xml  Comforter_-_20041030TheWordMuncherHausGermanDeliRita.xml
SQLCMD –E –d WordEngineering –i ..\SQLServerScript\Comforter_-_20040928SacredText.sql
SQLCMD –E –d WordEngineering –i ..\SQLServerScript\Comforter_-_20041030DDLWordEngineeringScriptureReadingContactId.sql