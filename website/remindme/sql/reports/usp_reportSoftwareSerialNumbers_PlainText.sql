USE [remindME]
GO
/****** Object:  StoredProcedure [dbo].[usp_reportSoftwareSerialNumbers]    Script Date: 09/03/2007 19:09:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

drop proc [dbo].[usp_reportSoftwareSerialNumbers_PlainText]
go


CREATE  procedure [dbo].[usp_reportSoftwareSerialNumbers_PlainText] 
(
	@memberID varchar(255) = null
)
as

	set nocount on

	set @memberID = '51517064-0267-11D4-B8A6-006008408162'

	declare @id_software_serial_number int

	select @id_software_serial_number = 13

	declare @tempTable table
	(
		id int identity(1,1) not null, 
		memberIdentifier uniqueIdentifier null,
		sectionHeader varchar(255) null,
		contactIdentifier uniqueIdentifier null,
		contact varchar(255) null,
		software varchar(255) null,
		softwareSerialNumber varchar(255) null
	)

	declare @groupHeaders TABLE
	(
		id int
	)

	insert into @tempTable
	(
		memberIdentifier,
		contactIdentifier,
		contact,
		software,
		softwareSerialNumber
	)
	select C.memberIdentifier,
	       C.contactIdentifier,
           --dbo.hrefContact(C.contactIdentifier, C.contact),
		   C.contact,
           CC.comm_data,
	       CC.comment	
	from   contacts C,
               contact_communication CC
	where  C.memberIdentifier = @memberID
	and    C.memberIdentifier = CC.memberIdentifier
	and    C.contactIdentifier = CC.contactIdentifier
	and    CC.comm_type_id = @id_software_serial_number
	order  by C.contact, CC.comm_data

	insert into @groupHeaders
	select min(id) as id
	from   @tempTable
    group  by contact

	update @tempTable
	set    sectionHeader = contact
	from   @tempTable A,
           @groupHeaders gh
	where  A.id = gh.id


	set nocount off


	select sectionHeader as 'Client',
           software as 'Sofware',
	       softwareSerialNumber as 'Software Serial Number'		
    from   @tempTable
	order by id asc


	
grant exec on [dbo].[usp_reportSoftwareSerialNumbers_PlainText] to public
go