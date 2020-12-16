ALTER TABLE KJV
ADD CONSTRAINT  CK_KJV_BookID_Range
  CHECK (BookID BETWEEN 1 AND 66);
GO

SELECT MAX(ChapterID) FROM Bible..KJV
GO

ALTER TABLE Bible..KJV ADD CONSTRAINT  CK_KJV_ChapterID_Range CHECK (ChapterID BETWEEN 1 AND 150)
GO

SELECT MAX(VerseID) FROM Bible..KJV
GO

ALTER TABLE KJV
ADD CONSTRAINT  CK_KJV_ChapterID_Range
  CHECK (ChapterID BETWEEN 1 AND 150);
GO

SELECT BookID, ChapterID FROM Bible..KJV GROUP BY BookID, ChapterID ORDER BY BookID, ChapterID
GO

ALTER TABLE Bible..KJV
ADD CONSTRAINT  CK_KJV_ChapterIDSequence_Range
  CHECK (ChapterIDSequence BETWEEN 1 AND 1189);
GO

SELECT COUNT(*) FROM Bible..KJV
GO

ALTER TABLE Bible..KJV ADD CONSTRAINT  CK_KJV_VerseIDSequence_Range CHECK (VerseIDSequence BETWEEN 1 AND 31102)
GO

ALTER TABLE Bible..KJV
ADD CONSTRAINT AK_KJV_VerseIDSequence UNIQUE (VerseIDSequence)   
GO 

SELECT BookTitle FROM Bible..KJV GROUP BY BookID, BookTitle HAVING MAX(ChapterID) = 1 ORDER BY BookID
GO

SELECT  ScriptureReference, BibleReference    
FROM	Bible..KJV
WHERE	BookID = 43 AND ChapterID = 1 AND VerseID = 1
GO

SELECT	BookID
FROM	Bible..KJV
GROUP BY BookID, ChapterID
GO

/*

	select distinct cast(BookID as decimal(10, 0)) + ( ChapterID * .1)
	FROM	Bible..KJV
	--order by VerseID desc

*/

set nocount on;

select count(
				distinct
					  cast(BookID as varchar(6))
					+ ' '
					+ cast(ChapterID as varchar(6))
			)
FROM	Bible..KJV

print replicate('*', 120)

; with cte
(
	  BookID
	, chapterID
)
as
(
	select distinct BookID, chapterID
	FROM	Bible..KJV
)
select cnt = count(*)
from   cte

print replicate('*', 120)
go

ALTER TABLE KJV ADD CONSTRAINT uc_KJV_ScriptureReference UNIQUE (ScriptureReference)
GO


