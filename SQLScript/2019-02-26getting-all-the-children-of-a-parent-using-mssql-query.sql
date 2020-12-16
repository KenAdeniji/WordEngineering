--https://stackoverflow.com/questions/19041814/getting-all-the-children-of-a-parent-using-mssql-query
/*
SELECT p.FullName
FROM AsWeSaidOmoSchoolYinNaTryOhunNaMakeEffort c
INNER JOIN AsWeSaidOmoSchoolYinNaTryOhunNaMakeEffort p ON c.FatherID = p.FatherID
WHERE c.FullName LIKE '%Enos%'
*/
/*
SELECT p.Child
FROM Table1 c
INNER JOIN Table1 p ON c.Parent = p.Parent
WHERE c.Child = @p0
*/

SELECT p.AsWeSaidOmoSchoolYinNaTryOhunNaMakeEffortID, p.FullName, p.ScriptureReference, p.FatherID, p.MotherID,
		(SELECT project.FullName FROM WordEngineering..AsWeSaidOmoSchoolYinNaTryOhunNaMakeEffort AS project WHERE p.FatherID = project.AsWeSaidOmoSchoolYinNaTryOhunNaMakeEffortID ) AS FullNameFather,
		(SELECT project.FullName FROM WordEngineering..AsWeSaidOmoSchoolYinNaTryOhunNaMakeEffort AS project WHERE p.MotherID = project.AsWeSaidOmoSchoolYinNaTryOhunNaMakeEffortID ) AS FullNameMother
		FROM WordEngineering..AsWeSaidOmoSchoolYinNaTryOhunNaMakeEffort AS c
		INNER JOIN AsWeSaidOmoSchoolYinNaTryOhunNaMakeEffort p ON c.FatherID = p.FatherID
		WHERE c.FullName LIKE '%enoch%'
