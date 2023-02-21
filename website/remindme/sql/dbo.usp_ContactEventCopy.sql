USE [remindme]
GO

/****** Object:  StoredProcedure [dbo].[usp_ContactEventUpdate]    Script Date: 2/21/2021 9:44:17 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER OFF
GO

if object_id('[dbo].[usp_ContactEventCopy]') is null
begin

    exec('CREATE procedure [dbo].[usp_ContactEventCopy] as ')


end
go

ALTER procedure [dbo].[usp_ContactEventCopy]
(
       @strMemberID varchar(255)

     , @strContactID varchar(255)

     , @strEventID  varchar(255)
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


        INSERT INTO [dbo].[contactEvent]
        (
            [memberIdentifier]
           ,[contactIdentifier]
         --  ,[eventIdentifier]
           ,[statusCode]
           ,[eventName]
           ,[eventComment]
           ,[startDate]
           ,[endDate]
           ,[allDayEvent]
           ,[dateCreated]
           ,[dateUpdated]
           ,[eventLink]
     )
     SELECT
            tblCE.[memberIdentifier]
           ,tblCE.[contactIdentifier]
          -- ,[eventIdentifier]
           ,[statusCode]
           ,[eventName]
           ,[eventComment]
           ,[startDate]
           ,[endDate]
           ,[allDayEvent]
           ,@ts as [dateCreated]
           ,null as [dateUpdated]
           ,[eventLink]

    from [dbo].[contactEvent] tblCE
         
    where  1 = 1

    and    tblCE.contactIdentifier = @strContactID

    and    tblCE.eventIdentifier = @strEventID


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
GO

/*


    declare @strEventID varchar(255)

    declare @ts datetime

    set @strEventID = '600b83f8-1d1b-4cb8-baa4-89c5c1b17529'

    set @strEventID = '511c60b2-e92c-440f-9a74-c6184e8d1ea2'


     SELECT
            tblCE.[memberIdentifier]
           ,tblCE.[contactIdentifier]
          -- ,[eventIdentifier]
           ,[statusCode]
           ,[eventName]
           ,[eventComment]
           ,[startDate]
           ,[endDate]
           ,[allDayEvent]
           ,@ts as [dateCreated]
           ,null as [dateUpdated]
           ,[eventLink]
           ,tblCE.*

    from [dbo].[contacts] tblC
    
    inner join [dbo].[contactEvent] tblCE
            on  tblC.memberIdentifier = tblCE.memberIdentifier
            and tblC.contactIdentifier = tblCE.contactIdentifier

    where  1 = 1
    
    --and    tblC.contact = @strMemberID

    and    tblCE.eventIdentifier = @strEventID


*/