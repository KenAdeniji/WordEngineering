/****** Object:  StoredProcedure [dbo].[usp_ContactMaintenanceQuery]    Script Date: 6/18/2025 6:43:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER PROCEDURE [dbo].[usp_ContactMaintenanceQuery]
	@query  AS NVARCHAR(4000)	=	NULL
    , @debug bit = 0
AS
BEGIN
/*
	2015-01-04	blogs.msdn.com/b/raulga/archive/2007/01/04/dynamic-sql-sql-injection.aspx
    2015-08-12  File created.
	2017-08-28	docs.microsoft.com/en-us/sql/t-sql/functions/isdate-transact-sql
	2017-08-29	blogs.sentryone.com/aaronbertrand/bad-habits-revival/#index
	2025-07-26T12:01:00	
				+   ' (WordEngineering.dbo.udf_SearchKey(Contact.ContactID) like case '
				+   ' when @query is null then WordEngineering.dbo.udf_SearchKey(Contact.ContactID) '
				+   ' else @query  '
				+	' end  ' 
				+	' ) '
				+   @CRLF
*/

/*

	select WordEngineering.dbo.udf_SearchKey(WordEngineering.dbo.Contact.ContactID)

*/

/*

	select
			contactid
			, WordEngineering.dbo.udf_SearchKey(WordEngineering.dbo.Contact.ContactID)

	FROM Contact
	
	--WordEngineering.dbo.udf_SearchKey(WordEngineering.dbo.Contact.ContactID)

*/

/*

	select
		
			 WordEngineering.dbo.udf_SearchKey(1000)

	

*/

/*

    EXEC usp_ContactMaintenanceQuery 
              @query = '1000'
            , @debug = 1


*/



/*

    EXEC usp_ContactMaintenanceQuery 
              @query = 'Faith An'
            , @debug = 1

*/

