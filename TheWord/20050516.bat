@Echo Off
Call SQLCMD –E –d WordEngineering –i ..\Documentation\Comforter.org\Comforter_-_20050424AttachDatabase.sql
Call Rhema /bennyHinn:../URI/20050418URIWordEngineering.xml
Call Eternal /sqlQuery:"Select ContactDated, ContactSequenceOrderId, ContactTitle, ContactFirstName, ContactLastName, ContactOtherName, ContactCompany, ContactEmailEmailAddress, ContactURIInternetAddress, StreetAddressAddressLine1, StreetAddressCity, StreetAddressState, StreetAddressZipCode, StreetAddressCountry, TheWordDated, TheWordSequenceOrderId, TheWordTitle, TelephoneTelephoneNo, TelephoneTelephoneLocation FROM WordEngineering..ViewContact (NOLOCK)" /filenameXml:Comforter_-_20031008ViewContact.xml /filenameStylesheet:Comforter_-_20031008ViewContact.xslt
Call Rhema /bennyHinn:../URI/20050520URIChrist.xml
Call SQLCMD –E –d WordEngineering –i ..\Documentation\Comforter.org\20050520AlterTableURIAlterColumnTitleNull.sql
Call SQLCMD –E –d WordEngineering –i ..\Documentation\Comforter.org\20050522AddLoginWordEngineering.sql
Call Rhema /bennyHinn:../URI/20050727URIChrist.xml