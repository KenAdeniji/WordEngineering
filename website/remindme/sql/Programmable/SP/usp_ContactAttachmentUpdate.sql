use remindME
go

if object_id('dbo.usp_ContactAttachmentUpdate') is not null
begin
	drop proc dbo.usp_ContactAttachmentUpdate
end
go

create procedure usp_ContactAttachmentUpdate
(
       @memberIdentifier varchar(255)
	,  @contactIdentifier varchar(255)
	,  @documentAttachmentIdentifier varchar(255)
	,  @attachmentName varchar(255)
	,  @attachmentFileName varchar(255)
	,  @attachmentContentType varchar(255)
	,  @attachmentDescription varchar(2000)
	,  @attachmentData image = null
)
as

	declare @dated datetime

	set @dated = getdate()

	if (@documentAttachmentIdentifier is null)
	begin

		set @documentAttachmentIdentifier = NEWID()

		insert into dbo.documentAttachment
		(
			  memberIdentifier
			, contactIdentifier
			, documentAttachmentIdentifier
			, sequenceNbr
			, dateCreated
			, dateUpdated
			, attachmentName
			, attachmentFilename
			, attachment
			, contentType
			, attachmentDescription
		)
	values
		(
			  @memberIdentifier
			, @contactIdentifier
			, @documentAttachmentIdentifier
			, 0 -- sequenceNbr
			, @dated
			, null
			, @attachmentName
			, @attachmentFileName
			, @attachmentData
			, @attachmentContentType -- contentType
			, @attachmentDescription -- contentType
		)
	

	end

go


grant execute on dbo.usp_ContactAttachmentUpdate to public
go