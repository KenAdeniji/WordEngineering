use [remindme]
go

select top 10 *
from   dbo.contact_communication
where  (

			   --( communicationLink is null )
			    ( communicationLink = '' )			
			 or ( communicationLink is not null )						
		)			