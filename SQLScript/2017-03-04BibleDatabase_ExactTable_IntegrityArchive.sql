SELECT MAX(SequenceOrderID) FROM Bible..Exact
GO

ALTER TABLE Bible..KJV ADD CONSTRAINT  CK_KJV_ChapterID_Range CHECK (ChapterID BETWEEN 1 AND 150)
GO

