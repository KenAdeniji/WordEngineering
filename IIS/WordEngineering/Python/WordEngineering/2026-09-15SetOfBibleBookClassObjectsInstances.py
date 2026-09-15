"""
    2026-09-15  http://someplace-else.neocities.org/books/Python%20One-Liners%20-%20Write%20Concise,%20Eloquent%20Python%20Like%20a%20Professional.pdf
    2026-09-15  http://stackoverflow.com/questions/17493307/creating-set-of-objects-of-user-defined-class-in-python
        bibleBooks = set([BibleBook(1, "Genesis")])
        print(BibleBook(1, "Genesis") in bibleBooks)
"""
# Source - https://stackoverflow.com/a/17493442
# Posted by Martijn Pieters, modified by community. See post 'Timeline' for change history
# Retrieved 2026-09-15, License - CC BY-SA 3.0

BibleBooks = []

class BibleBook(object):
    def __init__(self, bookID, bookTitle):
        self.bookID = bookID
        self.bookTitle = bookTitle
        if (self not in BibleBooks): 
            BibleBooks.append(self)

    def __hash__(self):
        return hash((self.bookID, self.bookTitle))

    def __eq__(self, other):
        if not isinstance(other, type(self)): return NotImplemented
        return self.bookID == other.bookID and self.bookTitle == other.bookTitle
        
    def __del__(self):
        print("Delete an instance of the BibleBook class.")

    def __str__(self):
        return "BibleBook ID: {0} Title: {1}".format(self.bookID, self.bookTitle)

_Pentateuch = "The first five books of Moses."
    
Matthew = BibleBook(40, "Matthew")
Mark = BibleBook(41, "Mark")
Duplicate = BibleBook(40, "Matthew")

print(len(BibleBooks))
print(Matthew)
print(Mark)
print(Duplicate)