exec sp_help support_Profession

--alter table support_Profession
--drop constraint PK_support_profession

alter table support_Profession
add constraint PK_support_profession
primary key
(memberIdentifier, profession_code)


