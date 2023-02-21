use remindme
go


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

DROP  function dbo.hrefContact
go


CREATE  function dbo.hrefContact(   @contactIdentifier uniqueIdentifier
                                   ,@contact varchar(255)
						  	   ) returns varchar(255)
as
	begin

		declare @strLink varchar(255)

		set @strLink = '<a href=../ContactBrowse.aspx?ContactID=' 
             		   + rtrim(convert(varchar(100), @contactIdentifier)) + ' target=_parent>'
                       + rtrim(@contact) + '</a>'
		
		return @strLink

	end

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

