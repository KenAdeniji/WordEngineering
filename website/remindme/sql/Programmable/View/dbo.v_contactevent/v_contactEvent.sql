SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




alter view v_contactEvent as
select *,

       case statusCode
	      WHEN 1 THEN 'Not Started'
	      WHEN 2 THEN 'In Progress'
	      WHEN 3 THEN 'Completed'
        END AS statusCodeLiteral

       ,convert(varchar(10), startDate, 101) as startDateAsMMDDYYYY
       ,convert(varchar(10), endDate, 101) as endDateAsMMDDYYYY
	
       ,convert(varchar(20), startDate, 100) as startDateAsMMDDYYYYAMPM
       ,convert(varchar(20), endDate, 100) as endDateAsMMDDYYYYAMPM

       ,datePart(year, startDate) as startDateYear
       ,datePart(month, startDate) as startDateMonth
       ,datePart(day, startDate) as startDateDay
       ,datePart(hour, startDate) as startDateHour
       ,datePart(minute, startDate) as startDateMinute
       ,case  
	      WHEN datePart(hour, startDate) < 12 THEN 'AM'
	      else 'PM'
        END AS startDateAMPM

       ,datePart(year, endDate) as endDateYear
       ,datePart(month, endDate) as endDateMonth
       ,datePart(day, endDate) as endDateDay
       ,datePart(hour, endDate) as endDateHour
       ,datePart(minute, endDate) as endDateMinute
       ,case  
	      WHEN datePart(hour, endDate) < 12 THEN 'AM'
	      else 'PM'
        END AS endDateAMPM
    
       ,datediff(Day, startDate, endDate) as daysApart
       ,datediff(Day, getdate(), startDate) as NDaysInFuture

       ,convert(varchar(10), dateCreated, 101) as dateCreatedAsMMDDYYYY
       ,convert(varchar(10), dateUpdated, 101) as dateUpdatedAsMMDDYYYY

from   contactEvent



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

