"""
	Date created: 2024-09-02T15:25:00
	http://www.bpesquet.fr/ainotes/foundations/programming.html
"""
numbers = {"one": 1, "two": 2, "three": 3}

numbers["ninety"] = 90
print(numbers)

for key, value in numbers.items():
    print(f"{key} => {value}")
	