USE [WordEngineering]
GO

/****** Object:  Table [dbo].[AsWeSaidOmoSchoolYinNaTryOhunNaMakeEffort]    Script Date: 2/26/2019 9:41:37 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AsWeSaidOmoSchoolYinNaTryOhunNaMakeEffort](
	[AsWeSaidOmoSchoolYinNaTryOhunNaMakeEffortID] [int] IDENTITY(1,1) NOT NULL,
	[Dated] [datetime] NOT NULL,
	[FullName] [nvarchar](100) NULL,
	[FatherId] [int] NULL,
	[MotherId] [int] NULL,
 CONSTRAINT [PK_AsWeSaidOmoSchoolYinNaTryOhunNaMakeEffort] PRIMARY KEY NONCLUSTERED 
(
	[AsWeSaidOmoSchoolYinNaTryOhunNaMakeEffortID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[AsWeSaidOmoSchoolYinNaTryOhunNaMakeEffort] ADD  CONSTRAINT [DF_AsWeSaidOmoSchoolYinNaTryOhunNaMakeEffort_Dated]  DEFAULT (getdate()) FOR [Dated]
GO


