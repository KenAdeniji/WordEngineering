SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

use remindme
go

ALTER  procedure usp_GetContactsForMember
                      (   @strMemberIdentifier uniqueidentifier
                         ,@strNameFilter varchar(20) = ''
                       )
as

    declare @iNameFilterLength tinyint
    declare @strNameFilterFull varchar(30)

    set @iNameFilterLength = len(@strNameFilter)

    if (@iNameFilterLength = 0)
    begin

    	select ContactIdentifier, Contact, affliate, profession 
	    from   dbo.v_contacts 
    	where memberIdentifier = @strMemberIdentifier
        order by contact

    end
    else
    begin

		if(@iNameFilterLength = 1)
		begin

	        set @strNameFilterFull = @strNameFilter + '%'

		end
		else
		begin

	        set @strNameFilterFull = '%' + @strNameFilter + '%'

		end

    	select distinct 
				  tblContact.ContactIdentifier
				, tblContact.Contact
				, tblContact.affliate
				, tblContact.profession 
	    from   dbo.v_contact_find tblContact

    	where tblContact.memberIdentifier = @strMemberIdentifier

        and   (
				   (tblContact.contact like @strNameFilterFull)
				or (tblContact.communicationData like @strNameFilterFull)
			  )

        order by contact

    end


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



--exec dbo.usp_GetContactsForMember '51517064-0267-11D4-B8A6-006008408162', 'hotmail.com'
--exec dbo.usp_GetContactsForMember '51517064-0267-11D4-B8A6-006008408162', 'yahoo.com'
--exec dbo.usp_GetContactsForMember '51517064-0267-11D4-B8A6-006008408162', '510-461'
