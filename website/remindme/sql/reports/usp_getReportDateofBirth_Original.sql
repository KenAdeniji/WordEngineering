USE [remindME]
GO
/****** Object:  StoredProcedure [dbo].[getReportDateofBirth]    Script Date: 09/03/2007 11:14:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



--drop procedure getReportContacts--

DROP procedure [dbo].[usp_getReportDateofBirth]
go

CREATE   procedure [dbo].[usp_getReportDateofBirth] @memberID varchar(255)
as

	set nocount on

	declare @urlPrefix sysname

	set @urlPrefix = '../ContactBrowse.aspx?ContactID='

	declare @monthID int
	declare @month varchar(255)

	create table #month
	(
		monthID int identity(1,1) not null,
		month varchar(255) not null
	)


	insert into #month(month) values('January')
	insert into #month(month) values('February')
	insert into #month(month) values('March')
	insert into #month(month) values('April')
	insert into #month(month) values('May')
	insert into #month(month) values('June')
	insert into #month(month) values('July')
	insert into #month(month) values('August')
	insert into #month(month) values('September')
	insert into #month(month) values('October')
	insert into #month(month) values('November')
	insert into #month(month) values('December')


	create table #tempTable
	(
		id int identity(1,1) not null, 
		memberIdentifier uniqueIdentifier null,
		contactIdentifier uniqueIdentifier null,
		monthID int null,
		month varchar(20) null,
		Contact varchar(255) null,
		DOB datetime null,
	    url varchar(255)
	)


	DECLARE monthCursor CURSOR FOR 
	SELECT *
	FROM   #month 
	ORDER BY monthID

	open monthCursor

	FETCH NEXT FROM monthCursor 
	INTO @monthID, @month

	WHILE @@FETCH_STATUS = 0
	BEGIN

		insert into #tempTable
		(
		 memberIdentifier,
		 monthId,
		 month,
		 Contact,
		 DOB
		 )
		 select 
		  @memberID,
		  @monthID,
          @month,
		  '',
          null

		insert into #tempTable
		(
		 memberIdentifier,
		 contactIdentifier,
		 monthId,
		 month,
		 Contact,
		 DOB,
         url
		 )
		 select 
		  C.memberIdentifier,
		  C.contactIdentifier,
		  null,
          null,
		  C.contact,
          C.DOB,
          '<a href=' + @urlPrefix + convert(varchar(255), C.contactIdentifier) + ' target=_parent>' + rtrim(C.Contact) + '<a/>'
		 from #month M,
		      contacts C
	         where M.monthID = datepart(month, C.DOB)
                 and   M.monthID =  @monthID
                 order by datePart(month, C.DOB), datePart(day, C.DOB)
   
		FETCH NEXT FROM monthCursor 
		INTO @monthID, @month	

	END

	select 
		isNull(month, '') as 'Month',
		--left(Contact, 60) as 'Contact',
	    url as 'Contact',
		isNull((convert(varchar(2), datepart(month, DOB)) + '/' + convert(varchar(2), datepart(day, DOB))), '') as 'Date'
	from   #tempTable
        order  by id 

	CLOSE monthCursor
	DEALLOCATE monthCursor

	drop table #month
	drop table #tempTable

	


