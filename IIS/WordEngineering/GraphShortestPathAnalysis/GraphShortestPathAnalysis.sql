-- CreateDemoDatabase.sql
-- creates a database to demo a CLR stored procedure
-- that does shortest path analysis

use master
go

/*
if exists(select * from sys.sysdatabases where name='GraphShortestPathAnalysis')
  drop database GraphShortestPathAnalysis
go
*/

USE [master]
GO

CREATE DATABASE [GraphShortestPathAnalysis]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GraphShortestPathAnalysis_Data', FILENAME = N'E:\SQLServerDataFiles\GraphShortestPathAnalysis\GraphShortestPathAnalysisData.MDF' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 5%), 
 FILEGROUP [GraphShortestPathAnalysis_Image_FileGroup] 
( NAME = N'GraphShortestPathAnalysis_Image', FILENAME = N'E:\SQLServerDataFiles\GraphShortestPathAnalysis\GraphShortestPathAnalysisImage.NDF' , SIZE = 1024KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB ), 
 FILEGROUP [GraphShortestPathAnalysis_Index_FileGroup] 
( NAME = N'GraphShortestPathAnalysis_Index', FILENAME = N'E:\SQLServerDataFiles\GraphShortestPathAnalysis\GraphShortestPathAnalysisIndex.NDF' , SIZE = 1024KB , MAXSIZE = UNLIMITED, FILEGROWTH = 5%), 
 FILEGROUP [GraphShortestPathAnalysis_Text_FileGroup] 
( NAME = N'GraphShortestPathAnalysis_Text', FILENAME = N'E:\SQLServerDataFiles\GraphShortestPathAnalysis\GraphShortestPathAnalysisText.NDF' , SIZE = 1024KB , MAXSIZE = UNLIMITED, FILEGROWTH = 5%), 
 FILEGROUP [GraphShortestPathAnalysis_Xml_FileGroup] 
( NAME = N'GraphShortestPathAnalysis_Xml', FILENAME = N'E:\SQLServerDataFiles\GraphShortestPathAnalysis\GraphShortestPathAnalysisXml.NDF' , SIZE = 1024KB , MAXSIZE = UNLIMITED, FILEGROWTH = 5%)
 LOG ON 
( NAME = N'GraphShortestPathAnalysis_Log', FILENAME = N'E:\SQLServerDataFiles\GraphShortestPathAnalysis\GraphShortestPathAnalysisLog.LDF' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 5%)
GO

ALTER DATABASE [GraphShortestPathAnalysis] SET COMPATIBILITY_LEVEL = 100
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GraphShortestPathAnalysis].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

use GraphShortestPathAnalysis
go

create table tblGraph
(
fromNode bigint not null,
toNode bigint not null,
edgeWeight real not null -- float(24)
)
go

set nocount on
insert into tblGraph values(111,222,1.0)
insert into tblGraph values(111,555,1.0)
insert into tblGraph values(222,111,2.0)
insert into tblGraph values(222,333,1.0)
insert into tblGraph values(222,555,1.0)
insert into tblGraph values(333,666,1.0)
insert into tblGraph values(333,888,1.0)
insert into tblGraph values(444,888,1.0)
insert into tblGraph values(555,111,2.0)
insert into tblGraph values(555,666,1.0)
insert into tblGraph values(666,333,2.0)
insert into tblGraph values(666,777,1.0)
insert into tblGraph values(777,444,2.0)
insert into tblGraph values(777,888,1.0)
go

create nonclustered index idxTblGraphFromNode on tblGraph(fromNode)
go
create nonclustered index idxTblGraphToNode on tblGraph(toNode)
go

alter database GraphShortestPathAnalysis set trustworthy on  
go
select is_trustworthy_on from sys.databases where name = 'GraphShortestPathAnalysis'
go

-- end create database statements

-- use VS to create a CLR stored procedure csp_ShortestPath

/*
DROP PROCEDURE csp_ShortestPath
GO

DROP ASSEMBLY GraphShortestPathAnalysis
GO

CREATE ASSEMBLY GraphShortestPathAnalysis from 'E:\WordEngineering\IIS\WordEngineering\GraphShortestPathAnalysis\GraphShortestPathAnalysis.dll' 
WITH PERMISSION_SET = SAFE
GO

CREATE PROCEDURE csp_ShortestPath
(
	@startNode				BigInt,
	@endNode				BigInt,
	@maxNodesToCheck		Int,
	@pathResult				NVarChar(4000)		OUTPUT,
	@distResult				Float				OUTPUT
) 
AS EXTERNAL NAME GraphShortestPathAnalysis.GraphShortestPathAnalysis.csp_ShortestPath
GO
*/

--create procedure ClrProc1(@param1 varchar(max)) as EXTERNAL NAME ClrClassLibraryAssembly.[ClrClassLibrary.ClrClassLibrary].ClrProc1
--System.Data.SqlTypes.SqlInt64 startNode, SqlInt64 endNode, SqlInt32 maxNodesToCheck, out SqlString pathResult, out SqlDouble distResult
declare @startNode bigint
declare @endNode bigint
declare @maxNodesToCheck int
declare @pathResult varchar(4000)
declare @distResult float

set @startNode = 222
set @endNode = 444
set @maxNodesToCheck = 100000

exec csp_ShortestPath @startNode, @endNode, @maxNodesToCheck, @pathResult output, @distResult output

select @pathResult

select @distResult

-- end CreateGraphDatabase.sql