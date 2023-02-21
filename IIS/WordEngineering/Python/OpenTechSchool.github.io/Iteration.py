#2019-10-23 http://opentechschool.github.io/python-beginners/en/simple_drawing.html
for name in "John", "Sam", "Jill":
    print("Hello " + name)

for i in range(10):
    print(i)

total = 0
for i in 5, 7, 11, 13:
    print(i)
    total = total + i

print(total)

for _ in range(10): #don't care to re-use the variable name.
    print("Hello!")
	