USE [WordEngineering]
GO
/****** Object:  Table [dbo].[ActToGod]    Script Date: 7/23/2020 11:47:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActToGod](
	[ActToGodID] [int] IDENTITY(1,1) NOT NULL,
	[Dated] [datetime] NOT NULL,
	[Major] [nvarchar](255) NOT NULL,
	[Minor] [nvarchar](255) NOT NULL,
	[Actor] [nvarchar](255) NULL,
	[ScriptureReference] [varchar](max) NULL,
	[HisWordID] [int] NULL,
	[Commentary] [varchar](max) NULL,
	[Uri] [varchar](255) NULL,
	[ContactId] [int] NULL,
 CONSTRAINT [PK_ActToGod] PRIMARY KEY CLUSTERED 
(
	[ActToGodID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ActToGod] ON 

INSERT [dbo].[ActToGod] ([ActToGodID], [Dated], [Major], [Minor], [Actor], [ScriptureReference], [HisWordID], [Commentary], [Uri], [ContactId]) VALUES (679, CAST(N'2020-07-23T15:07:24.213' AS DateTime), N'Qualifiers are entry.', N'#background-colorRed {
  background-color: red;  /* red */
}', NULL, NULL, NULL, N'<div id="background-colorRed">This will have a red background</div>', N'https://essential-css.programming-books.io/background-color-fd7e91aa109e4e868666e5fd0f397410', 10672)
INSERT [dbo].[ActToGod] ([ActToGodID], [Dated], [Major], [Minor], [Actor], [ScriptureReference], [HisWordID], [Commentary], [Uri], [ContactId]) VALUES (680, CAST(N'2020-07-23T15:49:10.463' AS DateTime), N'Excluded from the Gospel of John', N'Question and Answer, (Q&A)', N'Jesus Christ', N'Matthew 22:46, Mark 11:29, Mark 12:34, Luke 23:9', 134955, NULL, N'https://essential-css.programming-books.io/background-color-fd7e91aa109e4e868666e5fd0f397410', 10672)
SET IDENTITY_INSERT [dbo].[ActToGod] OFF
ALTER TABLE [dbo].[ActToGod] ADD  CONSTRAINT [DF_ActToGod_Dated]  DEFAULT (getdate()) FOR [Dated]
GO
ALTER TABLE [dbo].[ActToGod]  WITH CHECK ADD  CONSTRAINT [FK_ActToGod_Contact] FOREIGN KEY([ContactId])
REFERENCES [dbo].[Contact] ([ContactID])
GO
ALTER TABLE [dbo].[ActToGod] CHECK CONSTRAINT [FK_ActToGod_Contact]
GO
ALTER TABLE [dbo].[ActToGod]  WITH CHECK ADD  CONSTRAINT [FK_ActToGod_HisWord] FOREIGN KEY([HisWordID])
REFERENCES [dbo].[HisWord] ([HisWordID])
GO
ALTER TABLE [dbo].[ActToGod] CHECK CONSTRAINT [FK_ActToGod_HisWord]
GO
