--exec sp_help contact_comment
--exec sp_pkeys contact_comment
--exec sp_fkeys contacts

alter table dbo.contact_comment
drop constraint FK_contact_comment
go

alter table dbo.contact_comment
with check add constraint FK_contact_comment
foreign key
(memberIdentifier, contactIdentifier)
references
dbo.contacts
(memberIdentifier, contactIdentifier)
go

select *
from    dbo.contact_comment
where   contactIdentifier not in ( 
									select contactIdentifier
									from   dbo.contacts
								)


delete
from    dbo.contact_comment
where   contactIdentifier not in ( 
									select contactIdentifier
									from   dbo.contacts
								)



