USE [remindME]
GO
/****** Object:  View [dbo].[v_reports]    Script Date: 09/03/2007 14:04:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

drop view [dbo].[v_reports] 
go

create view [dbo].[v_reports] 
as
	select 
		   tblReports.reportID
		 , tblReports.reportName
		 , tblReports.reportDate
		 , tblReports.active
		 , tblReports.reportSQL
		 , tblReports.SQLType
		 , tblReports.sequence
		 , tblReports.dataStoreId
		 , tblReportDataStore.DATASTORECONNECTIONSTRING
		 , isNull(tblReports.MSReportServicesURL, '') MSReportServicesURL
	from   dbo.reports tblReports
            inner join dbo.REPORTDATASTORE tblReportDataStore
                on tblReports.dataStoreID = tblReportDataStore.dataStoreID 
	where  tblReports.active = 1
go

grant select on [dbo].[v_reports] to public
go