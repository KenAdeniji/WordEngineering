--exec sp_help documentAttachment
--exec sp_pkeys documentAttachment
--exec sp_fkeys contacts

alter table dbo.documentAttachment
drop constraint FK_documentAttachment
go

alter table dbo.documentAttachment
with check add constraint FK_documentAttachment
foreign key
(memberIdentifier, contactIdentifier)
references
dbo.contacts
(memberIdentifier, contactIdentifier)
go

select *
from    dbo.documentAttachment
where   contactIdentifier not in ( 
									select contactIdentifier
									from   dbo.contacts
								)
go

delete
from    dbo.documentAttachment
where   contactIdentifier not in ( 
									select contactIdentifier
									from   dbo.contacts
								)
go


