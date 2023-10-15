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

from bible_book import BibleBook

if __name__ == '__main__':
	list_bible_book = []
	list_bible_book.append(BibleBook(1, "Genesis", "Moses", 50))
	list_bible_book.append(BibleBook(2, "Exodus", "Moses", 40))
	list_bible_book.append(BibleBook(3, "Leviticus", "Moses", 27))
	
	json_string = json.dumps([ob.__dict__ for ob in list_bible_book])
	path_JSON_file = Path("BibleBook.json");
	with open(path_JSON_file, "w") as file:
	    file.write(json_string)

	index = 0
	length = len(list_bible_book)
	html_string = "<table><thead><tr><th>ID</th><th>Title</th><th>Author</th><th>Chapters</th></tr></thead><tbody>";
	while index < length:
		html_string += f"<tr><td>{list_bible_book[index].id}</td><td>{list_bible_book[index].title}</td><td>{list_bible_book[index].author}</td><td>{list_bible_book[index].chapters}</td></tr>"
		index += 1
	html_string += "</tbody></table>"	
	path_HTML_file = Path("BibleBook.html");
	with open(path_HTML_file, "w") as file:
	    file.write(html_string)


