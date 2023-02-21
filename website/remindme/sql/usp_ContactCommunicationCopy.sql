SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

use remindme
go

if object_id('[dbo].[usp_ContactCommunicationCopy]') is null
begin

    exec('CREATE procedure [dbo].[usp_ContactCommunicationCopy] as ')


end
go

alter procedure [dbo].[usp_ContactCommunicationCopy]
(
	  @memberIdentifier uniqueIdentifier
	, @contactIdentifier uniqueIdentifier
	, @sequenceIdentifier uniqueIdentifier
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


        INSERT INTO [dbo].[contact_communication]
        (
            [contact_id]
           ,[sequence]
           ,[comm_type_id]
           ,[comm_data]
           ,[userID]
           ,[comment]
           ,[memberIdentifier]
           ,[contactIdentifier]
           --,[sequenceIdentifier]
           ,[dateCreated]
           ,[dateUpdated]
           ,[active]
           ,[communicationLink]
        )
        select
            [contact_id]
           ,[sequence]
           ,[comm_type_id]
           ,[comm_data]
           ,[userID]
           ,[comment]
           ,[memberIdentifier]
           ,[contactIdentifier]
           --,[sequenceIdentifier]
           ,@ts [dateCreated]
           ,null as [dateUpdated]
           ,[active]
           ,[communicationLink]

        from [dbo].[contact_communication] tblCC

        where  1 = 1


        and    tblCC.memberIdentifier = @memberIdentifier

        and    tblCC.contactIdentifier = @contactIdentifier

        and    tblCC.sequenceIdentifier = @sequenceIdentifier


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
                        + ' [dbo].[usp_ContactEventCopy] '
                        + cast(@numberofRecordsAffected as varchar(10))
                        + ' record(s) affected'

        raiserror(@strLog, 16, 1)  

        print 'rollback tran';
                
		rollback tran;

    end


end


Go

