SELECT
	MIN(HisWord.Dated) HisWordDated,
	HisWord.HisWordID HisWordID,
	COUNT(DISTINCT Software.SoftwareID) SoftwareCount,
	COUNT(DISTINCT APass.APassID) APassCount,
	COUNT(DISTINCT Remember.RememberID) RememberCount,
	COUNT(DISTINCT ActToGod.ActToGodID) ActToGodCount
FROM WordEngineering..HisWord HisWord
FULL OUTER JOIN	WordEngineering..Software ON HisWord.HisWordID = Software.HisWordID
FULL OUTER JOIN WordEngineering..APass ON HisWord.HisWordID = APass.HisWordID
FULL OUTER JOIN WordEngineering..Remember ON HisWord.HisWordID = Remember.HisWordID
FULL OUTER JOIN WordEngineering..ActToGod ON HisWord.HisWordID = ActToGod.HisWordID
WHERE		HisWord.HisWordID IS NOT NULL
GROUP BY	HisWord.HisWordID
HAVING
			COUNT(DISTINCT Software.SoftwareID) > 0
OR			COUNT(DISTINCT APass.APassID) > 0
OR			COUNT(DISTINCT Remember.RememberID) > 0
OR			COUNT(DISTINCT ActToGod.ActToGodID) > 0
ORDER BY
	SoftwareCount DESC,
	APassCount DESC,
	RememberCount DESC,
	ActToGodCount DESC
