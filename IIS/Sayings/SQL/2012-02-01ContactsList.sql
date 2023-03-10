USE [Sayings]
GO

ALTER PROCEDURE [dbo].[ContactsList]
@loginName VARCHAR(max) = NULL,
@whereClause VARCHAR(max) = NULL
AS
SET NOCOUNT ON
DECLARE @empty NVARCHAR(4)
DECLARE @concatenateSeparator NVARCHAR(10)
DECLARE @contactIdJoin NVARCHAR(max)
DECLARE @joinSeparator NVARCHAR(2)
DECLARE @parameterDefinition NVARCHAR(500)
DECLARE @sqlStatementContactIdCollection NVARCHAR(max)

SET @contactIdJoin = NULL
SET @empty = ''''
SET @joinSeparator = ', '
SET @parameterDefinition =	N'@contactIdJoin nvarchar(max) OUTPUT, ' +
							N'@joinSeparator nvarchar(2)'

SET @sqlStatementContactIdCollection = 'SELECT @contactIdJoin = '
	+ 'COALESCE(@contactIdJoin + @joinSeparator, ' + @empty + @empty + ') + ' +
	' CONVERT(VARCHAR, ContactId) ' + 
	' FROM Contact INNER JOIN AspNetDB..aspnet_Membership ON Contact.UserId = aspnet_Membership.UserId ' +
	' WHERE aspnet_Membership.Email = ' + @empty + @loginName + @empty

IF @whereClause IS NOT NULL
BEGIN
	SET @sqlStatementContactIdCollection = @sqlStatementContactIdCollection + ' AND ( ' + @whereClause + ' ) '
END

--EXEC xp_logevent 60000, @sqlStatementContactIdCollection, informational

EXECUTE sp_executesql 
	@sqlStatementContactIdCollection,
	@parameterDefinition,
	@contactIdJoin OUTPUT,
	@joinSeparator

DECLARE @sqlStatementContact AS NVARCHAR(max)
SET @sqlStatementContact = 'SELECT *, dbo.Contact_Fullname(ContactId) AS FullName FROM Contact ' +
	'WHERE ContactId IN (' + @contactIdJoin + ')'
SET @sqlStatementContact = @sqlStatementContact + ' ORDER BY Fullname '

PRINT @sqlStatementContact

--EXEC xp_logevent 60000, @sqlStatementContact, informational

EXECUTE sp_executesql @sqlStatementContact
GO

/*
EXEC ContactsList @loginName = "kenadeniji@hotmail.com"
	,@whereClause = ' FirstName = ''Wole'' '
GO
*/

EXEC ContactsList @loginName = "kenadeniji@hotmail.com"
	, @whereClause = ' FirstName LIKE ''%Wole%'' '
GO
