#2022-01-06T15:13:00
"""
	http://index-of.es/Varios-2/Doing%20Math%20with%20Python.pdf
	python ListTupleBibleBook.py
	http://127.0.0.1:5000
"""

from flask import Flask
from flask import request

#from pylab import plot, show
import matplotlib.pyplot as plt
import numpy as np

app = Flask(__name__)

@app.route("/")
def listTupleBibleBook():
	stub()
	return("")
		
def stub():
	bibleBooksTitlesList = ["Genesis", "Exodus", "Leviticus"]	
	bibleBooksChaptersList = [50, 40]
	bibleBooksChaptersList.append(27)	
	for item in bibleBooksTitlesList:
		print(item)
	for index, item in enumerate(bibleBooksTitlesList):	
		print(index, item)
	#plt(bibleBooksTitlesList, bibleBooksChaptersList)
	plt.plot(bibleBooksTitlesList, bibleBooksChaptersList, label="Books and Chapters")
	plt.xlabel("Books")
	plt.ylabel("Chapters")
	#plt.title("Books and Chapters")
	plt.legend()
	plt.show()
	
if __name__ == "__main__":
    app.run()
