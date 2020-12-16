WITH cte_Genealogy(WeSaidOmoSchoolYinNaTryOhunNaMakeEffortID, FullName, ScriptureReference, FatherID, MotherID, ProductLevel, ProductAssemblyID, Sort)
AS  
(
	SELECT	G.AsWeSaidOmoSchoolYinNaTryOhunNaMakeEffortID,
            G.FullName,
			G.ScriptureReference,
			G.FatherID,
			G.MotherID,
			1,
			NULL,
			CAST (G.FullName AS VARCHAR (100)) 
     FROM   AsWeSaidOmoSchoolYinNaTryOhunNaMakeEffort AS G
     UNION ALL
     SELECT G.AsWeSaidOmoSchoolYinNaTryOhunNaMakeEffortID,
            G.FullName,
			G.ScriptureReference,
			G.FatherID,
			G.MotherID,
            cte_Genealogy.ProductLevel + 1,
            cte_Genealogy.AsWeSaidOmoSchoolYinNaTryOhunNaMakeEffortID,
            CAST (cte_Genealogy.Sort + '\' + G.FullName AS VARCHAR (100))
	FROM	cte_Genealogy
	INNER JOIN	AsWeSaidOmoSchoolYinNaTryOhunNaMakeEffort AS G 
			ON	cte_Genealogy.AsWeSaidOmoSchoolYinNaTryOhunNaMakeEffortID = G.AsWeSaidOmoSchoolYinNaTryOhunNaMakeEffortID 
)
SELECT  AsWeSaidOmoSchoolYinNaTryOhunNaMakeEffortID, 
		FullName, ScriptureReference, FatherID, MotherID, 
        ProductLevel,
        ProductAssemblyID,
        Sort
FROM    cte_Genealogy
ORDER BY Sort;
