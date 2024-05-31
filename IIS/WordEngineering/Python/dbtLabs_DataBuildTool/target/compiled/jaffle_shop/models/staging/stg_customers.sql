with source as (
    select * from "dbtLabs_DataBuildTool"."KAA"."raw_customers"

),

renamed as (

    select
        id as customer_id,
        first_name,
        last_name

    from source

)

select * from renamed