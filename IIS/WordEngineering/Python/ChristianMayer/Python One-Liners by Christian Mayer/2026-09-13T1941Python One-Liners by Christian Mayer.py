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

print("One-Liner", "print(22.0/7.0)")
print("π=pi", 22.0/7.0)
print("One-Liner", "print(type(22.0/7.0))")
print(type(22.0/7.0))

print("One-Liner", "print('// operator performs integer division. The result is an integer value that is rounded down (for example, 3 // 2 == 1).)'")
print(3 // 2 == 1)

print("One-Liner", "print('A variable of type Boolean can take only two values—either False or True. In Python, Boolean and integer data types are closely related: the Boolean data type internally uses integer values (by default, the Boolean value False is represented by integer 0, and the Boolean value True is represented by integer 1).'")
print(1 > 2) #False
print(2 > 1) #True

print("One-Liner", "Python string")
print("'Single quotes'")
print('"Double quotes"')
print("""
Triple
quotes
for
multiline
strings
""") 
print("One-Liner", "print(str(22.0/7.0))")
print(str(22 / 7))
print("One-Liner", "print(whitespace characters in strings)")
print("tab character\t Hello \s world newline\n")
