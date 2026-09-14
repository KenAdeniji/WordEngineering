"""
    http://someplace-else.neocities.org/books/Python%20One-Liners%20-%20Write%20Concise,%20Eloquent%20Python%20Like%20a%20Professional.pdf
"""
#2026-09-13T19:41:00 Address bar: import this, can it be, in a script?
print("One-Liner", "import this")
import this

print("One-Liner", "print([i**2 for i in range(10)])")
print([i**2 for i in range(10)]) #2026-09-13T20:00:00 [0, 1, 4, 9, 16, 25, 36, 49, 64, 81]

#2026-09-13T20:34:00 Address bar: create date from year month day python
import datetime
print("One-Liner", "print(datetime.date(1967, 10, 15))")
print(datetime.date(1967, 10, 15))
print("One-Liner", "print(type(datetime.date(1967, 10, 15)))")
print(type(datetime.date(1967, 10, 15)))
