SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

use remindme
go

DROP   procedure usp_ContactCommunicationActivateToggle
go

CREATE   procedure usp_ContactCommunicationActivateToggle
(
	  @strMemberID uniqueIdentifier
	, @strContactCommunicationID uniqueIdentifier
)
as


	begin tran

		update contact_communication
		set    active = ~ active 
		where  sequenceIdentifier =  @strContactCommunicationID
	
	commit tran

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

