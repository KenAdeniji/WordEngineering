--use telcoInventory
--

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_GetReports]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_GetReports]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE  procedure usp_GetReports as
	select reportID, reportName, reportSQL, SQLType
	from   reports
	where  active = 1
	order  by sequence, reportName

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

grant execute on [dbo].[usp_GetReports] to webUser
go