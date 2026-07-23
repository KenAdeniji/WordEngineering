"""
    2026-07-22T20:25:00
    http://jakevdp.github.io/PythonDataScienceHandbook/02.09-structured-data-numpy.html
    Numbers 26:4                Take the sum of the people, from twenty years old and upward; as the Lord commanded Moses and the children of Israel, which went forth out of the land of Egypt.
    Numbers 4:30, Luke 3:23     From thirty years old and upward even unto fifty years old shalt thou number them, every one that entereth into the service, to do the work of the tabernacle of the congregation.
    pip install numpy
"""
import numpy as np

bookID = [1, 27, 43, 66]
bookTitle = ["Genesis", "Daniel", "John", "Revelation"]
bookAuthor = ["Moses", "Daniel", "John", "John"]
bookGroup = ["Pentateuch", "Major Prophet, Apocalyptic", "Gospel", "Apocalyptic"]
bookChapters = [50, 12, 21, 22]

# Use a compound data type for structured arrays
bibleBooks = np.zeros(4, dtype={"names":("bookID", "bookTitle", "bookAuthor", "bookGroup", "bookChapters"),
                          "formats":("i4", "U20", "U20", "U50", "i4")})

# Now that we've created an empty container array, we can fill the array with our lists of values:
bibleBooks["bookID"] = bookID
bibleBooks["bookTitle"] = bookTitle
bibleBooks["bookAuthor"] = bookAuthor
bibleBooks["bookGroup"] = bookGroup
bibleBooks["bookChapters"] = bookChapters

print("Gospel:", bibleBooks[bibleBooks["bookGroup"] == "Gospel"]["bookTitle"])