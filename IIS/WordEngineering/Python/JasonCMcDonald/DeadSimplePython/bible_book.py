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

class BibleBook:
	def __init__(self, id, title, author, chapters):
		self.id = id
		self.title = title
		self.author = author
		self.chapters = chapters

	def __del__(self):
		print("Delete an instance of the Bible Book class.")

	def __str__(self):
		return "BibleBook ID: {}".format(self.id)	

	_Pentateuch = "The first five books of Moses."		

