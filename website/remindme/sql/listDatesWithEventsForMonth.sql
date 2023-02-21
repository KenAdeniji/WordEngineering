SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



ALTER procedure listDatesWithEventsForMonth(@memberIdentifier varchar(255)
             			            ,@strDate varchar(30))


as

	declare @iDebug int

	declare @dateScheduleBase datetime
	declare @iDayofMonth int
	declare @DateBeginingofNextMonth datetime
	declare @DateLastDayofMonth datetime
	declare @dateScheduleBegin datetime
	declare @dateScheduleEnd datetime
	declare @dateScheduleCurrent datetime
	declare @iMonth int
	declare @iDayAdjustment int
	declare @iIndex int
	declare @cnt int	
	declare @dayofWeekAsString varchar(30)

	set nocount on

	select @iDebug = 0

	create table #days
	(
		date datetime not null,
		day smallint not null,
		dayofWeek varchar(30) not null
	)

	create table #events
	(
		 iIndex int not null
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
        	,eventStartDateAsMMDDYYYY datetime null
	        ,eventEndDateAsMMDDYYYY datetime null
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

	insert into #events
	exec renderCalendar @memberIdentifier, @dateScheduleBase, 2

	if (@iDebug = 1)
	begin	

		select eventStartDate, eventEndDate
		from #events

	end

	--day of month
	select @iDayofMonth = datePart(day, @dateScheduleBase)

	--day of month
	select @iDayAdjustment = @iDayofMonth

	--month
	select @iMonth = datePart(month, @dateScheduleBase)

	--if month is 12, then make adjustment for next year
	--if month is not 12, then make adjustment for current year
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

	SELECT @iIndex = 0

	while (@dateScheduleCurrent < @dateScheduleEnd)
	begin

		--select @dayofWeekAsInteger = @dayofWeekAsInteger + 1
		select @iIndex = @iIndex + 1

		--select week day
		select @dayofWeekAsString = datename(WeekDay, @dateScheduleCurrent)

		select @cnt = count(*)
		from   #events
		where  datediff(minute, eventStartDateAsMMDDYYY, @dateScheduleCurrent) >= 0 
		and    datediff(minute, @dateScheduleCurrent, eventEndDateAsMMDDYYYY) >= 0 


		--select  @dateScheduleCurrent, @cnt

		if (@cnt > 0) 
		begin
			insert into #days
			(date, day, dayofWeek)
			values (@dateScheduleCurrent 
                                ,datepart(day, @dateScheduleCurrent)
                                ,datename(weekday, @dateScheduleCurrent))
		end

	        select @dateScheduleCurrent = dateAdd(day, 1, @dateScheduleCurrent)


	end


        select * from #days

	set nocount off


	drop table #events
	drop table #days


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

grant execute on listDatesWithEventsForMonth to webUser
go