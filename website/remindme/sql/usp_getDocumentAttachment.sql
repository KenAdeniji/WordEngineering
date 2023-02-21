use remindme
go

drop proc dbo.usp_getDocumentAttachment
go

create proc dbo.usp_getDocumentAttachment
(
	  @memberID uniqueIdentifier = null
	, @documentAttachmentId uniqueIdentifier = null
)
as

	
	SELECT top 1
		   [memberIdentifier]
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
	 AND   (documentAttachmentIdentifier = @documentAttachmentId)

--	 WHERE (contentType in ('image/gif'))
--	 WHERE (contentType in ('application/msword'))
--	 WHERE (contentType in ('application/pdf'))

/*

*/
			
go

grant exec on dbo.usp_getDocumentAttachment to public
go
