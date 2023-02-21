SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


ALTER procedure renderDayCalendar(@memberIdentifier varchar(255)
                				  ,@strDate varchar(30)
                                  ,@iHrBegin int = 0
                                  ,@iHrEnd int = 23
				                  ,@iMinutesIncr int = 60)


as

	declare @iDebug int

	declare @dateScheduleBase datetime
	declare @dateScheduleBegin datetime
	declare @dateScheduleEnd datetime
	declare @dateScheduleCurrent datetime
	declare @dateScheduleCurrentEnd datetime

	declare @iCnt int
	declare @strMessage varchar(255)

	set nocount on

	select @iDebug = 0

    declare @iPeriodTypeStartedOnDaysPrior int
    declare @iPeriodTypeStartedHrsPriorToScheduleRequested int
    declare @iPeriodTypeStartedDuringScheduleRequested int
    declare @iPeriodTypeStartedHrsAfterScheduleRequested int

    select @iPeriodTypeStartedOnDaysPrior = 1
    select @iPeriodTypeStartedHrsPriorToScheduleRequested = 2
    select @iPeriodTypeStartedDuringScheduleRequested = 3
    select @iPeriodTypeStartedHrsAfterScheduleRequested = 4

	create table #schedule
	(
		 iIndex int identity(1,1)
		,dateScheduleBegin datetime
		,dateScheduleEnd datetime
	)

	create table #events
	(
		 iIndex int identity(1,1)
		,memberIdentifier uniqueIdentifier null	
		,contactIdentifier uniqueIdentifier  null	
		,Contact varchar(255)  null			
		,eventIdentifier uniqueIdentifier  null		
        ,iEventPeriodType smallint
		,dateScheduleBegin datetime  null	
		,dateScheduleEnd datetime  null	
		,eventName varchar(1000)  null	
		,eventComment varchar(1000)  null	
        ,eventStartDate datetime null
        ,eventEndDate datetime null
		,statusCode smallint  null	
		,statusCodeLiteral varchar(255)  null	
		,allDayEvent smallint  null	
        ,DurationInDays int null
        ,DurationInHrs int null
        ,DurationInMinutes int null
        ,DurationAsString varchar(255)

        ,eventLabel varchar(255)
        ,eventFormattedDispay  varchar(255)
	)

	select @dateScheduleBase = @strDate

	select @dateScheduleBegin = dateadd(hour, @iHrBegin, @dateScheduleBase)
	select @dateScheduleEnd = dateadd(hour, @iHrEnd, @dateScheduleBase)
	select @dateScheduleCurrent = @dateScheduleBegin

	if (@iDebug = 1) 
	begin
		select 'Base Date ' + convert(varchar, @dateScheduleBase)
		select 'Schedule Start Date ' + convert(varchar, @dateScheduleBegin)
		select 'Schedule End Date ' + convert(varchar, @dateScheduleEnd)
	end

   --events started on prior days, and crossed over 
   insert into #events
   (	
	memberIdentifier
	,contactIdentifier
    ,Contact
	,eventIdentifier
    ,iEventPeriodType
	,dateScheduleBegin
	,dateScheduleEnd
	,eventName
	,eventComment
    ,eventStartDate
    ,eventEndDate
	,statusCode
	,statusCodeLiteral                
	,allDayEvent
    ,DurationInDays
    ,DurationInHrs
    ,DurationInMinutes
     )
     select @memberIdentifier
            ,contactIdentifier
            ,Contact
            ,eventIdentifier
            ,@iPeriodTypeStartedOnDaysPrior
	        ,null
            ,null
	        ,eventName
	        ,eventComment
            ,startDate
            ,endDate
            ,statusCode
		    ,statusCodeLiteral                
            ,allDayEvent 
            ,datediff(Day, startDate, endDate)
            ,datediff(Hour, startDate, endDate)
            ,datediff(Minute, startDate, endDate)
      from  v_contactEvent
      where memberIdentifier = @memberIdentifier
      and   startDate <= @dateScheduleBase
      and   endDate > @dateScheduleBase
      and   eventIdentifier not in ( select eventIdentifier from #events)


   --events started on same day, but before requested scsheduled time
   insert into #events
   (	
	memberIdentifier
	,contactIdentifier
    ,Contact
	,eventIdentifier
    ,iEventPeriodType
	,dateScheduleBegin
	,dateScheduleEnd
	,eventName
	,eventComment
    ,eventStartDate
    ,eventEndDate
	,statusCode
	,statusCodeLiteral                
	,allDayEvent
    ,DurationInDays
    ,DurationInHrs
    ,DurationInMinutes
     )
     select @memberIdentifier
            ,contactIdentifier
            ,Contact
            ,eventIdentifier
            ,@iPeriodTypeStartedHrsPriorToScheduleRequested
	        ,null
            ,null
	        ,eventName
	        ,eventComment
            ,startDate
            ,endDate
            ,statusCode
		    ,statusCodeLiteral                
            ,allDayEvent 
            ,datediff(Day, startDate, endDate)
            ,datediff(Hour, startDate, endDate)
            ,datediff(Minute, startDate, endDate)
      from  v_contactEvent
      where memberIdentifier = @memberIdentifier
      and   startDate < @dateScheduleBegin
      and   (datediff(Day, startDate, @dateScheduleBase) = 0)
      and   eventIdentifier not in ( select eventIdentifier from #events)


	while (@dateScheduleCurrent < @dateScheduleEnd)
	begin

	   select @dateScheduleCurrentEnd = dateadd(minute, @iMinutesIncr, @dateScheduleCurrent)

	   insert into #schedule
	   (dateScheduleBegin, dateScheduleEnd)
	   values (@dateScheduleCurrent, @dateScheduleCurrentEnd)	

	   insert into #events
	   (	
		memberIdentifier
		,contactIdentifier
	        ,Contact
		,eventIdentifier
        	,iEventPeriodType
		,dateScheduleBegin
		,dateScheduleEnd
		,eventName
		,eventComment
	        ,eventStartDate
        	,eventEndDate
		,statusCode
		,statusCodeLiteral                
		,allDayEvent
	        ,DurationInDays
        	,DurationInHrs
	        ,DurationInMinutes
	     )
	     select @memberIdentifier
        	    ,contactIdentifier
               	,Contact
                ,eventIdentifier
                ,@iPeriodTypeStartedDuringScheduleRequested
		        ,@dateScheduleCurrent
                ,@dateScheduleCurrentEnd
		        ,eventName
		        ,eventComment
                ,startDate
                ,endDate
                ,statusCode
    		    ,statusCodeLiteral                
                ,allDayEvent 
                ,datediff(Day, startDate, endDate)
                ,datediff(Hour, startDate, endDate)
                ,datediff(Minute, startDate, endDate)
	      from  v_contactEvent
	      where memberIdentifier = @memberIdentifier
	      and   startDate >= @dateScheduleCurrent	
	      and   startDate < @dateScheduleCurrentEnd
              and   eventIdentifier not in ( select eventIdentifier from #events)

	      select @dateScheduleCurrent = @dateScheduleCurrentEnd


	end

   --events started on same day, but after requested scheduled time
   insert into #events
   (	
	memberIdentifier
	,contactIdentifier
    ,Contact
	,eventIdentifier
    ,iEventPeriodType
	,dateScheduleBegin
	,dateScheduleEnd
	,eventName
	,eventComment
    ,eventStartDate
    ,eventEndDate
	,statusCode
	,statusCodeLiteral                
	,allDayEvent
    ,DurationInDays
    ,DurationInHrs
    ,DurationInMinutes
     )
     select @memberIdentifier
            ,contactIdentifier
            ,Contact
            ,eventIdentifier
            ,@iPeriodTypeStartedHrsAfterScheduleRequested
	        ,null
            ,null
	        ,eventName
	        ,eventComment
            ,startDate
            ,endDate
            ,statusCode
		    ,statusCodeLiteral                
            ,allDayEvent 
            ,datediff(Day, startDate, endDate)
            ,datediff(Hour, startDate, endDate)
            ,datediff(Minute, startDate, endDate)
      from  v_contactEvent
      where memberIdentifier = @memberIdentifier
      and   startDate > @dateScheduleEnd
      and   (datediff(Day, startDate, @dateScheduleBase) = 0)
      and   eventIdentifier not in ( select eventIdentifier from #events)

      update #events
      set    DurationAsString = convert(varchar, DurationInDays) + ' Day'
      where  DurationInDays = 1
    
      update #events
      set    DurationAsString = convert(varchar, DurationInDays) + ' Day(s)'
      where  DurationInDays > 1

      update #events
      set    DurationAsString = 'All Day'
      where  DurationInDays = 0
      and    DurationInHrs > 0
      and    allDayEvent = 1

      update #events
      set    DurationAsString = convert(varchar, DurationInHrs) + ' Hr.'
      where  DurationInDays = 0
      and    DurationInHrs = 1
      and    allDayEvent = 0

      update #events
      set    DurationAsString = convert(varchar, DurationInHrs) + ' Hrs.'
      where  DurationInDays = 0
      and    DurationInHrs > 1
      and    allDayEvent = 0

      update #events
      set    DurationAsString = convert(varchar, DurationInMinutes) + ' Min(s).'
      where  DurationInDays = 0
      and    DurationInHrs = 0

      --update eventLabel  
      update #events
      set    eventLabel = convert(varchar, eventStartDate, 101)
             ,eventFormattedDispay = eventName + '  [' +  DurationAsString + ']'
      where  ieventPeriodType = @iPeriodTypeStartedOnDaysPrior  

      update #events
      set    eventLabel = substring(convert(varchar, eventStartDate, 100),13,100)
             ,eventFormattedDispay = eventName + '  [' +  DurationAsString + ']'
      where  ieventPeriodType = @iPeriodTypeStartedHrsPriorToScheduleRequested

      update #events
      set    eventLabel = substring(convert(varchar, eventStartDate, 100),13,100)
             ,eventFormattedDispay = eventName + '  [' +  DurationAsString + ']'
      where  ieventPeriodType = @iPeriodTypeStartedDuringScheduleRequested

      update #events
      set    eventLabel = substring(convert(varchar, eventStartDate, 100),13,100)
             ,eventFormattedDispay = eventName + '  [' +  DurationAsString + ']'
      where  ieventPeriodType = @iPeriodTypeStartedHrsAfterScheduleRequested 


      --update eventLabel  
      update #events
      set    eventFormattedDispay = eventName + 
                                    ' (' +  Contact + ')' + 
                                    ' [' +  DurationAsString + ']'


	if (@iDebug = 1) 
	begin
	     select * from #schedule
	end

    select * from #events

	set nocount off

	drop table #schedule
	drop table #events



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

