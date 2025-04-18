USE [remindme]
GO
/****** Object:  StoredProcedure [dbo].[usp_ContactCommunicationUpdate]    Script Date: 07/30/2016 11:03:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[usp_ContactCommunicationUpdate] 
(
      @strContactCommunicationID varchar(255)
     ,@iCommunicationType int
     ,@strCommunicate varchar(255)
     ,@strComment varchar(255)
	 ,@communicationLink varchar(255)     
     ,@iActive int

)
as

	--begin tran

		update contact_communication
		set   comm_type_id = @iCommunicationType, 
	              comm_data = @strCommunicate,
	              comment = @strComment,
	              communicationLink = @communicationLink,
	              active = @iActive,
                      dateUpdated = getDate()
                where sequenceIdentifier = @strContactCommunicationID 
              

/*
		if (@@rowcount = 1)
		begin
			commit tran
		end
		else
		begin
			rollback tran
		end

*/