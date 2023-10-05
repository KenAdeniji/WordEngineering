"""
2022-08-05  Created. https://www.google.com/books/edition/Python_Crash_Course_2nd_Edition/w1v6DwAAQBAJ?hl=en&gbpv=1
2022-08-05  https://stackoverflow.com/questions/394809/does-python-have-a-ternary-conditional-operator/394814#394814
"""
if __name__ == '__main__':
	import sys
	name = sys.argv[1] if len(sys.argv) > 1 else "ada lovelace"
	cases = f"\
Title: {name.title()} \n\
Upper: {name.upper()} \n\
Lower: {name.lower()} \
	"
	print(cases)