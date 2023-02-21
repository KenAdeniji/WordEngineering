SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


DROP  procedure dbo.usp_GetContactCommunicationInfo
go


CREATE   procedure dbo.usp_GetContactCommunicationInfo (
                @memberIdentifier varchar(255),
                @contactIdentifier varchar(255))
as

	select *
	from   dbo.v_contact_communication_formatted 
	where  memberIdentifier = @memberIdentifier
	and    contactIdentifier = @contactIdentifier
	order  by active desc, CommunicationType

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

grant execute on dbo.usp_GetContactCommunicationInfo to webUser
go
