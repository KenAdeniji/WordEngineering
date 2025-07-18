--http://github.com/KenAdeniji/WordEngineering/blob/main/SQLScript/2025-07-18T1124alter database Bible set read_only with rollback immediate.sql

--alter database Bible set read_write with rollback immediate;

SELECT 		'alter database ' + name + ' set read_only with rollback immediate ' SetDatabaseToRead_Only
FROM		master.sys.databases
WHERE		
			name not in ('IHaveDecidedToWorkOnAGradualImprovingSystem', 'URI', 'WordEngineering') 
AND			database_id > 7
ORDER BY name

/*
SetDatabaseToRead_Only
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
alter database Account set read_only with rollback immediate 
alter database AManDevelopedInAll set read_only with rollback immediate 
alter database AmericaWorkingFour set read_only with rollback immediate 
alter database ASPNetDB set read_only with rollback immediate 
alter database Bible set read_only with rollback immediate 
alter database BibleDictionary set read_only with rollback immediate 
alter database CodingSample set read_only with rollback immediate 
alter database ComparingYourWordAsYourDeed set read_only with rollback immediate 
alter database Confide set read_only with rollback immediate 
alter database dbtLabs_DataBuildTool set read_only with rollback immediate 
alter database DepositACode set read_only with rollback immediate 
alter database Dictionary set read_only with rollback immediate 
alter database ElectronicCopy set read_only with rollback immediate 
alter database Generative set read_only with rollback immediate 
alter database Gutenberg set read_only with rollback immediate 
alter database HomeAbroad set read_only with rollback immediate 
alter database InternetDictionaryProjectIDP set read_only with rollback immediate 
alter database IShallBeTheirInheritance set read_only with rollback immediate 
alter database IweKiko set read_only with rollback immediate 
alter database OMatePro set read_only with rollback immediate 
alter database RatingRank set read_only with rollback immediate 
alter database RobertRouseVizBible set read_only with rollback immediate 
alter database SoughtOut set read_only with rollback immediate 
alter database SQLSharp set read_only with rollback immediate 
alter database UnifiedModelingLanguage set read_only with rollback immediate 
alter database UserDb set read_only with rollback immediate 
alter database UsualPassage set read_only with rollback immediate 
alter database WhatWillInvolveLifeAsOurPart set read_only with rollback immediate 

(28 rows affected)


Completion time: 2025-07-18T11:54:23.5646758-07:00
*/