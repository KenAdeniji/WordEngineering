USE [WordEngineering]
GO

/****** Object:  Table [dbo].[HowIRealizeHisBeing]    Script Date: 3/12/2019 7:44:46 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[HowIRealizeHisBeing](
	[HowIRealizeHisBeingID] [int] IDENTITY(1,1) NOT NULL,
	[Dated] [datetime] NOT NULL,
	[ScriptureReference] [varchar](max) NULL,
	[Commentary] [nvarchar](max) NULL,
	[Uri] [varchar](255) NULL,
	[ContactId] [int] NULL,
	[Actor] [varchar](255) NULL,
	[DatedFrom] [datetime] NULL,
	[DatedUntil] [datetime] NULL,
 CONSTRAINT [PK_HowIRealizeHisBeing] PRIMARY KEY CLUSTERED 
(
	[HowIRealizeHisBeingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[HowIRealizeHisBeing] ADD  CONSTRAINT [DF_HowIRealizeHisBeing_Dated]  DEFAULT (getdate()) FOR [Dated]
GO

ALTER TABLE [dbo].[HowIRealizeHisBeing]  WITH CHECK ADD  CONSTRAINT [FK_HowIRealizeHisBeing_Contact] FOREIGN KEY([ContactId])
REFERENCES [dbo].[Contact] ([ContactID])
GO

ALTER TABLE [dbo].[HowIRealizeHisBeing] CHECK CONSTRAINT [FK_HowIRealizeHisBeing_Contact]
GO


