USE [remindme]
GO

/****** Object:  StoredProcedure [dbo].[usp_GetContactCommunicationInfo]    Script Date: 2/9/2019 6:45:47 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_GetContactCommunicationInfo]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[usp_GetContactCommunicationInfo] AS' 
END
GO




ALTER    procedure [dbo].[usp_GetContactCommunicationInfo] 
(
      @memberIdentifier varchar(255)
    , @contactIdentifier varchar(255)
	, @contactMinor	 varchar(255) = null
)
as

	select *

	from   dbo.v_contact_communication_formatted vwCCF 
	
	where  memberIdentifier = @memberIdentifier
	
	and    contactIdentifier = @contactIdentifier
	
	and    (
				
				   ( @contactMinor is null )
				
				or ( @contactMinor = '' )
				or
				(

					( 
						vwCCF.CommunicationData 
								like '%' + @contactMinor + '%'
					)

					or
					( 
						vwCCF.Comment 
								like '%' + @contactMinor + '%'
					)

					or
					( 
						vwCCF.communicationLink 
								like '%' + @contactMinor + '%'
					)

				)
		   )
	order  by active desc, CommunicationType, communicationData, Comment


GO


