use telcoInventory
go

drop procedure dbo.usp_GetReportParameters
go

create procedure dbo.usp_GetReportParameters(@strObjectName sysname)
as

    --declare @strObjectName sysname
    
    --set @strObjectName = 'report_ListAllCircuitLocations'
    --set @strObjectName = 'report_ListAllCircuitLocationsFilteredOnLocation'
    --set @strObjectName = 'report_ListAllCircuitLocationsFilteredOnCircuitStatus'
    
    --select object_id(@strObjectName)
    
    select   SC.name   columnName 
           , ST.name   dataType   
           , tblReportParam.paramNameLiteral parameterNameLiteral
           , tblReportParam.paramSQL  paramSQL
           , isNull(tblReportParam.paramIsSystem, 0)  paramIsSystem
    from   dbo.syscolumns SC 
    	    join   dbo.systypes ST 
    			 on     SC.xusertype = ST.xusertype
    		left outer join dbo.reportParam tblReportParam
    			on     SC.name = tblReportParam.paramName  COLLATE Latin1_General_CI_AI
    where  SC.id = object_id(@strObjectName)
go

grant execute on [dbo].[usp_GetReportParameters] to telcoWebUser
go