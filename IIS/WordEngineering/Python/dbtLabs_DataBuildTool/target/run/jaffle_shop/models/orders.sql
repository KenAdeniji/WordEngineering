
  
    

   

    USE [dbtLabs_DataBuildTool];
    
    

    EXEC('create view "KAA"."orders_temp_view" as 

with orders as (

    select * from "dbtLabs_DataBuildTool"."KAA"."stg_orders"

),

payments as (

    select * from "dbtLabs_DataBuildTool"."KAA"."stg_payments"

),

order_payments as (

    select
        order_id,

        sum(case when payment_method = ''credit_card'' then amount else 0 end) as credit_card_amount,
        sum(case when payment_method = ''coupon'' then amount else 0 end) as coupon_amount,
        sum(case when payment_method = ''bank_transfer'' then amount else 0 end) as bank_transfer_amount,
        sum(case when payment_method = ''gift_card'' then amount else 0 end) as gift_card_amount,
        sum(amount) as total_amount

    from payments

    group by order_id

),

final as (

    select
        orders.order_id,
        orders.customer_id,
        orders.order_date,
        orders.status,

        order_payments.credit_card_amount,

        order_payments.coupon_amount,

        order_payments.bank_transfer_amount,

        order_payments.gift_card_amount,

        order_payments.total_amount as amount

    from orders


    left join order_payments
        on orders.order_id = order_payments.order_id

)

select * from final;');



    
      EXEC('SELECT * INTO [dbtLabs_DataBuildTool].[KAA].[orders] FROM [dbtLabs_DataBuildTool].[KAA].[orders_temp_view];');
    

    
      
      
    
    USE [dbtLabs_DataBuildTool];
    EXEC('DROP view IF EXISTS "KAA"."orders_temp_view";');



  