@Echo Off
CALL Rhema /bennyHinn:../URI/20050717URIChrist.xml
CALL Rhema /bennyHinn:../URI/20050718URIWordEngineering.xml
CALL SQLCMD –E –d WordEngineering –i ..\Documentation\Comforter.org\20050718AlterTableURIWordEngineeringAlterColumnDatedDefaultGetDate.sql
CALL SQLCMD –E –d WordEngineering –i ..\Documentation\Comforter.org\20050724HouseKeepingURI.sql
CALL SQLCMD –E –d WordEngineering –i ..\Documentation\Comforter.org\20050727HouseKeepingURI.sql
CALL Rhema /bennyHinn:../URI/20050729URIWordEngineering.xml
CALL Rhema /bennyHinn:/WordOfGod/20050808RegularExpression.xml
CALL Rhema /bennyHinn:../URI/20050819URIWordEngineering.xml