--exec sp_help contact_Address
--exec sp_pkeys contact_Address
--exec sp_fkeys contacts

alter table dbo.contact_Address
drop constraint FK_Contact_Address
go

alter table dbo.contact_Address
with check add constraint FK_Contact_Address
foreign key
(memberIdentifier, contactIdentifier)
references
dbo.contacts
(memberIdentifier, contactIdentifier)
go

select *
from    dbo.contact_address
where   contactIdentifier not in ( 
									select contactIdentifier
									from   dbo.contacts
								)
go

delete
from    dbo.contact_address
where   contactIdentifier not in ( 
									select contactIdentifier
									from   dbo.contacts
								)



