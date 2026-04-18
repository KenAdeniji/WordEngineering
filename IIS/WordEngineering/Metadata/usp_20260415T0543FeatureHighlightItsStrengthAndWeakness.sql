CREATE OR ALTER PROCEDURE usp_20260415T0543FeatureHighlightItsStrengthAndWeakness
AS
BEGIN
	SET NOCOUNT ON
/*
http://en.wikipedia.org/wiki/Encarta
Developer	Microsoft
Final release	
2009 / August 23, 2008; 17 years ago
Operating system	Microsoft Windows, MacOS Classic
Available in	English, German, French, Spanish, Portuguese, Italian, Dutch, Japanese
Type	Encyclopedia
License	Proprietary commercial software
Website	Formerly encarta.msn.com at the Wayback Machine (archived October 31, 2009)
*/
/*
    2026-04-18T04:07:00 http://stackoverflow.com/questions/887370/sql-server-extract-table-meta-data-description-fields-and-their-data-types    
*/
/*
    SELECT
        TableName = tbl.table_schema + '.' + tbl.table_name, 
        TableDescription = tableProp.value,
        ColumnName = col.column_name, 
        ColumnDataType = col.data_type,
        ColumnDescription = colDesc.ColumnDescription
    FROM information_schema.tables tbl
    INNER JOIN information_schema.columns col 
        ON col.table_name = tbl.table_name
    LEFT JOIN sys.extended_properties tableProp 
        ON tableProp.major_id = object_id(tbl.table_schema + '.' + tbl.table_name) 
            AND tableProp.minor_id = 0
            AND tableProp.name = 'MS_Description' 
    LEFT JOIN (
        SELECT sc.object_id, sc.column_id, sc.name, colProp.[value] AS ColumnDescription
        FROM sys.columns sc
        INNER JOIN sys.extended_properties colProp
            ON colProp.major_id = sc.object_id
                AND colProp.minor_id = sc.column_id
                AND colProp.name = 'MS_Description' 
    ) colDesc
        ON colDesc.object_id = object_id(tbl.table_schema + '.' + tbl.table_name)
            AND colDesc.name = col.COLUMN_NAME
    WHERE tbl.table_type = 'base table'
        AND tableProp.[value] IS NOT NULL AND colDesc.ColumnDescription IS NOT NULL
    ORDER BY
        TableName,
        ColumnName
*/

/*
    2026-04-18T04:59:00 http://stackoverflow.com/questions/15221338/how-to-get-a-list-of-all-extended-properties-for-all-objects
    2026-04-18T05:36:00 sys.all_objects versus (VS) sys.objects
*/
    SELECT
        schemas.name                SchemaName,
        objects.name                ObjectName,
        columns.name                ColumnName,
        extended_properties.name    ExtendedPropertyName, 
        extended_properties.value   ExtendedPropertyValue
    FROM 
        sys.extended_properties
        LEFT JOIN sys.objects ON extended_properties.major_id = objects.object_id 
        LEFT JOIN sys.schemas on objects.schema_id = schemas.schema_id
        LEFT OUTER JOIN sys.columns ON extended_properties.major_id = columns.object_id AND extended_properties.minor_id = columns.column_id
    ORDER BY
        schemas.name,
        objects.name,
        columns.name,
        extended_properties.name, 
        extended_properties.value

END
GO
