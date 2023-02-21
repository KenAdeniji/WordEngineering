use remindME
go

if object_id('dbo.v_documentAttachment') is not null
begin
	drop view dbo.v_documentAttachment
end
go

create view dbo.v_documentAttachment
as
	select *
		   , convert(varchar(30), dateCreated, 101) as dateCreatedAsString
	from   dbo.documentAttachment
go