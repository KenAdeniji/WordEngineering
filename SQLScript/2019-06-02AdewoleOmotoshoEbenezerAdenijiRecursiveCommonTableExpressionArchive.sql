ALTER PROCEDURE usp_AdewoleOmotoshoEbenezerAdenijiRecursiveCommonTableExpression AS
/*
	2019-06-02	EssentialSQL.com/recursive-ctes-explained
*/
WITH cte_FamilyTree (id, text, generation, parentID)
AS  
(
	SELECT	grandFather.AdewoleOmotoshoEbenezerAdenijiID,
            grandFather.FullName,
            1,
            NULL
     FROM   WordEngineering..AdewoleOmotoshoEbenezerAdeniji AS grandFather
	 WHERE	ParentID IS NULL
     UNION ALL
     SELECT grandFather.AdewoleOmotoshoEbenezerAdenijiID AS id,
            --CAST(REPLICATE('|---', cte_FamilyTree.generation) + grandFather.FullName AS VARCHAR (100)),
			grandFather.FullName,
            cte_FamilyTree.generation + 1,
            cte_FamilyTree.id
     FROM   cte_FamilyTree
     INNER JOIN WordEngineering..AdewoleOmotoshoEbenezerAdeniji AS grandFather
		ON	grandFather.ParentId = cte_FamilyTree.id
    )
SELECT   id, ISNULL(CONVERT(VARCHAR, ParentId), '#') AS parent, text
FROM     cte_FamilyTree
ORDER BY parent, id
