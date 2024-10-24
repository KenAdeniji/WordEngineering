USE [remindME]
GO
/****** Object:  StoredProcedure [dbo].[usp_GetReports]    Script Date: 09/03/2007 11:55:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

DROP  procedure [dbo].usp_GetMSReportServicesReports
go

CREATE  procedure [dbo].usp_GetMSReportServicesReports
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
		 , isNull(tblReports.MSReportServicesURL, '') MSReportServicesURL
		 , tblReportDataStore.DATASTORECONNECTIONSTRING
	from   dbo.reports tblReports
            inner join dbo.REPORTDATASTORE tblReportDataStore
                on tblReports.dataStoreID = tblReportDataStore.dataStoreID 
	where  tblReports.active = 1
	and    (
				    (tblReports.MSReportServicesURL is not null)
				and (tblReports.MSReportServicesURL != '')
			)

	order  by tblReports.sequence, tblReports.reportName

go

grant exec on [dbo].usp_GetMSReportServicesReports to public
go
