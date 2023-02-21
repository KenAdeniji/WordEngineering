create procedure dbo.usp_getCompanySerialNumbers 
as
select distinct C.contactIdentifier, C.contact 
from contacts C, contact_communication CC 
where    C.memberIdentifier = CC.memberIdentifier
and    C.contactIdentifier = CC.contactIdentifier
and    CC.comm_type_id = 13
order  by C.contact
go

grant execute on dbo.usp_getCompanySerialNumbers to webUser
go