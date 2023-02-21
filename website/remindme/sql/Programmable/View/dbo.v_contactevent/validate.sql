use [remindme]
go

select top 100 *
from   dbo.v_contactevent
where  (

			   --( communicationLink is null )
			    ( eventLink = '' )			
			 or ( eventLink is not null )						
		)			