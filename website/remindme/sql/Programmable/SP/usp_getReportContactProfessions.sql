SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

use remindme
go

if object_id('dbo.usp_getContactProfessions') is not null
begin
    drop procedure dbo.usp_getContactProfessions
end
go

CREATE  procedure dbo.usp_getContactProfessions @memberID varchar(255)
as

    --	exec dbo.getReportAffliations '51517064-0267-11D4-B8A6-006008408162'

	set nocount on

	declare @urlPrefix sysname

	set @urlPrefix = '../ContactBrowse.aspx?ContactID='


	create table #tempTable
	(
		id int identity(1,1) not null, 
		memberIdentifier uniqueIdentifier null,
		contactIdentifier uniqueIdentifier null,
		contact varchar(255) null,
		profession_code int null,
		profession_literal varchar(255) null,
        comment varchar(255),
        url varchar(255) null
	)

	insert into #tempTable
	(
		memberIdentifier,
		contactIdentifier,
		contact,
		profession_code,
		profession_literal,
        comment,
        url
	)
	select     
               C.memberIdentifier,
               C.contactIdentifier,
               C.contact,
               C.profession_code,
	           '',
               C.comment,	               
	           '<a href=' + @urlPrefix + convert(varchar(255), contactIdentifier) + ' target=_parent>' + rtrim(C.contact) + '<a/>'
	from   contacts C,
           support_profession tblProfession
	where  C.memberIdentifier = @memberID
	and    ( (C.profession_code is not null))
	and    C.memberIdentifier = tblProfession.memberIdentifier
	and    C.profession_code = tblProfession.profession_code
	order  by tblProfession.[description], C.contact

	select min(id) as id
	into   #groupHeaders
	from   #tempTable
    group  by profession_code

	update #tempTable
	set    profession_literal = AFFL.[description]
	from   #tempTable A,
	       #groupHeaders gh,	
           support_profession AFFL 
	where  A.memberIdentifier = AFFL.memberIdentifier
	and    A.profession_code = AFFL.profession_code
	and    A.id = gh.id

	set nocount off

	select profession_literal as 'Profession'
--           , contact as 'Contact'
           , '<a href=' + @urlPrefix + convert(varchar(255), contactIdentifier) + ' target=_parent>' + rtrim(contact) + '<a/>' as 'Contact'
		   , comment as 'Comment'
	from   #tempTable
	order by id

	drop table #tempTable

	


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

grant execute on dbo.usp_getContactProfessions to webUser
go

--dbo.usp_getContactProfessions '51517064-0267-11D4-B8A6-006008408162'
