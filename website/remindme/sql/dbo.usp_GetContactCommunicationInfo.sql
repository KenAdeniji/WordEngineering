USE [remindme]
GO

/****** Object:  StoredProcedure [dbo].[usp_GetContactCommunicationInfo]    Script Date: 3/21/2020 3:13:59 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
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


