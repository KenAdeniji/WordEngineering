USE [remindme]
GO
/****** Object:  StoredProcedure [dbo].[usp_CommunicationTypeSave]    Script Date: 3/21/2020 2:55:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO



ALTER  procedure [dbo].[usp_CommunicationTypeSave]
(
      @strMemberID varchar(255)
     ,@iCommunicationTypeID int
     ,@strCommunicationType varchar(255)
     ,@isPrivate            int
     ,@isPhone              int
     ,@isWebSite            tinyint=0
)
as

	begin tran

		--if inserting, then get next communication type id
		if ( 
			   (@iCommunicationTypeID is null)
			or (@iCommunicationTypeID = -1)
		   )
		begin

			select @iCommunicationTypeID = isNull(max(id), 0) + 1
			from   dbo.support_communication
			where  memberIdentifier = @strMemberID

			insert into dbo.support_communication
			(
			    memberIdentifier
			   ,[id]
			   ,comm_type
		           ,isPrivate
			   ,isPhoneNumber
               , [isWebSite]
			)
			values
			(
  			     @strMemberID
			   , @iCommunicationTypeID	
                           , @strCommunicationType
                           , @isPrivate
                           , @isPhone
              , @isWebSite 
			)		
			

		end
		else
		begin

			update dbo.support_communication
			set      comm_type = @strCommunicationType
				, isPrivate = @isPrivate
				, isPhoneNumber = @isPhone
                , [isWebSite] = @isWebSite
			where  memberIdentifier = @strMemberID
			and    id = @iCommunicationTypeID

		end
		
			
		if (@@rowcount = 1)
		begin
			commit tran
		end
		else
		begin
			rollback tran
		end
