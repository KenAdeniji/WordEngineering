import csv
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

with open("BibleBook.csv", "w") as f:
	fieldnames = bible_books[0].keys()
	fieldnames = sorted(fieldnames)
	writer = csv.DictWriter(f, fieldnames=fieldnames)
	writer.writeheader()
	for w in bible_books()
		writer.writerow(w)
		
	