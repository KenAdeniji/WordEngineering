-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ken Adeniji
-- Create date: 2025-03-02T23:00:00
-- Description:	SELECT COUNT(ContactID) FROM WordEngineering..HisWord
-- =============================================
CREATE OR ALTER PROCEDURE usp_DoNotGoIntoEgypt
	-- Add the parameters for the stored procedure here
	@TopLimit INT = 10
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT	TOP (@TopLimit) 
		COALESCE(ISNULL(ContactID, 0), 'Total') ContactID,
		COUNT(ContactID) ContactIDCount
	FROM	WordEngineering..HisWord
	GROUP BY ROLLUP(ContactID)
	--GROUP BY GROUPING SETS (ContactID)
	ORDER BY COUNT(ContactID) DESC
END
GO
