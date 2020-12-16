USE [WordEngineering]
GO

CREATE TABLE [dbo].[BecauseYouExistThyMustBeFound](
	[SequenceOrderId] [int] IDENTITY(1,1) NOT NULL,
	[Dated] [datetime] NOT NULL CONSTRAINT [DF_BecauseYouExistThyMustBeFound_Dated]  DEFAULT (getdate()),
	[Linux] [varchar](MAX) NOT NULL,	
	[Windows] [varchar](MAX) NOT NULL,
	[Commentary] [varchar](8000) NULL,
	[ScriptureReference] [varchar](max) NULL,
	[Uri] [varchar](255) NULL,
	[ContactId] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
