#2019-03-05	pip install pyodbc
"""
	http://127.0.0.1:5000
	http://127.0.0.1:5000/bibleBooks
	http://127.0.0.1:5000/bibleBook/John
"""
from flask import Flask
import pyodbc
app = Flask(__name__)

@app.route("/")
def hello():
    return "Hello World!"

@app.route('/bibleBooks')
def bibleBooks():
    queryStatement = "SELECT DISTINCT BookID, BookTitle FROM Scripture ORDER BY BookID"
    return sqlSelect(queryStatement)

@app.route('/bibleBook/<bookTitle>')
def bibleBook(bookTitle):
    queryStatement = "SELECT DISTINCT BookID, BookTitle FROM Scripture WHERE BookTitle LIKE '%" + bookTitle + "%' ORDER BY BookID"
    return sqlSelect(queryStatement)

def sqlSelect(selectQuery):
    cnxn = pyodbc.connect("Driver={SQL Server Native Client 11.0};"
                          "Server=(local);"
                          "Database=Bible;"
                          "Trusted_Connection=yes;")
    cursor = cnxn.cursor()
    cursor.execute(selectQuery)
    result_set = cursor.fetchall()
    
    infoSet = "<table border='1'>"

    for row in result_set:
        infoSet += "<tr><td>" + str(row[0]) + "</td><td>" + row[1] + "</td></tr>"

    infoSet += "</table>"
    
    return infoSet    
		
	
