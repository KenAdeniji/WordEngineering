@ECHO OFF
REM 2026-11-03 linux-magazine.com/Resources/Special-Editions/57-Best-of-Bash-2026-Edition
REM 2026-11-03 http://stackoverflow.com/questions/1355876/export-table-to-file-with-column-headers-column-names-using-the-bcp-utility-an
sqlcmd -s, -W -Q "set nocount on; select HisWordID, Dated, Word, Dream, Commentary, Location, Scene, Uri, ContactID, ScriptureReference from WordEngineering.dbo.HisWord order by HisWordID asc" | findstr /v /c:"-" /b > "2026-11-03Chapter14Verse9_Chapter14Verse7.csv"