CREATE DATABASE [URI]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'URI_Data', FILENAME = N'E:\SQLServerDataFiles\URI\URIData.MDF' , SIZE = 73088KB , MAXSIZE = UNLIMITED, FILEGROWTH = 5%), 
 FILEGROUP [URI_Image_FileGroup] 
( NAME = N'URI_Image', FILENAME = N'E:\SQLServerDataFiles\URI\URIImage.NDF' , SIZE = 1024KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB ), 
 FILEGROUP [URI_Index_FileGroup] 
( NAME = N'URI_Index', FILENAME = N'E:\SQLServerDataFiles\URI\URIIndex.NDF' , SIZE = 1024KB , MAXSIZE = UNLIMITED, FILEGROWTH = 5%), 
 FILEGROUP [URI_Text_FileGroup] 
( NAME = N'URI_Text', FILENAME = N'E:\SQLServerDataFiles\URI\URIText.NDF' , SIZE = 1024KB , MAXSIZE = UNLIMITED, FILEGROWTH = 5%), 
 FILEGROUP [URI_Xml_FileGroup] 
( NAME = N'URI_Xml', FILENAME = N'E:\SQLServerDataFiles\URI\URIXml.NDF' , SIZE = 1024KB , MAXSIZE = UNLIMITED, FILEGROWTH = 5%)
 LOG ON 
( NAME = N'URI_Log', FILENAME = N'E:\SQLServerDataFiles\URI\URILog.LDF' , SIZE = 38976KB , MAXSIZE = 2048GB , FILEGROWTH = 5%)
GO
