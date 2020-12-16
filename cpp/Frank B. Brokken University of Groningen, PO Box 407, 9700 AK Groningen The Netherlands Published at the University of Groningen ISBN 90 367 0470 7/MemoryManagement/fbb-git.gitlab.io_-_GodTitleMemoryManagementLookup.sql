--GodTitles[0].setGodTitle("El", "The Strong One.", "");
--Title, Commentary, OrderSequence, Dated, ScriptureReference, GodTitleID, TypeMaster
SELECT
	'GodTitles[' 
	+CONVERT(VARCHAR, GodTitleID)
	+'].setGodTitle("' + Title + ',"' + ISNULL(Commentary, '') + '","' + ISNULL(ScriptureReference, '') + '");'
FROM
	WordEngineering..GodTitle
ORDER BY
	GodTitleID
	 