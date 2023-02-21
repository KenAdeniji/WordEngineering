--exec sp_pkeys affliations
--exec sp_fkeys contacts
--exec sp_help contacts

alter table dbo.contacts
drop constraint FK_Contact_Affliation
go

alter table dbo.contacts
with check add constraint FK_Contact_Affliation
foreign key
(memberIdentifier, affliation_code)
references
dbo.affliations
(memberIdentifier, affliation_code)
go

alter table dbo.affliations
drop constraint PK_affliation_1__10
go

alter table dbo.affliations
add constraint PK_affliation_1__10
primary key
(memberIdentifier, affliation_code)
go

select *
from    dbo.contacts
where   affliation_code not in ( 
									select affliation_code 
									from   dbo.affliations
								)
and     affliation_code is not null



update  dbo.contacts
set     affliation_code = null
where   affliation_code not in ( 
									select affliation_code 
									from   dbo.affliations
								)
and     affliation_code is not null