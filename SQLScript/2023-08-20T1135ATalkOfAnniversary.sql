USE [WordEngineering]
GO

/****** Object:  Table [dbo].[ATalkOfAnniversary]    Script Date: 8/20/2023 2:18:32 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ATalkOfAnniversary](
	[ATalkOfAnniversaryID] [int] IDENTITY(1,1) NOT NULL,
	[Dated] [datetime2] NOT NULL,
	[Word] [nvarchar](MAX) NULL,
	[Commentary] [nvarchar](max) NULL,
	[Uri] [nvarchar](max) NULL,
	[ContactId] [int] NULL,
	[ScriptureReference] [nvarchar](max) NULL,
	[Filename] [nvarchar](max) NULL,
	[EnglishTranslation] [varchar](2000) NULL,
	[Location] [nvarchar](max) NULL,
	[Scene] [nvarchar](max) NULL,
	[Audience] [nvarchar](max) NULL,
	[DatedFrom] [datetime2] NOT NULL,
	[DatedUntil] [datetime2] NOT NULL,
	[GrammarCorrection] [nvarchar](max) NULL,
	[InternationalStandardBookNumberISBN] [nvarchar](max) NULL,
	[RelatedInformation] [nvarchar](max) NULL,
	[SourceActor] [nvarchar](max) NULL, /*Jarrod. Barnes & Noble. Old English name.	2017-11-28T19:22:08. 8884.*/
	[SourceMediaType] [nvarchar](max) NULL, /*book, audio, video*/
	[SourceReleaseDated] [datetime2] NOT NULL,
	[TransportationType] [nvarchar](max) NULL,
	[TransportationID] [nvarchar](max) NULL,
	[WordsInOtherLanguages] [nvarchar](max) NULL,
 CONSTRAINT [PK_ATalkOfAnniversary] PRIMARY KEY NONCLUSTERED 
(
	[ATalkOfAnniversaryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[ATalkOfAnniversary] ADD  CONSTRAINT [DF_ATalkOfAnniversarySimplyIHaveProvidedSufficientNeedForReUsingYouILetTheLightOpenToAdmireMine_Dated]  DEFAULT (getdate()) FOR [Dated]
GO

ALTER TABLE [dbo].[ATalkOfAnniversary]  WITH CHECK ADD  CONSTRAINT [FK_ATalkOfAnniversary_Contact] FOREIGN KEY([ContactId])
REFERENCES [dbo].[Contact] ([ContactID])
GO

ALTER TABLE [dbo].[ATalkOfAnniversary] CHECK CONSTRAINT [FK_ATalkOfAnniversary_Contact]
GO

EXEC sys.sp_addextendedproperty @name=N'Commentary', @value=N'The ATalkOfAnniversaryID column is an identity column, maintained by SQL Server, which automatically generates a sequential next identity. The goodness of this technique is that it is a candidate primary key, data loss is trackable, and it provides a sort key. The ATalkOfAnniversaryID column may serve as the primary and/or foreign key, the backbone of the Referential Integrity Constraint. It is debatable, the need for this identity column, when there is a dated column, which does similar work, and offers almost identical benefit; we discuss the dated column, next. One benefit of the identity column, is that it is unique, and it offers performance gain when querying based on where condition, and sorting.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ATalkOfAnniversary', @level2type=N'COLUMN',@level2name=N'ATalkOfAnniversaryID'
GO

EXEC sys.sp_addextendedproperty @name=N'Commentary', @value=N'The Dated column, as the name implies, is of the DateTime type. If an insert statement does not explicitly specify a value for the dated column, then it defaults to the current date and time of the (UTC-08:00) Pacific Time (US & Canada) time zone. There is a preference for the Coordinated Universal Time (UTC) format. ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ATalkOfAnniversary', @level2type=N'COLUMN',@level2name=N'Dated'
GO

EXEC sys.sp_addextendedproperty @name=N'Commentary', @value=N'As the name of the table denotes, the ATalkOfAnniversary table, is what the author heard from the source. The entries in the ATalkOfAnniversary table is exact, and representable in alphanumeric format (Numbers 12:6-8). In following, the Bible''s New Testament convention, where there is translation of Hebrew words to English, which is being interpreted, (Matthew 1:23, Mark 5:41, Mark 15:22, Mark 15:34, John 1:38, John 1:41, Acts 4:36); so also, there is translation of Yoruba words to English.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ATalkOfAnniversary'
GO


