USE [remindME]
GO
/****** Object:  StoredProcedure [dbo].[sp_ContactInsert]    Script Date: 09/01/2007 22:28:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER procedure [dbo].[sp_ContactInsert]
(
      @strMemberID varchar(255)
     ,@strContact varchar(255)
     ,@iAffliate int
     ,@iProfession int
     ,@strDOB varchar(255)
     ,@strComment varchar(255)
     ,@strContactIDOut varchar(255) = null OUTPUT
)
as

	declare @strContactID uniqueidentifier

	set nocount on

	select @strContactID = NEWID()

	set nocount off

	begin tran

		if (@strComment is not null)
		begin
			select @strComment = ltrim(rtrim(@strComment))
		end

		if (@strDOB = '')
		begin
			select @strDOB = null
		end

		insert contacts
		(
			memberIdentifier,
            contactIdentifier,
  			contact,
			affliation_code,	
			profession_code,	
            DOB,
            comment
		)
		values
		(
			      @strMemberID	
				, @strContactID
                , @strContact
				, case @iAffliate
						when -1 then null
						else @iAffliate
				  end
				, case @iProfession
						when -1 then null
						else @iProfession
				  end
                , @strDOB
                , @strComment
		)

		if (@@rowcount = 1)
		begin

			select @strContactIDOut = @strContactID
			commit tran
		end
		else
		begin
			rollback tran
		end
