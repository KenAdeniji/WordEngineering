SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
use [Bible]
go


CREATE or ALTER FUNCTION dbo.Multipointquery 
(	
	@chapterIDSequence	AS	INT
)
RETURNS TABLE 
AS
RETURN 
(

	-- =============================================
	-- Author:		Ken Adeniji
	-- Create date: 2024-11-18T16:26:00
	-- Description:	It may return more than 1 record, as there may be multiple records. It is restricted by an equality condition on part of a potential composite key.
	-- =============================================

	/*

	-- ================================================
	-- Template generated from Template Explorer using:
	-- Create Inline Function (New Menu).SQL
	--
	-- Use the Specify Values for Template Parameters 
	-- command (Ctrl-Shift-M) to fill in the parameter 
	-- values below.
	--
	-- This block of comments will not be included in
	-- the definition of the function.
	-- ================================================

	*/
	-- Add the SELECT statement with parameter references here
	SELECT *
	FROM Bible..Scripture_View
	WHERE chapterIDSequence = @chapterIDSequence
)
GO

/*
	declare @chapterIDSequence int

	set @chapterIDSequence = 1

	select *
	from   dbo.Multipointquery( @chapterIDSequence)

*/