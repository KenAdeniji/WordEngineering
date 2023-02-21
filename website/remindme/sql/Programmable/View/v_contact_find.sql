SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if object_id('dbo.v_contact_find') is not null
begin
	drop view dbo.v_contact_find
end
go

CREATE  view dbo.v_contact_find
as

  select 
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
  from   dbo.contacts C

			left outer join dbo.affliations AFFL

				on   C.memberIdentifier = AFFL.memberIdentifier
				and  C.affliation_code = AFFL.affliation_code

			left outer join dbo.support_profession PROFESSIONS
				on   C.memberIdentifier = AFFL.memberIdentifier
				and  C.profession_code = PROFESSIONS.profession_code


			left outer join dbo.contact_communication tblCommunication
				on   C.memberIdentifier = tblCommunication.memberIdentifier
				and  C.contactIdentifier = tblCommunication.contactIdentifier

			left outer join dbo.support_communication tblCommunicationSupport
				on   tblCommunication.memberIdentifier = tblCommunicationSupport.memberIdentifier
				and  tblCommunication.comm_type_id = tblCommunicationSupport.[id]


GO

SET QUOTED_IDENTIFIER OFF 
GO

SET ANSI_NULLS ON 
GO

grant select on dbo.v_contact_find to public
go


--select top 10 * from dbo.v_contact_find
