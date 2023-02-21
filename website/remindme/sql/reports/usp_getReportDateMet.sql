use [remindME]
go

DROP   procedure [dbo].[usp_getReportDateMet] 
go

CREATE   procedure [dbo].[usp_getReportDateMet] 
(
	@memberID varchar(255) = '51517064-0267-11D4-B8A6-006008408'
)
as

	 select 
	    C.memberIdentifier
	  , C.contactIdentifier
      , C.contact
      , isNull(C.dateCreated, '1/1/1900') as dateCreated
      , tblAffliations.affliation_name  
      , tblProfession.description
	 from dbo.contacts C
		 left outer join dbo.affliations tblAffliations
				on C.memberIdentifier = tblAffliations.memberIdentifier
				and C.affliation_code = tblAffliations.affliation_code
		 left outer join dbo.support_profession tblProfession
				on C.memberIdentifier = tblProfession.memberIdentifier
				and C.profession_code = tblProfession.profession_code
    order by C.dateCreated desc
go
