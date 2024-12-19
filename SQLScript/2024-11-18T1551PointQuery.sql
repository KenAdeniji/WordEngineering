SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
use [Bible]
go


CREATE or ALTER FUNCTION dbo.Pointquery 
(	
	@verseIDSequence	AS	INT
)
RETURNS TABLE 
AS
RETURN 
(

	-- =============================================
	-- Author:		Ken Adeniji
	-- Create date: 2024-11-18T15:51:00
	-- Description:	A point query returns at most 1 record. The query includes an equality condition.
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
	WHERE VerseIDSequence = @verseIDSequence
)
GO

grant select on dbo.Pointquery to public
go

/*

	declare @verseIDSequence int

	set @verseIDSequence = 1

	select *
	from   dbo.Pointquery( @verseIDSequence)

*/