USE [master]
GO
/****** Object:  Database [Sayings]    Script Date: 01/30/2012 22:02:00 ******/
CREATE DATABASE [Sayings] ON  PRIMARY 
( NAME = N'Sayings_Data', FILENAME = N'E:\SQLServerDataFiles\Sayings\SayingsData.MDF' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 5%), 
 FILEGROUP [Sayings_Image_FileGroup] 
( NAME = N'Sayings_Image', FILENAME = N'E:\SQLServerDataFiles\Sayings\SayingsImage.NDF' , SIZE = 1024KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB ), 
 FILEGROUP [Sayings_Index_FileGroup] 
( NAME = N'Sayings_Index', FILENAME = N'E:\SQLServerDataFiles\Sayings\SayingsIndex.NDF' , SIZE = 1024KB , MAXSIZE = UNLIMITED, FILEGROWTH = 5%), 
 FILEGROUP [Sayings_Text_FileGroup] 
( NAME = N'Sayings_Text', FILENAME = N'E:\SQLServerDataFiles\Sayings\SayingsText.NDF' , SIZE = 1024KB , MAXSIZE = UNLIMITED, FILEGROWTH = 5%), 
 FILEGROUP [Sayings_Xml_FileGroup] 
( NAME = N'Sayings_Xml', FILENAME = N'E:\SQLServerDataFiles\Sayings\SayingsXml.NDF' , SIZE = 1024KB , MAXSIZE = UNLIMITED, FILEGROWTH = 5%)
 LOG ON 
( NAME = N'Sayings_Log', FILENAME = N'E:\SQLServerDataFiles\Sayings\SayingsLog.LDF' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 5%)
GO

USE [Sayings]
GO

CREATE TABLE [dbo].[Contact](
	[ContactId] [int] IDENTITY(1,1) NOT NULL,
	[Dated] [datetime] NOT NULL,
	[UserId] [uniqueidentifier] NULL,
	[FirstName] [nvarchar](50) NULL,
	[MiddleName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[NickName] [nvarchar](50) NULL,
	[Organization] [nvarchar](50) NULL,
	[Birthday] [datetime] NULL,
	[Anniversary] [datetime] NULL,
	[Note] [varchar](max) NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY NONCLUSTERED 
(
	[ContactId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Contact] ADD  CONSTRAINT [DF_Contact_Dated]  DEFAULT (getdate()) FOR [Dated]
GO

CREATE TABLE [dbo].[Quote](
	[QuoteId] [int] IDENTITY(1,1) NOT NULL,
	[Dated] [datetime] NOT NULL,
	[ContactId] [int] NULL,
	[Commentary] [varchar](max) NOT NULL,
	[Event] [varchar](max) NULL,
 CONSTRAINT [PK_Quote] PRIMARY KEY NONCLUSTERED 
(
	[QuoteId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Quote]  WITH CHECK ADD  CONSTRAINT [FK_Contact_Quote] FOREIGN KEY([ContactId])
REFERENCES [dbo].[Contact] ([ContactId])
ON DELETE CASCADE
ON UPDATE CASCADE
GO

ALTER TABLE [dbo].[Quote] CHECK CONSTRAINT [FK_Contact_Quote]
GO

ALTER TABLE [dbo].[Quote] ADD  CONSTRAINT [DF_Quote_Dated]  DEFAULT (getdate()) FOR [Dated]
GO
