use remindME
go

if object_id('dbo.documentAttachment') is not null
begin
	drop table dbo.documentAttachment
end
go

create table dbo.documentAttachment
(
	  memberIdentifier uniqueIdentifier not null
	, contactIdentifier uniqueIdentifier not null
	, documentAttachmentIdentifier uniqueIdentifier not null 
		primary key
	, sequenceNbr tinyint not null default 0
	, dateCreated datetime not null default getdate()
	, dateUpdated datetime null 
	, attachmentName varchar(255) not null
	, attachmentFilename varchar(255) not null
	, attachmentDescription varchar(1000) null
	, attachment image null
	, contentType  varchar(255) not null

)