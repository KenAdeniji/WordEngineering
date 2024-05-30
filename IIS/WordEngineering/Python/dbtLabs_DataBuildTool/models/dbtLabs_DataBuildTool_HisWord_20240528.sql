select * from HisWord

-- if the table already exists and `--full-refresh` is
-- not set, then only add new records. otherwise, select
-- all records.
{% if is_incremental() %}
   where Dated > (
     select coalesce(max(Dated), '2024-05-28') from {{ this }}
   )
{% endif %}
