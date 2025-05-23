SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

use remindme
go

if object_id('dbo.usp_getReportAffliations') is not null
begin
    drop procedure dbo.usp_getReportAffliations
end
go

CREATE  procedure usp_getReportAffliations @memberID varchar(255)
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
		affliationID int null,
		affliationName varchar(255) null,
        comment varchar(255),
        url varchar(255) null
	)

	insert into #tempTable
	(
		memberIdentifier,
		contactIdentifier,
		contact,
		affliationID,
		affliationName,
        comment,
        url
	)
	select     
               C.memberIdentifier,
               C.contactIdentifier,
               C.contact,
               C.affliation_code,
	           '',
               C.comment,	               
	           '<a href=' + @urlPrefix + convert(varchar(255), contactIdentifier) + ' target=_parent>' + rtrim(C.contact) + '<a/>'
	from   contacts C,
           affliations AFFL                
	where  C.memberIdentifier = @memberID
	and    ( (C.affliation_code is not null) and (C.affliation_code <> -1))
	and    C.memberIdentifier = AFFL.memberIdentifier
	and    C.affliation_code = AFFL.affliation_code
	order  by AFFL.affliation_name, C.contact

	select min(id) as id
	into   #groupHeaders
	from   #tempTable
        group  by affliationID

	update #tempTable
	set    affliationName = AFFL.affliation_name
	from   #tempTable A,
	       #groupHeaders gh,	
               affliations AFFL 
	where  A.memberIdentifier = AFFL.memberIdentifier
	and    A.affliationID = AFFL.affliation_code
	and    A.id = gh.id

	set nocount off

	select affliationName as 'Affliate'
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

grant execute on dbo.usp_getReportAffliations to webUser
go

