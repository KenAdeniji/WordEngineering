USE [remindme]
GO

/****** Object:  View [dbo].[v_contact_find]    Script Date: 07/05/2014 19:44:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


if OBJECT_ID('[dbo].[v_contact_find]') is null
begin

	exec('create view [dbo].[v_contact_find] as select 1/0 as ''shell'' ')
	
end
go


ALTER  view [dbo].[v_contact_find]
as

  select 
		distinct	
           C.affliation_code
         , C.comment
         , C.contact
         , C.contactIdentifier
         , C.dateCreated
         , C.dateUpdated
         , convert(varchar(10), c.DOB, 101) as DOB
         , c.id
         , c.memberIdentifier
         , c.profession_code
         , AFFL.affliation_name affliate
         , PROFESSIONS.description profession

		 , tblCommunication.comm_data communicationData
		 , tblCommunicationSupport.[id] comunicationTypeID
		 , tblCommunicationSupport.[comm_type] comunicationType
		 , C.active as contactActive

		 , tblContactAddress.address1 as contactAddressAddress1
		 , tblContactAddress.address2 as contactAddressAddress2
		 , tblContactAddress.city as contactAddressCity
		 , tblContactAddress.[state] as contactAddressState
		 , tblContactAddress.PostalCode as contactAddressPostalCode
		 , tblContactAddress.country as contactAddressCountry


  from   dbo.contacts C

			left outer join dbo.affliations AFFL

				on   C.memberIdentifier = AFFL.memberIdentifier
				and  C.affliation_code = AFFL.affliation_code

			left outer join dbo.support_profession PROFESSIONS
				on   C.memberIdentifier = PROFESSIONS.memberIdentifier
				and  C.profession_code = PROFESSIONS.profession_code


			left outer join dbo.contact_communication tblCommunication
				on   C.memberIdentifier = tblCommunication.memberIdentifier
				and  C.contactIdentifier = tblCommunication.contactIdentifier


			left outer join dbo.support_communication tblCommunicationSupport
				on   tblCommunication.memberIdentifier = tblCommunicationSupport.memberIdentifier
				and  tblCommunication.comm_type_id = tblCommunicationSupport.[id]


			left outer join [dbo].[contact_address] tblContactAddress

				on   C.memberIdentifier = tblContactAddress.memberIdentifier
				and  C.contactIdentifier = tblContactAddress.contactIdentifier






GO


