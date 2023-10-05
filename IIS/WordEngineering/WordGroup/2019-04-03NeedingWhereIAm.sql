			SELECT  
				ActToGod.Minor, 
				ScriptureReferenceSubset.value
			FROM
				Bible..Scripture,
				WordEngineering..ActToGod
			CROSS APPLY	
				STRING_SPLIT(WordEngineering..ActToGod.ScriptureReference, ',') AS ScriptureReferenceSubset
			WHERE
				Major LIKE '%Comparative verse%'
			ORDER BY
				Minor, 
				ActToGod.ScriptureReference
go


