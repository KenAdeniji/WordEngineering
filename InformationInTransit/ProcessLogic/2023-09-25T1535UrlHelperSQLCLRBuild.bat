@ECHO OFF
REM 2023-0925T16:31:00 http://learn.microsoft.com/en-us/sql/relational-databases/user-defined-functions/create-clr-functions?view=sql-server-ver16
csc /define:DEBUG /debug:full /out:\WordOfGod\UrlHelper.exe /target:exe UrlHelper.cs
csc /define:DEBUG /debug:full /out:\WordOfGod\bin\UrlHelper.dll /target:library UrlHelper.cs

GOTO SkipInternetCountryCodeTopLevelDomain_ccTLD

DROP FUNCTION InternetCountryCodeTopLevelDomain_ccTLD;
DROP ASSEMBLY UrlHelper;
CREATE ASSEMBLY UrlHelper FROM 'E:\WordOfGod\bin\UrlHelper.dll' WITH PERMISSION_SET = SAFE;
GO
CREATE FUNCTION [dbo].[InternetCountryCodeTopLevelDomain_ccTLD](@url NVARCHAR(MAX))
RETURNS NVARCHAR(MAX)
AS EXTERNAL NAME UrlHelper.[UrlHelper].InternetCountryCodeTopLevelDomain_ccTLD
GO
SELECT dbo.[InternetCountryCodeTopLevelDomain_ccTLD]('Microsoft.com.au/Index.html')
SELECT dbo.[InternetCountryCodeTopLevelDomain_ccTLD]('Microsoft.com/Index.html')

:SkipInternetCountryCodeTopLevelDomain_ccTLD
