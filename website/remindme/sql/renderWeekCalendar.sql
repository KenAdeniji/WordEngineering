SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


alter procedure renderCalendar(@memberIdentifier varchar(255)
     			       ,@strDate varchar(30)
                               ,@iRenderType int = 1)


as

	declare @iDebug int

	declare @dateScheduleBase datetime
	declare @dateScheduleBegin datetime
	declare @dateScheduleEnd datetime
	declare @dateScheduleCurrent datetime
	declare @dateScheduleCurrentEnd datetime

	declare @DateBeginingofNextMonth datetime
        declare @DateLastDayofMonth datetime

	declare @iDayofWeek int
	declare @iWeekDayAdjustment int
	declare @iDayAdjustment	int
	declare @iDayofMonth int	
	declare @iMonth int	

	declare @iIndex int
	declare @iCnt int
	declare @strMessage varchar(255)

	declare @dayofWeekAsInteger int
	declare @dayofWeekAsString varchar(30)

	set nocount on

	select @iDebug = 0

	declare @iPeriodTypeStartedOnDaysPrior int
	declare @iPeriodTypeStartedOnDay int

	select @iPeriodTypeStartedOnDaysPrior = 1
	select @iPeriodTypeStartedOnDay = 2

	create table #events
	(
		 iIndex int identity(1,1)
		,memberIdentifier uniqueIdentifier null	
		,contactIdentifier uniqueIdentifier  null	
		,Contact varchar(255)  null			
		,eventIdentifier uniqueIdentifier  null		
	        ,iEventPeriodType smallint
		,dayofWeekAsInteger int
		,dayofWeekAsString varchar(20)
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

	--get base date
	select @dateScheduleBase = @strDate

	--get week day
	select @iDayofWeek = datepart(weekday, @dateScheduleBase)

	

	if (@iRenderType = 1)
	begin

		--Adjust for business week
		--Business week starts on Monday
		if (@iDayofWeek > 1) 
		begin
			select @iWeekDayAdjustment = 2 - @iDayofWeek 
		end	
		else
		begin
			select @iWeekDayAdjustment = @iDayofWeek + 1
		end	
	
		select @dateScheduleBegin = dateadd(day, @iWeekDayAdjustment, @dateScheduleBase)
		select @dateScheduleEnd = dateadd(day, 6, @dateScheduleBegin)
		select @dateScheduleCurrent = @dateScheduleBegin
	
		if (@iDebug = 1) 
		begin
			select 'Base Date ' + convert(varchar, @dateScheduleBase)
			select 'Week Day ' + convert(varchar, @iDayofWeek)
			select 'Week Day Adjustment ' + convert(varchar, @iWeekDayAdjustment)
			select 'Schedule Start Date ' + convert(varchar, @dateScheduleBegin)
			select 'Schedule End Date ' + convert(varchar, @dateScheduleEnd)
		end

	end
	else if (@iRenderType = 2)
	begin

		--day of month
		select @iDayofMonth = datePart(day, @dateScheduleBase)

		select @iDayAdjustment = @iDayofMonth

		--month
		select @iMonth = datePart(month, @dateScheduleBase)

		

		if (@iMonth <> 12)
		begin

			select @DateBeginingofNextMonth = convert(varchar, (datePart(month, @dateScheduleBase) + 1)) +
	                                                  '/1/' +
							  convert(varchar, (datePart(year, @dateScheduleBase)))

		end
		else
		begin

			select @DateBeginingofNextMonth = '1' +
	                                                  '/1/' +
							  convert(varchar, (datePart(year, @dateScheduleBase) + 1) )

		end



	
		select @DateLastDayofMonth = dateadd(Day, -1, @DateBeginingofNextMonth)

		select @dateScheduleBegin = convert(varchar, datePart(month, @dateScheduleBase)) +
                                             '/1/' +
					    convert(varchar, (datePart(year, @dateScheduleBase)))


		select @dateScheduleEnd = @DateLastDayofMonth

		select @dateScheduleCurrent = @dateScheduleBegin
	
		if (@iDebug = 1) 
		begin
			select 'Base Date ' + convert(varchar, @dateScheduleBase)
			select 'Schedule Start Date ' + convert(varchar, @dateScheduleBegin)
			select 'Schedule End Date ' + convert(varchar, @dateScheduleEnd)
		end

	end

	select @dayofWeekAsInteger = 0
	SELECT @iIndex = 0

	while (@dateScheduleCurrent < @dateScheduleEnd)
	begin

		--select @dayofWeekAsInteger = @dayofWeekAsInteger + 1
		select @iIndex = @iIndex + 1

		select @dayofWeekAsString = datename(WeekDay, @dateScheduleCurrent)

	        --events started on prior days, and crossed over 
	        insert into #events
		(	
			memberIdentifier
			,contactIdentifier
		        ,Contact
			,eventIdentifier
		        ,iEventPeriodType
			,eventName
			,eventComment
		        ,eventStartDate
		        ,eventEndDate
		        ,dayofWeekAsInteger
		        ,dayofWeekAsString
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
			    ,eventName
			    ,eventComment
		            ,startDate
		            ,endDate
			    ,@iIndex
		            ,@dayofWeekAsString
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


	        --events started on same day
	        insert into #events
		(	
			memberIdentifier
			,contactIdentifier
		        ,Contact
			,eventIdentifier
		        ,iEventPeriodType
			,eventName
			,eventComment
		        ,eventStartDate
		        ,eventEndDate
		        ,dayofWeekAsInteger
		        ,dayofWeekAsString
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
		            ,@iPeriodTypeStartedOnDay
			    ,eventName
			    ,eventComment
		            ,startDate
		            ,endDate
			    ,@iIndex
		            ,@dayofWeekAsString
		            ,statusCode
			    ,statusCodeLiteral                
		            ,allDayEvent 
		            ,datediff(Day, startDate, endDate)
		            ,datediff(Hour, startDate, endDate)
		            ,datediff(Minute, startDate, endDate)
		      from  v_contactEvent
		      where memberIdentifier = @memberIdentifier
		      and   (datediff(day, @dateScheduleCurrent, startDate) = 0)
		      select @dateScheduleCurrent = dateAdd(day, 1, @dateScheduleCurrent)


	end



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
      set     eventLabel = dayofWeekAsString + ' ' + convert(varchar, eventStartDate, 101)
             ,eventFormattedDispay = eventName + 
                                    ' (' +  Contact + ')' + 
                                    ' [' +  DurationAsString + ']'




    select * from #events

	set nocount off


	drop table #events



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

grant execute on renderCalendar to webUser
go

