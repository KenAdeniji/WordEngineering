#2019-03-05	https://stackoverflow.com/questions/33725862/connecting-to-microsoft-sql-server-using-python
#2019-03-05	pip install pyodbc
#2019-03-05	https://realpython.com/python3-object-oriented-programming/

def sqlSelect():
	cnxn = pyodbc.connect("Driver={SQL Server Native Client 11.0};"
						  "Server=(local);"
						  "Database=Bible;"
						  "Trusted_Connection=yes;")
	cursor = cnxn.cursor()
	cursor.execute('SELECT DISTINCT BookID, BookTitle FROM Scripture ORDER BY BookID')

	for row in cursor:
		print('row = %r' % (row,))

class BibleBook():
	#pass
    # Class Attribute
	# author = 'Old'
	
    # Initializer / Instance Attributes
    def __init__(self, bookID, bookTitle, bookGroup):
        self.bookID = bookID
        self.bookTitle = bookTitle
        self.bookGroup = bookGroup
		
    # instance method
    def toString(self):
        return "Book ID: {} Title: {}".format(self.bookID, self.bookTitle)
		
if __name__ == '__main__':
	import pyodbc 
	sqlSelect()
	# Instantiate the BibleBook object
	genesis = BibleBook(1, 'Genesis', 'Pentateuch')
	print( genesis.toString() );
	