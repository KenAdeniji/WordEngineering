
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER view [dbo].[v_contacts]
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
  from   dbo.contacts C

           left outer join dbo.affliations AFFL
				on  C.memberIdentifier = AFFL.memberIdentifier
				and C.affliation_code = AFFL.affliation_code

           left outer join dbo.support_profession PROFESSIONS
				on C.profession_code = PROFESSIONS.profession_code


GO

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO

