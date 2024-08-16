bible_books = [
	{
		"bookID": 1,
		"bookTitle": "Genesis",
		"chapters": 50,
		"author": "Moses",
		"bookGroup": "Pentateuch",
		"translation": "In the beginning"
	},
	{
		"bookID": 40,
		"bookTitle": "Matthew",
		"chapters": 28,
		"author": "Matthew",
		"bookGroup": "Gospel",
		"translation": None
	},
	{
		"bookID": 66,
		"bookTitle": "Revelation",
		"chapters": 22,
		"author": "Apostle John",
		"bookGroup": "Apocalyptic",
		"translation": None
	}
]

cols = bible_books[0].keys()
cols = sorted(cols)

with open("BibleBooks.csv", "w") as f:
	f.write(",".join(cols) + "\n")
	
	for o in bible_books:
		row = [str(o[col]) for col in cols]
		f.write(",".join(row) + "\n")
		
with open("BibleBooks.csv") as f:
	for line in f.readlines():
		print(line)
