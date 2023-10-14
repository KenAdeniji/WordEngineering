"""
2023-10-13T19:47:00...2023-10-13T20:47:00 Created.
	http://github.com/CodeMouse92/DeadSimplePython/blob/main/Ch11/write_house_json.py
2023-10-13T21:29:00	It separates the serialization from the file write.
	json_string = json.dumps([ob.__dict__ for ob in list_bible_book])
	path_JSON_file = Path("BibleBook.json");
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
		