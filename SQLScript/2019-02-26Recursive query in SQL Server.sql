;WITH ret AS(
        SELECT  *
        FROM    AsWeSaidOmoSchoolYinNaTryOhunNaMakeEffort
        WHERE   FullName like '%Seth%'
        UNION ALL
        SELECT  t.*
        FROM    AsWeSaidOmoSchoolYinNaTryOhunNaMakeEffort
				t INNER JOIN
                ret r ON t.FatherID = r.AsWeSaidOmoSchoolYinNaTryOhunNaMakeEffortID
)

SELECT  *
FROM    ret
/*
;WITH ret AS(
        SELECT  *
        FROM    @Table
        WHERE   ID = @ID
        UNION ALL
        SELECT  t.*
        FROM    @Table t INNER JOIN
                ret r ON t.ParentID = r.ID
)

SELECT  *
FROM    ret
*/