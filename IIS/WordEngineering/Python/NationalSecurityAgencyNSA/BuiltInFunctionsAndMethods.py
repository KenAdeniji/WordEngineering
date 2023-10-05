"""
	2023-02-20T11:14:00 Created. http://nsa.sfo2.digitaloceanspaces.com/comp3321.pdf
"""
help(print) #Shows interactive help.

class Person: #http://www.w3schools.com/python/ref_func_dir.asp
  name = "John"
  age = 36
  country = "Norway"

print("Directory of Person. All the methods available: ", dir(Person))

print("Type of 1: ", type(1))

print("isinstance(1, int): ", isinstance(1, int))

print("hasattr(Person, \"age\"): ", hasattr(Person, "age"))

print("getattr(Person, \"age\"): ", getattr(Person, "age"))

print("Identity of Person: ", id(Person))

print("str(1967-10-15): ", str(1967-10-15))

print("int(1967.1015): ", int(1967.1015))

print("float(1967.1015): ", float(1967.1015))

print("complex(1967,1015): ", complex(1967,1015))

print("abs(-1967.1015): ", abs(-1967.1015))

print("round(-1967.1015, 3): ", round(-1967.1015, 3))

print("max(19, 67, 10, 15): ", max(19, 67, 10, 15))

print("min(19, 67, 10, 15): ", min(19, 67, 10, 15))

print("pow(19, 6): ", pow(19, 6))

print("chr(1967): ", chr(1967))

print("divmod(1967, 105): ", divmod(1967, 1015))