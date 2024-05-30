USE [WordEngineering];
    
    

    EXEC('create view "dbo"."dbtLabs_DataBuildTool_HisWord_20240528" as select * from HisWord

-- if the table already exists and `--full-refresh` is
-- not set, then only add new records. otherwise, select
-- all records.
;');


