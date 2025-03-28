SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

use remindme
go

if object_id('dbo.usp_getContactProfessions_filtered_on_profession') is not null
begin
    drop procedure dbo.usp_getContactProfessions_filtered_on_profession
end
go

CREATE  procedure dbo.usp_getContactProfessions_filtered_on_profession 
(
     @memberID varchar(255)
    ,@profession_code varchar(255)
)
as


	set nocount on

	declare @urlPrefix sysname

	set @urlPrefix = '../ContactBrowse.aspx?ContactID='


	select     
	           '<a href=' + @urlPrefix + convert(varchar(255), contactIdentifier) + ' target=_parent>' + rtrim(C.contact) + '<a/>' Contact,
               C.comment 
	from   contacts C,
           support_profession tblProfession (nolock)
	where  C.memberIdentifier = @memberID
	and    ( (C.profession_code is not null))
	and    C.memberIdentifier = tblProfession.memberIdentifier
	and    C.profession_code = tblProfession.profession_code
    and    C.profession_code = @profession_code
	order  by tblProfession.[description], C.contact
	
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

grant execute on dbo.usp_getContactProfessions_filtered_on_profession to webUser
go

--dbo.usp_getContactProfessions '51517064-0267-11D4-B8A6-006008408162'
--exec dbo.usp_getContactProfessions_filtered_on_profession '51517064-0267-11D4-B8A6-006008408162', 37
