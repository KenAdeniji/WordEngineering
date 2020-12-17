# 2019-11-14 https://stackoverflow.com/questions/48968054/joining-integer-list
dictionaryPentateuch={
	1: "Genesis",
	2: "Exodus",
	3: "Leviticus",
	4: "Numbers",
	5: "Deuteronomy"
	}
print("0 a key, book ID:", 0 in dictionaryPentateuch)
print("For key =-1, what is the value:", dictionaryPentateuch.get(-1))
print("For key =-1, what is the value:", dictionaryPentateuch.get(-1, "Optional value"))
print(", ".join(map(str, list(dictionaryPentateuch.keys()))))
print(", ".join(list(dictionaryPentateuch.values())))
print(', '.join(['{}_{}'.format(k,v) for k,v in dictionaryPentateuch.items()]))
