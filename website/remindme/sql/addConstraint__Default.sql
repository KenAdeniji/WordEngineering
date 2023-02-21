alter table contact_communication
drop constraint DF_contact_communication_active
go

ALTER TABLE dbo.contact_communication ADD CONSTRAINT
	DF_contact_communication_active DEFAULT 1 FOR active
go
