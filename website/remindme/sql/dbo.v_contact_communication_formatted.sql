USE [remindme]
GO

/****** Object:  View [dbo].[v_contact_communication_formatted]    Script Date: 3/21/2020 3:14:42 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



ALTER view [dbo].[v_contact_communication_formatted] as

    select *
           , CommunicationData as 'communicationDataFormatted'
    
    from   dbo.v_contact_communication
    
    where  (
                    (IsEmail != 1) 
                and (IsWeb != 1)
            )

    union

    select *
           , '<a href=mailto:' + CommunicationData + '>' + CommunicationData + '<a>' 'communicationDataFormatted'
    from   dbo.v_contact_communication
    where  IsEmail = 1

    union

    select *
           , '<a href=''' + CommunicationData + ''' target=_blank>' + CommunicationData + '<a>' 'communicationDataFormatted'
    from   dbo.v_contact_communication
    where  IsWeb = 1


GO


