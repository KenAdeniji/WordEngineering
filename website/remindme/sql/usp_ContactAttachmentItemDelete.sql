use remindme
go

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


drop proc dbo.usp_ContactAttachmentItemDelete
go


CREATE procedure usp_ContactAttachmentItemDelete
(
      @strMemberID varchar(255)
     ,@strAttachmentID  varchar(255)
)
as

	begin tran

		begin

			delete from dbo.documentAttachment
			where  memberIdentifier = @strMemberID
			and    documentAttachmentIdentifier = @strAttachmentID

		end
		
			
		if (@@rowcount = 1)
		begin
			commit tran
		end
		else
		begin
			rollback tran
		end

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

grant exec on usp_ContactAttachmentItemDelete to public

