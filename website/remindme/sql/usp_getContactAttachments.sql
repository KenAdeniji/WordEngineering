use remindME
go

if object_id('dbo.usp_getContactAttachments') is not null
begin
	drop proc dbo.usp_getContactAttachments
end
go

create procedure dbo.usp_getContactAttachments
(
       @memberIdentifier varchar(255)
	,  @contactIdentifier varchar(255)
)
as

	select tblDocumentAttachment.*
	from   dbo.v_documentAttachment tblDocumentAttachment
	where  tblDocumentAttachment.memberIdentifier = @memberIdentifier
	and	   tblDocumentAttachment.contactIdentifier =	@contactIdentifier
	order by dateCreated desc, attachmentName asc


go


grant execute on dbo.usp_getContactAttachments to public
go