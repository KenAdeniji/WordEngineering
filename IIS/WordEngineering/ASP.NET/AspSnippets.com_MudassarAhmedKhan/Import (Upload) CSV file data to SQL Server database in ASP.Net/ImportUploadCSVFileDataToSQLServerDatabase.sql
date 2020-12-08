CREATE TABLE [dbo].[MudassarAhmedKhan_ImportUploadCSVFileDataToSQLServerdatabase_Customers](
	[CustomerId] [int] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Country] [varchar](50) NOT NULL
) ON [PRIMARY]

GO

INSERT INTO MudassarAhmedKhan_ImportUploadCSVFileDataToSQLServerdatabase_Customers
SELECT 1, 'John Hammond', 'United States'
UNION ALL
SELECT 2, 'Mudassar Khan', 'India'
UNION ALL
SELECT 3, 'Suzanne Mathews', 'France'
UNION ALL
SELECT 4, 'Robert Schidner', 'Russia'
