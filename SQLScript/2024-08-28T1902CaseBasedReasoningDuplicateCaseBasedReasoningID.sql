SELECT	DISTINCT CaseBasedReasoningID
FROM	WordEngineering..CaseBasedReasoning
GROUP BY CaseBasedReasoningID
HAVING COUNT(*) > 1
ORDER BY CaseBasedReasoningID
	
/*
USE [WordEngineering]
GO

/****** Object:  Index [IDX_CaseBasedReasoning_Dated]    Script Date: 8/28/2024 7:10:05 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CaseBasedReasoning]') AND type in (N'U'))
ALTER TABLE [dbo].[CaseBasedReasoning] DROP CONSTRAINT IF EXISTS [IDX_CaseBasedReasoning_Dated]
GO
*/

/****** Object:  Index [IDX_CaseBasedReasoning]    Script Date: 8/28/2024 7:14:22 PM ******/
DROP INDEX IF EXISTS [IDX_CaseBasedReasoning] ON [dbo].[CaseBasedReasoning]
GO

