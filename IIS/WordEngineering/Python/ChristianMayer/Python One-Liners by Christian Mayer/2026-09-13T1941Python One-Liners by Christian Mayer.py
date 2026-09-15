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

print("One-Liner", "Python string", "http://docs.python.org/3/library/string.html#module-string")
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
print("tab character\t Hello \s world newline\n".strip())
print("lower", "tab character\t Hello \s world newline\n".lower())
print("upper", "tab character\t Hello \s world newline\n".upper())
import string
print("string.ascii_letters", string.ascii_letters)
print("string.ascii_lowercase", string.ascii_lowercase)
print("string.ascii_uppercase", string.ascii_uppercase)
print("string.digits", string.digits)
print("string.hexdigits", string.hexdigits)
print("string.octdigits", string.octdigits)
print("string.punctuation", string.punctuation)
print("string.printable", string.printable)
print("string.whitespace", string.whitespace)

print("One-Liner", "print(string.capwords('cap words'))")
print(string.capwords('cap words'))

print("One-Liner", "print('The keyword None is a Python constant and it means the absence of a value. Other programming languages such as Java use the value null instead. However, the term null often confuses beginners, who assume it’s equal to the integer value 0. Instead, Python uses the keyword None, as shown as Listing 1-6, to indicate that it’s different from any numerical value for zero, an empty list, or an empty string. An interesting fact is that the value None is the only value in the NoneType data type.'")

#2026-09-14T18:29:00 http://stackoverflow.com/questions/930397/how-do-i-get-the-last-element-of-a-list
print("Passover days?", [10, 14, 15], "Length of list?", len([10, 14, 15]), "First element in the list?", [10, 14, 15][0], "Last element in the list?", [10, 14, 15][-1])
