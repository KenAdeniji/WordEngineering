SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


ALTER   procedure usp_ContactCommunicationDelete
(
	  @strMemberID uniqueIdentifier
	, @strContactCommunicationID uniqueIdentifier
)
as


	begin tran

		delete 
		from   contact_communication
		where  sequenceIdentifier =  @strContactCommunicationID

		if (@@rowcount = 1)
		begin
			commit tran
		end
		else
		begin
			rollback tran
		end



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

