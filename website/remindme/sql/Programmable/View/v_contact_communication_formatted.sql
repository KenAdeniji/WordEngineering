drop view dbo.v_contact_communication_formatted
go

create view dbo.v_contact_communication_formatted as

    select *
           , CommunicationData as 'communicationDataFormatted'
    from   dbo.v_contact_communication
    where  ((IsEmail != 1) and (IsWeb != 1))

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

go

grant select on dbo.v_contact_communication_formatted to webUser
go