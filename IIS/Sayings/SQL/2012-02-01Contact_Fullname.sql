USE [Sayings]
GO
ALTER FUNCTION [dbo].[Contact_Fullname]
(
 @ContactId Integer
)
RETURNS VARCHAR(max)
BEGIN

	DECLARE	@firstName VARCHAR(max)
	DECLARE @lastName VARCHAR(max)	
	DECLARE @middleName VARCHAR(max)
	DECLARE @fullname VARCHAR(max)
	DECLARE @organization VARCHAR(max)

	SET @fullname = NULL
	
	SELECT
		@firstName = LTRIM(RTRIM(FirstName)),
		@lastName = LTRIM(RTRIM(LastName)),
		@middleName = LTRIM(RTRIM(MiddleName)),
		@organization = LTRIM(RTRIM(Organization))
	FROM
		Contact ( NOLOCK )
	WHERE
		ContactId  =  @contactId

	IF @@ROWCOUNT > 0
	BEGIN
		SET @fullname = ''
		IF @firstName IS NOT NULL
		BEGIN
			SET @fullname = @firstName + ' '
		END
		IF @middleName IS NOT NULL
		BEGIN
			SET @fullname = @fullname + @middleName + ' '
		END
		IF @lastName IS NOT NULL
		BEGIN
			SET @fullname = @fullname + @lastName + ' '
		END
		IF @organization IS NOT NULL
		BEGIN
			SET @organization = @fullname + @organization + ' '
		END
	END		
	SET @fullname = LTRIM(RTRIM(@fullname))
	IF @fullname = ''
	BEGIN
		SET @fullname = NULL
	END
RETURN @fullname
END
GO
