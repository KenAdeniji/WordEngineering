SELECT * FROM WordEngineering..HisWord HisWordLead
WHERE Dated >
(
	SELECT TOP 1 Dated
	FROM WordEngineering..HisWord HisWordLag
	WHERE HisWordLead.HisWordID < HisWordLag.HisWordID
	ORDER BY HisWordLead.HisWordID 
)
ORDER BY HisWordID DESC

