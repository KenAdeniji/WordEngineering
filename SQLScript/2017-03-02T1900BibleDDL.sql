CREATE DATABASE [Bible]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Bible_Data', FILENAME = N'E:\SQLServerDataFiles\Bible\BibleData.MDF' , SIZE = 73088KB , MAXSIZE = UNLIMITED, FILEGROWTH = 5%), 
 FILEGROUP [Bible_Image_FileGroup] 
( NAME = N'Bible_Image', FILENAME = N'E:\SQLServerDataFiles\Bible\BibleImage.NDF' , SIZE = 1024KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB ), 
 FILEGROUP [Bible_Index_FileGroup] 
( NAME = N'Bible_Index', FILENAME = N'E:\SQLServerDataFiles\Bible\BibleIndex.NDF' , SIZE = 1024KB , MAXSIZE = UNLIMITED, FILEGROWTH = 5%), 
 FILEGROUP [Bible_Text_FileGroup] 
( NAME = N'Bible_Text', FILENAME = N'E:\SQLServerDataFiles\Bible\BibleText.NDF' , SIZE = 1024KB , MAXSIZE = UNLIMITED, FILEGROWTH = 5%), 
 FILEGROUP [Bible_Xml_FileGroup] 
( NAME = N'Bible_Xml', FILENAME = N'E:\SQLServerDataFiles\Bible\BibleXml.NDF' , SIZE = 1024KB , MAXSIZE = UNLIMITED, FILEGROWTH = 5%)
 LOG ON 
( NAME = N'Bible_Log', FILENAME = N'E:\SQLServerDataFiles\Bible\BibleLog.LDF' , SIZE = 38976KB , MAXSIZE = 2048GB , FILEGROWTH = 5%)
GO
