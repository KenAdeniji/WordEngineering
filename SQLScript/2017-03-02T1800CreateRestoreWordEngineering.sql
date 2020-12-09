CREATE DATABASE [WordEngineering]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WordEngineering_Data', FILENAME = N'E:\SQLServerDataFiles\WordEngineering\WordEngineeringData.MDF' , SIZE = 73088KB , MAXSIZE = UNLIMITED, FILEGROWTH = 5%), 
 FILEGROUP [WordEngineering_Image_FileGroup] 
( NAME = N'WordEngineering_Image', FILENAME = N'E:\SQLServerDataFiles\WordEngineering\WordEngineeringImage.NDF' , SIZE = 1024KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB ), 
 FILEGROUP [WordEngineering_Index_FileGroup] 
( NAME = N'WordEngineering_Index', FILENAME = N'E:\SQLServerDataFiles\WordEngineering\WordEngineeringIndex.NDF' , SIZE = 1024KB , MAXSIZE = UNLIMITED, FILEGROWTH = 5%), 
 FILEGROUP [WordEngineering_Text_FileGroup] 
( NAME = N'WordEngineering_Text', FILENAME = N'E:\SQLServerDataFiles\WordEngineering\WordEngineeringText.NDF' , SIZE = 1024KB , MAXSIZE = UNLIMITED, FILEGROWTH = 5%), 
 FILEGROUP [WordEngineering_Xml_FileGroup] 
( NAME = N'WordEngineering_Xml', FILENAME = N'E:\SQLServerDataFiles\WordEngineering\WordEngineeringXml.NDF' , SIZE = 1024KB , MAXSIZE = UNLIMITED, FILEGROWTH = 5%)
 LOG ON 
( NAME = N'WordEngineering_Log', FILENAME = N'E:\SQLServerDataFiles\WordEngineering\WordEngineeringLog.LDF' , SIZE = 38976KB , MAXSIZE = 2048GB , FILEGROWTH = 5%)
GO

RESTORE DATABASE WordEngineering
   FROM DISK = 'E:\SQLServerBackup\WordEngineering\WordEngineering_2017-03-01.bak'  
   WITH NORECOVERY,  
   MOVE 'WordEngineering_Data' TO 'E:\SQLServerDataFiles\WordEngineering\WordEngineering.mdf',   
   MOVE 'WordEngineering_Image' TO 'E:\SQLServerDataFiles\WordEngineering\WordEngineeringImage.ndf',   
   MOVE 'WordEngineering_Index' TO 'E:\SQLServerDataFiles\WordEngineering\WordEngineeringIndex.ndf',   
   MOVE 'WordEngineering_Text' TO 'E:\SQLServerDataFiles\WordEngineering\WordEngineeringText.ndf',   
   MOVE 'WordEngineering_Xml' TO 'E:\SQLServerDataFiles\WordEngineering\WordEngineeringXml.ndf',   
   MOVE 'WordEngineering_Log' TO 'E:\SQLServerDataFiles\WordEngineering\WordEngineering_Log.ldf';  
GO
