USE [remindme]
GO
/****** Object:  StoredProcedure [dbo].[usp_GetContactsForMember]    Script Date: 8/14/2015 10:39:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

ALTER  procedure [dbo].[usp_GetContactsForMember]
                      (  
						  @strMemberIdentifier uniqueidentifier
                         ,@strNameFilter varchar(20) = ''
						 ,@FilterOnContactNameOnly bit = 0
                      )
as

    declare @iNameFilterLength tinyint
    declare @strNameFilterFull varchar(30)

    set @iNameFilterLength = len(@strNameFilter)

    if (@iNameFilterLength = 0)
    begin

    	select 
    			    ContactIdentifier
    			  , Contact
    			  , affliate
    			  , profession
    			  , dateCreated 
				  , dateCreatedAsDay = convert(varchar(10), dateCreated, 101)    	
	    from   dbo.v_contacts tblContact
    	where  tblContact.contactActive = 1
		and    tblContact.memberIdentifier = @strMemberIdentifier
        order by contact

    end
    else if (@FilterOnContactNameOnly = 1)
    begin


	    set @strNameFilterFull = @strNameFilter + '%'


    	select distinct 
				  tblContact.ContactIdentifier
				, tblContact.Contact
				, tblContact.affliate
				, tblContact.profession 
				, dateCreated
				, dateCreatedAsDay = convert(varchar(10), dateCreated, 101)
	    from   dbo.v_contact_find tblContact

    	where  tblContact.contactActive = 1

    	and tblContact.memberIdentifier = @strMemberIdentifier

        and   (

				   (tblContact.contact like @strNameFilterFull)
			  )

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
				, dateCreated
				, dateCreatedAsDay = convert(varchar(10), dateCreated, 101)
	    from   dbo.v_contact_find tblContact

    	where  tblContact.contactActive = 1

    	and tblContact.memberIdentifier = @strMemberIdentifier

        and   (
				   (tblContact.contact like @strNameFilterFull)
				or (tblContact.communicationData like @strNameFilterFull)
				or (tblContact.affliate like @strNameFilterFull)
				or (tblContact.profession like @strNameFilterFull)
				
				--contactAddress
				or 
				(
				
					   (tblContact.contactAddressAddress1 like @strNameFilterFull)
					or (tblContact.contactAddressAddress2 like @strNameFilterFull)					
					or (tblContact.contactAddressCity like @strNameFilterFull)					
					or (tblContact.contactAddressState like @strNameFilterFull)					
					or (tblContact.contactAddressPostalCode like @strNameFilterFull)																				
					--or (tblContact.contactAddressCountry like @strNameFilterFull)																				
										
				)					
								
			  )

        order by contact

    end