/*

    EXEC usp_ContactMaintenanceQuery 
              @query = 'Chuck Missler'
            , @debug = 1


*/

    SET NOCOUNT ON

	DECLARE @sqlSelectStatement NVARCHAR(4000)
	DECLARE @CRLF nvarchar(10) = char(13) + char(10)

    DECLARE @isNumeric BIT = ISNUMERIC(@query)
    DECLARE @queryNumber INT = NULL

	declare @queryBase nvarchar(4000)

    IF (@isNumeric = 1)
    BEGIN
        SET @queryNumber = CONVERT( INT, @query )
    END

	DECLARE @isDateTime BIT = ISDATE(@query)
	DECLARE @queryDateTime DateTime = NULL
    IF (@isDateTime = 1)
    BEGIN
        SET @queryDateTime = CONVERT( DateTime, @query )
    END

	set @queryBase = @query

	if @query is not null
	begin
	
		set @query = '%' + @query + '%'

	end
	
    SET @sqlSelectStatement =	'SELECT '
								+ @CRLF + 
								-- + ' DISTINCT '
								+ @CRLF + 
								+ ' Contact.ContactID, Contact.Dated, Contact.Title, Contact.FirstName, Contact.LastName, Contact.OtherName, Contact.Company, Contact.Commentary ' +
								 @CRLF + 
								' FROM Contact ' +
								@CRLF + 
								' LEFT OUTER JOIN ContactEmail ON Contact.ContactId = ContactEmail.ContactID ' + 
								@CRLF + 
								' LEFT OUTER JOIN ContactURI ON Contact.ContactID = ContactURI.ContactID ' + 
								@CRLF + 
								' LEFT OUTER JOIN StreetAddress ON Contact.ContactID = StreetAddress.ContactId ' + 
								@CRLF + 
								' LEFT OUTER JOIN Telephone ON Contact.ContactID = Telephone.ContactId ' +
								@CRLF + 
							    +   @CRLF
								+ ' WHERE 1 = 0 '

	+   @CRLF

	+   ' or '
	+   ' ( '
	+   ' isNumeric (' + '''' + @queryBase + '''' + ') = 0 ' 
	+   ' and '
	+   ' ( '
	+   ' WordEngineering.dbo.udf_SearchKey(WordEngineering.dbo.Contact.ContactID) = ' 
	+   ' ''' + @queryBase + ''' '
	+   ' ) '
	+ ' ) '



	+   @CRLF
	+   ' or '
	+   ' (Contact.FirstName like case '
	+   ' when @query is null then Contact.FirstName '
	+   ' else @query  '
	+	' end  ' 
	+	' ) '
	+   @CRLF

    +   ' OR (Contact.LastName like case '
	+   ' when @query is null then Contact.LastName '
	+   ' else @query  '
	+	' end  ' 
	+	' ) '
	+   @CRLF

    +   ' OR (Contact.OtherName like case '
	+   ' when @query is null then Contact.OtherName '
	+   ' else @query  '
	+	' end  ' 
	+	' ) '
	+   @CRLF

    +   ' OR (Contact.OtherName like case '
	+   ' when @query is null then Contact.OtherName '
	+   ' else @query  '
	+	' end  ' 
	+	' ) '
	+   @CRLF

    +   ' OR (Contact.Title like case '
	+   ' when @query is null then Contact.Title '
	+   ' else @query  '
	+	' end  ' 
	+	' ) '
	+   @CRLF

    +   ' OR (Contact.Company like case '
	+   ' when @query is null then Contact.Company '
	+   ' else @query  '
	+	' end  ' 
	+	' ) '
	+   @CRLF

    +   ' OR (Contact.Commentary like case '
	+   ' when @query is null then Commentary '
	+   ' else @query  '
	+	' end  ' 
	+	' ) '
	+   @CRLF

    +   ' OR (Telephone.TelephoneNo like case '
	+   ' when @query is null then Telephone.TelephoneNo '
	+   ' else @query  '
	+	' end  ' 
	+	' ) '
	+   @CRLF

    +   ' OR (ContactEmail.emailAddress like case '
	+   ' when @query is null then ContactEmail.emailAddress '
	+   ' else @query  '
	+	' end  ' 
	+	' ) '
	+   @CRLF

    +   ' OR (ContactURI.internetAddress like case '
	+   ' when @query is null then ContactURI.internetAddress '
	+   ' else @query  '
	+	' end  ' 
	+	' ) '
	+   @CRLF

    +   ' OR (StreetAddress.addressLine1 like case '
	+   ' when @query is null then StreetAddress.addressLine1 '
	+   ' else @query  '
	+	' end  ' 
	+	' ) '
	+   @CRLF

    +   ' OR (StreetAddress.city like case '
	+   ' when @query is null then StreetAddress.city '
	+   ' else @query  '
	+	' end  ' 
	+	' ) '
	+   @CRLF

    +   ' OR (StreetAddress.state like case '
	+   ' when @query is null then StreetAddress.state '
	+   ' else @query  '
	+	' end  ' 
	+	' ) '
	+   @CRLF

    +   ' OR (StreetAddress.zipcode like case '
	+   ' when @query is null then StreetAddress.zipcode '
	+   ' else @query  '
	+	' end  ' 
	+	' ) '
	+   @CRLF

    +   ' OR (StreetAddress.country like case '
	+   ' when @query is null then StreetAddress.country '
	+   ' else @query  '
	+	' end  ' 
	+	' ) '
	+   @CRLF


    IF (@isNumeric = 1)
    BEGIN
    SET @sqlSelectStatement += 
       ' OR (Contact.ContactID = ' + CONVERT(VARCHAR, @queryNumber) + ') '
	+   @CRLF
    END

    IF (@queryDateTime IS NOT NULL)
    BEGIN
    SET @sqlSelectStatement += 
       ' OR (CONVERT(DATE, Contact.Dated) = ' + '''' + CONVERT(VARCHAR, @queryDateTime) + ''') '
	+   @CRLF
    END

	SET @sqlSelectStatement += ' GROUP BY Contact.ContactID, Contact.Dated, Contact.Title, Contact.FirstName, Contact.LastName, Contact.OtherName, Contact.Company, Contact.Commentary '

	SET @sqlSelectStatement += ' ORDER BY Contact.ContactID, Contact.Dated, Contact.Title, Contact.FirstName, Contact.LastName, Contact.OtherName, Contact.Company, Contact.Commentary '

    DECLARE @parmDefinition nvarchar(4000)
    SET @parmDefinition = '@query nvarchar(4000)'

    IF ( @debug = 1)
    BEGIN
        PRINT @sqlSelectStatement
    END

	EXEC sp_executesql 
			  @sqlSelectStatement
			, @parmDefinition
			, @query = @query

END
GO

--[dbo].[usp_ContactMaintenanceQuery] 'Faith An'