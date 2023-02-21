--exec sp_help contact_task
--exec sp_pkeys contact_task
--exec sp_fkeys contacts

alter table dbo.contact_task
drop constraint FK_contact_task

alter table dbo.contact_task
with check add constraint FK_contact_task
foreign key
(memberIdentifier, contactIdentifier)
references
dbo.contacts
(memberIdentifier, contactIdentifier)
go

select *
from    dbo.contact_task
where   contactIdentifier not in ( 
									select contactIdentifier
									from   dbo.contacts
								)


delete
from    dbo.contact_task
where   contactIdentifier not in ( 
									select contactIdentifier
									from   dbo.contacts
								)



