USE [dbtLabs_DataBuildTool];
    
    

    EXEC('create view "KAA"."stg_customers" as with source as (
    select * from "dbtLabs_DataBuildTool"."KAA"."raw_customers"

),

renamed as (

    select
        id as customer_id,
        first_name,
        last_name

    from source

)

select * from renamed;');


