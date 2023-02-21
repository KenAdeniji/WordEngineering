use remindme
go

--exec sp_help contact_communication
--exec sp_pkeys contact_communication
--exec sp_fkeys contacts

alter table dbo.contact_communication
drop constraint FK_contact_communication
go

alter table dbo.contact_communication
with check add constraint FK_contact_communication
foreign key
(memberIdentifier, contactIdentifier)
references
dbo.contacts
(memberIdentifier, contactIdentifier)
go

select *
from    dbo.contact_communication
where   contactIdentifier not in ( 
									select contactIdentifier
									from   dbo.contacts
								)


delete
from    dbo.contact_communication
where   contactIdentifier not in ( 
									select contactIdentifier
									from   dbo.contacts
								)



