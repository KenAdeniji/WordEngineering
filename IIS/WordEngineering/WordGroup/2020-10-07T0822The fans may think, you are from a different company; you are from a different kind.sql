SELECT
	Minor
	,dbo.udf_splitSelectRandom(ScriptureReference) AS ScriptureReference
FROM
	WordEngineering..ActToGod
WHERE
	Major = 'Prayer'
AND	ScriptureReference IS NOT NULL
ORDER BY
	Minor


