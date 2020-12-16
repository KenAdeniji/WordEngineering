CREATE DATABASE [IHaveDecidedToWorkOnAGradualImprovingSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'IHaveDecidedToWorkOnAGradualImprovingSystem_Data', FILENAME = N'E:\SQLServerDataFiles\IHaveDecidedToWorkOnAGradualImprovingSystem\IHaveDecidedToWorkOnAGradualImprovingSystemData.MDF' , SIZE = 73088KB , MAXSIZE = UNLIMITED, FILEGROWTH = 5%), 
 FILEGROUP [IHaveDecidedToWorkOnAGradualImprovingSystem_Image_FileGroup] 
( NAME = N'IHaveDecidedToWorkOnAGradualImprovingSystem_Image', FILENAME = N'E:\SQLServerDataFiles\IHaveDecidedToWorkOnAGradualImprovingSystem\IHaveDecidedToWorkOnAGradualImprovingSystemImage.NDF' , SIZE = 1024KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB ), 
 FILEGROUP [IHaveDecidedToWorkOnAGradualImprovingSystem_Index_FileGroup] 
( NAME = N'IHaveDecidedToWorkOnAGradualImprovingSystem_Index', FILENAME = N'E:\SQLServerDataFiles\IHaveDecidedToWorkOnAGradualImprovingSystem\IHaveDecidedToWorkOnAGradualImprovingSystemIndex.NDF' , SIZE = 1024KB , MAXSIZE = UNLIMITED, FILEGROWTH = 5%), 
 FILEGROUP [IHaveDecidedToWorkOnAGradualImprovingSystem_Text_FileGroup] 
( NAME = N'IHaveDecidedToWorkOnAGradualImprovingSystem_Text', FILENAME = N'E:\SQLServerDataFiles\IHaveDecidedToWorkOnAGradualImprovingSystem\IHaveDecidedToWorkOnAGradualImprovingSystemText.NDF' , SIZE = 1024KB , MAXSIZE = UNLIMITED, FILEGROWTH = 5%), 
 FILEGROUP [IHaveDecidedToWorkOnAGradualImprovingSystem_Xml_FileGroup] 
( NAME = N'IHaveDecidedToWorkOnAGradualImprovingSystem_Xml', FILENAME = N'E:\SQLServerDataFiles\IHaveDecidedToWorkOnAGradualImprovingSystem\IHaveDecidedToWorkOnAGradualImprovingSystemXml.NDF' , SIZE = 1024KB , MAXSIZE = UNLIMITED, FILEGROWTH = 5%)
 LOG ON 
( NAME = N'IHaveDecidedToWorkOnAGradualImprovingSystem_Log', FILENAME = N'E:\SQLServerDataFiles\IHaveDecidedToWorkOnAGradualImprovingSystem\IHaveDecidedToWorkOnAGradualImprovingSystemLog.LDF' , SIZE = 38976KB , MAXSIZE = 2048GB , FILEGROWTH = 5%)
GO
