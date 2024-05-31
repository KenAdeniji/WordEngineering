USE [dbtLabs_DataBuildTool];
    
    

    EXEC('create view "KAA"."stg_orders" as with source as (
    select * from "dbtLabs_DataBuildTool"."KAA"."raw_orders"

),

renamed as (

    select
        id as order_id,
        user_id as customer_id,
        order_date,
        status

    from source

)

select * from renamed;');


