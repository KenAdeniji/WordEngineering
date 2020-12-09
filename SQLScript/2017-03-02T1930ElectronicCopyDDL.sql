CREATE DATABASE [ElectronicCopy]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ElectronicCopy_Data', FILENAME = N'E:\SQLServerDataFiles\ElectronicCopy\ElectronicCopyData.MDF' , SIZE = 73088KB , MAXSIZE = UNLIMITED, FILEGROWTH = 5%), 
 FILEGROUP [ElectronicCopy_Image_FileGroup] 
( NAME = N'ElectronicCopy_Image', FILENAME = N'E:\SQLServerDataFiles\ElectronicCopy\ElectronicCopyImage.NDF' , SIZE = 1024KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB ), 
 FILEGROUP [ElectronicCopy_Index_FileGroup] 
( NAME = N'ElectronicCopy_Index', FILENAME = N'E:\SQLServerDataFiles\ElectronicCopy\ElectronicCopyIndex.NDF' , SIZE = 1024KB , MAXSIZE = UNLIMITED, FILEGROWTH = 5%), 
 FILEGROUP [ElectronicCopy_Text_FileGroup] 
( NAME = N'ElectronicCopy_Text', FILENAME = N'E:\SQLServerDataFiles\ElectronicCopy\ElectronicCopyText.NDF' , SIZE = 1024KB , MAXSIZE = UNLIMITED, FILEGROWTH = 5%), 
 FILEGROUP [ElectronicCopy_Xml_FileGroup] 
( NAME = N'ElectronicCopy_Xml', FILENAME = N'E:\SQLServerDataFiles\ElectronicCopy\ElectronicCopyXml.NDF' , SIZE = 1024KB , MAXSIZE = UNLIMITED, FILEGROWTH = 5%)
 LOG ON 
( NAME = N'ElectronicCopy_Log', FILENAME = N'E:\SQLServerDataFiles\ElectronicCopy\ElectronicCopyLog.LDF' , SIZE = 38976KB , MAXSIZE = 2048GB , FILEGROWTH = 5%)
GO
