CREATE DATABASE [BibleDictionary]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BibleDictionary_Data', FILENAME = N'E:\SQLServerDataFiles\BibleDictionary\BibleDictionaryData.MDF' , SIZE = 73088KB , MAXSIZE = UNLIMITED, FILEGROWTH = 5%), 
 FILEGROUP [BibleDictionary_Image_FileGroup] 
( NAME = N'BibleDictionary_Image', FILENAME = N'E:\SQLServerDataFiles\BibleDictionary\BibleDictionaryImage.NDF' , SIZE = 1024KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB ), 
 FILEGROUP [BibleDictionary_Index_FileGroup] 
( NAME = N'BibleDictionary_Index', FILENAME = N'E:\SQLServerDataFiles\BibleDictionary\BibleDictionaryIndex.NDF' , SIZE = 1024KB , MAXSIZE = UNLIMITED, FILEGROWTH = 5%), 
 FILEGROUP [BibleDictionary_Text_FileGroup] 
( NAME = N'BibleDictionary_Text', FILENAME = N'E:\SQLServerDataFiles\BibleDictionary\BibleDictionaryText.NDF' , SIZE = 1024KB , MAXSIZE = UNLIMITED, FILEGROWTH = 5%), 
 FILEGROUP [BibleDictionary_Xml_FileGroup] 
( NAME = N'BibleDictionary_Xml', FILENAME = N'E:\SQLServerDataFiles\BibleDictionary\BibleDictionaryXml.NDF' , SIZE = 1024KB , MAXSIZE = UNLIMITED, FILEGROWTH = 5%)
 LOG ON 
( NAME = N'BibleDictionary_Log', FILENAME = N'E:\SQLServerDataFiles\BibleDictionary\BibleDictionaryLog.LDF' , SIZE = 38976KB , MAXSIZE = 2048GB , FILEGROWTH = 5%)
GO
