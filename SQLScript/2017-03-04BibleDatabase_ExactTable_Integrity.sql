SELECT MAX(SequenceOrderID) FROM Bible..Exact
GO

SELECT COUNT(*) FROM Bible..Exact
GO

ALTER TABLE Bible..Exact ADD CONSTRAINT  CK_Exact_SequenceOrderID_Range CHECK (SequenceOrderID BETWEEN 1 AND 12891)
GO

CREATE UNIQUE INDEX AK_Exact_SequenceOrderID ON Bible..Exact(SequenceOrderID)
GO

ALTER TABLE [dbo].[Exact] ADD  CONSTRAINT [PK_Exact] PRIMARY KEY CLUSTERED 
(
	[BibleWord] ASC
)
GO

ALTER TABLE [dbo].[Exact]  WITH CHECK ADD  CONSTRAINT [FK_Exact_KJV] FOREIGN KEY(FirstOccurrence)
REFERENCES [dbo].[KJV] (ScriptureReference)
GO

ALTER TABLE [dbo].[HisWord] CHECK CONSTRAINT [FK_HisWord_Contact]
GO

SELECT DATEDIFF(day, '20 July 356 BC', '2017-03-05')
GO
