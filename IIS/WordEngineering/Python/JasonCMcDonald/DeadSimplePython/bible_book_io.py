"""
2023-10-13T19:47:00...2023-10-13T20:47:00 Created.
	http://github.com/CodeMouse92/DeadSimplePython/blob/main/Ch11/write_house_json.py
2023-10-13T21:29:00	It separates the serialization from the file write.
	json_string = json.dumps([ob.__dict__ for ob in list_bible_book])
	path_JSON_file = Path("BibleBook.json");
	2023-10-13T06:11:00...2023-10-13T07:36:00 google.com +python object list html table site:stackoverflow.com 
	2023-10-13T07:36:00 Urine
	2023-10-13T07:36:00...2023-10-13T07:56:00 html table while iteration.	
"""
import sys
from pathlib import Path
import json

class Bible_Book():
    # Initializer / Instance Attributes
    def __init__(self, ID, Title):
        self.ID = ID
        self.Title = Title

    def __str__(self): #2019-06-11  https://www.brianheinold.net/python/A_Practical_Introduction_to_Python_Programming_Heinold.pdf
        return "Bible_Book ID: {} Title: {}".format(self.ID, self.Title())
		
if __name__ == '__main__':
	list_bible_book = []
	list_bible_book.append(Bible_Book(1, "Genesis"))
	list_bible_book.append(Bible_Book(2, "Exodus"))
	
	json_string = json.dumps([ob.__dict__ for ob in list_bible_book])
	path_JSON_file = Path("BibleBook.json");
	with open(path_JSON_file, "w") as file:
	    file.write(json_string)

	index = 0
	length = len(list_bible_book)
	html_string = "<table><thead><tr><th>ID</th><th>Title</th></tr></thead><tbody>";
	while index < length:
		html_string += f"<tr><td>{list_bible_book[index].ID}</td><td>{list_bible_book[index].Title}</td></tr>"
		index += 1
	html_string += "</tbody></table>"	
	path_HTML_file = Path("BibleBook.html");
	with open(path_HTML_file, "w") as file:
	    file.write(html_string)


