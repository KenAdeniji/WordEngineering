SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

use remindme
go

DROP  procedure sp_ContactUpdate 
go

CREATE  procedure sp_ContactUpdate 
(
      @strContactID varchar(255)
     ,@strContact varchar(255)
     ,@iAffliate int
     ,@iProfession int
     ,@DOB varchar(255)
     ,@strComment varchar(255)

)
as

begin tran

		if (@strComment is not null)
		begin
			set @strComment = ltrim(rtrim(@strComment))
		end

		if (
				   (@DOB = '')
				or (@DOB = '1/1/1900')
			)
		begin
			set @DOB = null
		end

		if (@iAffliate = -1)
		begin
			set @iAffliate = null
		end

		if (@iProfession = -1)
		begin
			set @iProfession = null
		end

		update dbo.contacts
		set 
                  contact = @strContact,    
	              affliation_code = @iAffliate,
	              profession_code = @iProfession,
		          DOB = @DOB,	
	              comment = @strComment,
                  dateUpdated = getDate()
         where contactIdentifier = @strContactID 


              
		if (@@rowcount = 1)
		begin
			commit tran
		end
		else
		begin
			rollback tran
		end


GO

grant execute on sp_ContactUpdate to [ephraimtech\webUser]
go

grant execute on sp_ContactUpdate to [webUser]
go


/*


	update dbo.contacts set affliation_code = null  where  affliation_code = -1
	update dbo.contacts set DOB = null  where  DOB = '1/1/1900'

*/