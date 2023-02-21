use telcoInventory
go

drop table [dbo].[reports]
GO

CREATE TABLE [dbo].[reports] (
	[reportID] [smallint] NOT NULL ,
	[reportName] [varchar] (255) NOT NULL ,
	[reportDate] [datetime] NOT NULL ,
	[active] [bit] NOT NULL ,
	[reportSQL] [varchar] (255) NOT NULL ,
	[SQLType] [tinyint] NOT NULL ,
	[reportDesc] [varchar] (255) NOT NULL ,
	[sequence] [smallint] NOT NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[reports] WITH NOCHECK ADD 
	CONSTRAINT [PK_reports] PRIMARY KEY  CLUSTERED 
	(
		[reportID]
	) WITH  FILLFACTOR = 10  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[reports] ADD 
	CONSTRAINT [DF_reports_reportDate] DEFAULT (getdate()) FOR [reportDate],
	CONSTRAINT [DF_reports_SQLType] DEFAULT (1) FOR [SQLType],
	CONSTRAINT [DF_reports_sequence] DEFAULT (1) FOR [sequence]
GO

