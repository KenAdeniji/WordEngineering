"""
    2020-02-16 Created. john.zelle@wartburg.edu; Postal address: Department of Math/CS/Physics Wartburg College 100 Wartburg Blvd. Waverly, IA 50677
	http://127.0.0.1:5000
	http://127.0.0.1:5000/bibleBooks
	http://127.0.0.1:5000/bibleBook/John
	https://www.pythonforbeginners.com/dictionary/how-to-use-dictionaries-in-python
	https://stackoverflow.com/questions/3294889/iterating-over-dictionaries-using-for-loops
	
	line = infile.readline()
	while line != "":
		columns = line.split(",")
		line = infile.readline()	
	2020-02-17
	https://stackoverflow.com/questions/6579876/how-to-match-a-substring-in-a-string-ignoring-case
"""
from flask import Flask
app = Flask(__name__)

import re

@app.route("/")
def hello():
    return "Hello World!"

@app.route('/bibleBooks')
def bibleBooks():
    return query()

@app.route('/bibleBook/<bookTitle>')
def bibleBook(bookTitle):
    return query(bookTitle)

def readFile():
	infile = open("BibleBook.txt", "r")
	for line in infile.readlines():
		columns = line.split(",")
		bookID = columns[0]
		bookTitle = columns[1]
		chapters = columns[2]
		bibleBooks[bookTitle] = chapters
		
def query(bookTitle = ""):
    infoSet = 	"<table border='1'><caption>Bible Books</caption><thead><tr><th>ID</th><th>Title</th><th>Chapters</th></tr></thead><tbody>"
    bookID = 0
    for the_key, the_value in bibleBooks.items():
        bookID += 1
        if (re.search(bookTitle, the_key, re.IGNORECASE)):
            infoSet += "<tr><td>" + str(bookID) + "</td><td>" + the_key + "</td><td>" + the_value + "</td></tr>"
    infoSet += "</tbody></table>"
    return infoSet

bibleBooks = {}
readFile()
