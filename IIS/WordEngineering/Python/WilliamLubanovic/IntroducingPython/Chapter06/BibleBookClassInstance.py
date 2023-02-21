class BibleBook():
    # Initializer / Instance Attributes
    def __init__(self, bookID, bookTitle):
        self.bookID = bookID
        self.bookTitle = bookTitle

    def __str__(self): #2019-06-11  https://www.brianheinold.net/python/A_Practical_Introduction_to_Python_Programming_Heinold.pdf
        return "Book ID: {} Title: {} Author: {}".format(self.bookID, self.bookTitle, self.author())

    # instance method		
    def author(self):
        author = "Unknown"
        if self.bookID <= 5:
            author = "Moses"
        return author
    
if __name__ == '__main__':
	genesis = BibleBook(1, "Genesis")
	print(genesis)
