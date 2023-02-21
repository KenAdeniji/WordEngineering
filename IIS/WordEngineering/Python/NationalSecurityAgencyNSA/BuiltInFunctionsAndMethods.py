"""
	2023-02-20T11:14:00 Created. http://nsa.sfo2.digitaloceanspaces.com/comp3321.pdf
"""
help(print) #Shows interactive help.

class Person: #http://www.w3schools.com/python/ref_func_dir.asp
  name = "John"
  age = 36
  country = "Norway"

print(dir(Person))

print(type(1))

print(isinstance(1, int))

print(hasattr(Person, "age"))