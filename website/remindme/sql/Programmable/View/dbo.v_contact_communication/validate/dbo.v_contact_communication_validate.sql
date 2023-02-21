use [remindme]
go

select top 100 *
from   dbo.v_contact_communication
where  (

			   --( communicationLink is null )
			    ( communicationLink = '' )			
			 or ( communicationLink is not null )						
		)		