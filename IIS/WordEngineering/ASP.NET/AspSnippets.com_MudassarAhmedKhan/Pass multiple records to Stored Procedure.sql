-- 	2014-08-05 AspSnippets.com Mudassar Ahmed Khan
-- 	http://www.aspsnippets.com/Articles/Pass-multiple-records-rows-to-a-Stored-Procedure-in-SQL-Server-using-C-and-VBNet.aspx

CREATE TABLE AspSnippetsMudassarAhmedKhanCustomer(
      [Id] [int] NULL,
      [Name] [varchar](100) NULL,
      [Country] [varchar](50) NULL
)
GO

CREATE TYPE [dbo].[AspSnippetsMudassarAhmedKhanCustomerType] AS TABLE(
      [Id] [int] NULL,
      [Name] [varchar](100) NULL,
      [Country] [varchar](50) NULL
)
GO

ALTER PROCEDURE [dbo].[usp_AspSnippetsMudassarAhmedKhan_InsertCustomer]
      @tblCustomer AspSnippetsMudassarAhmedKhanCustomerType READONLY
AS
BEGIN
	-- http://www.aspsnippets.com/Articles/Pass-multiple-records-rows-to-a-Stored-Procedure-in-SQL-Server-using-C-and-VBNet.aspx
	SET NOCOUNT ON;
	
	TRUNCATE TABLE AspSnippetsMudassarAhmedKhanCustomer
	INSERT INTO AspSnippetsMudassarAhmedKhanCustomer(Id, Name, Country)
	SELECT Id, Name, Country FROM @tblCustomer
END
GO
