"""
2026-08-31  http://learn.microsoft.com/en-us/sql/connect/python/mssql-python/python-sql-driver-mssql-python-quickstart?view=sql-server-ver17&tabs=sql-server%2Cwindows
pip mssql-python
"""
from os import getenv
from mssql_python import connect
        
if __name__ == '__main__':
    SQL_CONNECTION_STRING="Server=localhost;Database=master;Trusted_Connection=yes;TrustServerCertificate=yes;"
    SQL_QUERY = """
    SELECT
    TOP 5 object_id,
    name
    FROM
    master.sys.objects
    ORDER BY
    object_id
    """
    conn = connect(SQL_CONNECTION_STRING)
    cursor = conn.cursor()
    cursor.execute(SQL_QUERY)
    records = cursor.fetchall()
    for r in records:
        print(f"{r.object_id}\t{r.name}")
      