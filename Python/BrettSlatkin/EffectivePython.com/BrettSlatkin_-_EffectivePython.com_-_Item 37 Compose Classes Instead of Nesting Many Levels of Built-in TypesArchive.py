"""
	2021-12-28T12:47:00 Created. http://www.informit.com/articles/article.aspx?p=2992597
"""
class SimpleBookScriptureReference:
	def __init__(self):
		self._scriptureReferences = {}
		
	def add_book(self, book):
		self._scriptureReferences[book] = []
	
	def report_scriptureReference(self, book, scriptureReference):
		self._scriptureReferences[book].append(scriptureReference)
		
	def count_scriptureReference(self, book):
		scriptureReferences = self._scriptureReferences[book]
		return len(scriptureReferences)

book = SimpleBookScriptureReference()
book.add_book("Genesis")
book.report_scriptureReference("Genesis", "Genesis 1")
book.report_scriptureReference("Genesis", "Genesis 22")
book.report_scriptureReference("Genesis", "Genesis 41")
print(book.count_scriptureReference("Genesis"))
book.add_book("John")
book.report_scriptureReference("John", "John 1")
book.report_scriptureReference("John", "John 17")
print(book.count_scriptureReference("John"))
book.add_book("Hebrews")
book.report_scriptureReference("Hebrews", "Hebrews 11")
print(book.count_scriptureReference("Hebrews"))
