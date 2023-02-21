USE [remindme]
GO

/****** Object:  StoredProcedure [dbo].[usp_CommunicationTypeGet]    Script Date: 3/21/2020 2:50:09 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER OFF
GO



--DROP   procedure dbo.usp_GetCommunicationTypeRecord

ALTER   procedure [dbo].[usp_CommunicationTypeGet]
(   @strMemberIdentifier uniqueidentifier
    ,@iCommunicationTypeID int 
)
as

    begin
	
    	select *
        from   dbo.support_communication
    	where  memberIdentifier = @strMemberIdentifier
        and    id = @iCommunicationTypeID


    end

GO


