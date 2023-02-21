use remindme
go

drop proc dbo.usp_getListofDocumentAttachments
go

create proc dbo.usp_getListofDocumentAttachments
(
	  @memberID uniqueIdentifier
	, @searchTag varchar(255) = null
)
as

	declare @searchTagWildcard varchar(255)

	set @searchTagWildcard = '%' + isNull(@searchTag, '') + '%'
	
	SELECT [memberIdentifier]
		  ,[contactIdentifier]
		  ,[documentAttachmentIdentifier]
		  ,[sequenceNbr]
		  ,[dateCreated]
		  ,[dateUpdated]
		  ,[attachmentName]
		  ,[attachmentFilename]
		  ,[attachmentDescription]
		  ,[attachment]
		  ,[contentType]
	 FROM [remindME].[dbo].[documentAttachment] (nolock)
	 WHERE (memberIdentifier = @memberID)
	 and
			(
				(attachmentName like @searchTagWildcard)
			)
			
go

grant exec on dbo.usp_getListofDocumentAttachments to public
go
