SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

use remindme
go


ALTER   procedure usp_ContactCommunicationActivateToggle
(
	  @memberID        uniqueIdentifier
	, @ContactID       uniqueIdentifier
	, @sequenceID      uniqueIdentifier
)
as

begin

    set nocount on;
    set XACT_ABORT on;


    declare @ts datetime;
    declare @numberofRecordsAffected int
    declare @strLog  varchar(255);

    set @ts = getdate();


	begin tran

		update contact_communication

		set    active = ~ active 


        where  memberIdentifier =  @memberID
		
        and    contactIdentifier =  @ContactID
        
        and    sequenceIdentifier =  @sequenceID
		
    set @numberofRecordsAffected = @@ROWCOUNT

    
	if (@numberofRecordsAffected = 1)
	begin
       
        print 'commit tran';
        
        commit tran

	end
	else
	begin

        set @strLog = 
                          'In module '
                        + ' [dbo].[usp_ContactCommunicationDelete] '
                        + cast(@numberofRecordsAffected as varchar(10))
                        + ' record(s) affected'

        raiserror(@strLog, 16, 1)  

        print 'rollback tran';
                
		rollback tran;

    end

end
go

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

