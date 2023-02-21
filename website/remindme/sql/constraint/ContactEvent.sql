--exec sp_help contactEvent
--exec sp_pkeys contactEvent
--exec sp_fkeys contacts

alter table dbo.contactEvent
drop constraint FK_contactEvent
go

alter table dbo.contactEvent
with check add constraint FK_contactEvent
foreign key
(memberIdentifier, contactIdentifier)
references
dbo.contacts
(memberIdentifier, contactIdentifier)
go

select *
from    dbo.contactEvent
where   contactIdentifier not in ( 
									select contactIdentifier
									from   dbo.contacts
								)


delete
from    dbo.contactEvent
where   contactIdentifier not in ( 
									select contactIdentifier
									from   dbo.contacts
								)



