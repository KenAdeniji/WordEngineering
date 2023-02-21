--exec sp_pkeys Professions
--exec sp_fkeys contacts
--exec sp_help contacts

alter table dbo.contacts
drop constraint FK_Contact_Profession

alter table dbo.contacts
with check add constraint FK_Contact_Profession
foreign key
(memberIdentifier, Profession_code)
references
dbo.support_Profession
(memberIdentifier, Profession_code)

alter table dbo.Professions
drop constraint PK_Profession_1__10

alter table dbo.Professions
add constraint PK_Profession_1__10
primary key
(memberIdentifier, Profession_code)


select *
from    dbo.contacts
where   Profession_code not in ( 
									select Profession_code 
									from   dbo.support_Profession
								)
and     Profession_code is not null



update  dbo.contacts
set     Profession_code = null
where   Profession_code not in ( 
									select Profession_code 
									from   dbo.support_Profession
								)
and     Profession_code is not null