'''
2026-07-08T20:32:00
http://github.com/mkleehammer/pyodbc
2019-03-05 
http://stackoverflow.com/questions/33725862/connecting-to-microsoft-sql-server-using-python 
2019-03-05 
pip install pyodbc
'''
def sqlSelect(): 
    cnxn = pyodbc.connect("DRIVER={ODBC Driver 17 for SQL Server};SERVER=(local);DATABASE=Bible;Trusted_Connection=yes;");
    cursor = cnxn.cursor()
    cursor.execute("SELECT * FROM master.sys.databases")
    for row in cursor:
        print("row = %r" % (row,)) 	 
        
if __name__ == '__main__':
    import pyodbc
    sqlSelect()