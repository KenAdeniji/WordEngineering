USE [remindme]
GO

/****** Object:  View [dbo].[v_contact_communication]    Script Date: 3/21/2020 3:16:00 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






ALTER   view [dbo].[v_contact_communication]
as

  select C.memberidentifier,
         C.contactidentifier,
         C.Contact, 
         convert(varchar(60), CC.sequenceIdentifier) as sequenceIdentifier,
         convert(varchar(60), CC.sequenceIdentifier) as communicationIdentifier,
         CC.comm_type_id as CommunicationTypeID,
         CC.comm_data  as 'CommunicationData',
         CC.comment as 'Comment',
         communicationLink
			= CC.communicationLink,
         convert(varchar(20), CC.dateCreated, 101) as 'dateCreated',
         convert(varchar(20), CC.dateUpdated, 101) as 'dateUpdated',
  	     CC.active,

         activeLiteral = case CC.active
 		 when 0 then 'No'
	          else 'Yes' 
         end,

         SC.comm_type as 'CommunicationType',
         SC.IsPhoneNumber,
         SC.IsPrivate
        
         , case SC.comm_type
            when 'Email' then 1
            else 0
            end as 'IsEmail'

         , case 
            when ( SC.comm_type = 'Web') then 1
            when ( SC.isWebSite =1) then 1
            else 0
            end as 'IsWeb'

/*

  from   dbo.contacts C,
 	     dbo.contact_communication CC,
	     dbo.support_communication SC

  where  C.memberidentifier = CC.memberidentifier
  and    C.contactidentifier = CC.contactidentifier
  and    CC.comm_type_id = SC.id


*/

  from   dbo.contacts C

  inner join dbo.contact_communication CC
  
        on   C.memberidentifier = CC.memberidentifier
        and  C.contactidentifier = CC.contactidentifier
  
  inner join dbo.support_communication SC
        
        on CC.comm_type_id = SC.id

GO


