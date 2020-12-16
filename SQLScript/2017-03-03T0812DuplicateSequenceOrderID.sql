SELECT  SequenceOrderId, MIN(Commentary)
FROM	Dream
GROUP BY SequenceOrderId
having count(*) > 1
ORDER BY SequenceOrderId DESC
GO

SELECT  SequenceOrderId, MIN(Commentary)
FROM	Dream
GROUP BY SequenceOrderId
having count(*) > 1
ORDER BY SequenceOrderId DESC
GO

ALTER TABLE [dbo].[Dream] ADD  CONSTRAINT [PK_Dream] PRIMARY KEY NONCLUSTERED 
(
	[SequenceOrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90)
GO