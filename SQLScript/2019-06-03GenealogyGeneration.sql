USE [WordEngineering]
GO

/****** Object:  Table [dbo].[GenealogyGeneration]    Script Date: 6/3/2019 11:47:11 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[GenealogyGeneration](
	[GenealogyGenerationID] [int] NOT NULL,
	[Dated] [datetime] NOT NULL,
	[BibleWord] [nvarchar](100) NULL,
	[ParentId] [int] NULL,
	[ScriptureReference] [nvarchar](100) NULL,
 CONSTRAINT [PK_GenealogyGeneration] PRIMARY KEY NONCLUSTERED 
(
	[GenealogyGenerationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[GenealogyGeneration] ADD  CONSTRAINT [DF_GenealogyGeneration_Dated]  DEFAULT (getdate()) FOR [Dated]
GO


