USE [remindME]
GO
/****** Object:  StoredProcedure [dbo].[getReportDateofBirth]    Script Date: 09/03/2007 11:14:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

DROP   procedure [dbo].[usp_getReportDateofBirth_Adeniji]
go


CREATE   procedure [dbo].[usp_getReportDateofBirth_Adeniji] 
(
	@memberID varchar(255)
)
as

	set nocount on

	declare @monthID int
	declare @month varchar(255)

	declare @monthTable table
	(
		monthID int identity(1,1) not null,
		month varchar(255) not null
	)


	--set @memberID = '51517064-0267-11D4-B8A6-006008408162'

	insert into @monthTable(month) values('January')
	insert into @monthTable(month) values('February')
	insert into @monthTable(month) values('March')
	insert into @monthTable(month) values('April')
	insert into @monthTable(month) values('May')
	insert into @monthTable(month) values('June')
	insert into @monthTable(month) values('July')
	insert into @monthTable(month) values('August')
	insert into @monthTable(month) values('September')
	insert into @monthTable(month) values('October')
	insert into @monthTable(month) values('November')
	insert into @monthTable(month) values('December')


	declare @tempTable TABLE
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
	FROM   @monthTable 
	ORDER BY monthID

	open monthCursor

	FETCH NEXT FROM monthCursor 
	INTO @monthID, @month

	WHILE @@FETCH_STATUS = 0
	BEGIN

		insert into @tempTable
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

		insert into @tempTable
		(
		 memberIdentifier,
		 contactIdentifier,
		 monthId,
		 month,
		 Contact,
		 DOB
		 )
		 select 
		  C.memberIdentifier,
		  C.contactIdentifier,
		  null,
          null,
		  C.contact,
          C.DOB
		 from dbo.contacts C
			 inner join dbo.affliations tblAffliations
					on C.memberIdentifier = tblAffliations.memberIdentifier
					and C.affliation_code = tblAffliations.affliation_code
				 inner join	@monthTable M
					on M.monthID = datepart(month, C.DOB)
	     where M.monthID =  @monthID
		 and   tblAffliations.affliation_name = 'Adeniji'
		 and   c.affliation_code is not null
         order by datePart(month, C.DOB), datePart(day, C.DOB)
   
		FETCH NEXT FROM monthCursor 
		INTO @monthID, @month	

	END

	select 
		isNull(month, '') as 'Month',
		left(Contact, 60) as 'Contact',
		isNull((convert(varchar(2), datepart(month, DOB)) + '/' + convert(varchar(2), datepart(day, DOB))), '') as 'Date'
	from   @tempTable
    order  by id 

	CLOSE monthCursor
	DEALLOCATE monthCursor

go	

	
grant exec on [dbo].[usp_getReportDateofBirth_Adeniji] to public
go

/*

   exec [dbo].[usp_getReportDateofBirth_Adeniji] '51517064-0267-11D4-B8A6-006008408162'

*/