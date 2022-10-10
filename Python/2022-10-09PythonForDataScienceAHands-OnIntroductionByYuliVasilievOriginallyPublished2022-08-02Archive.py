#!/usr/bin/python

# 	2022-10-09T20:49:00	Created. https://www.google.com/books/edition/Python_for_Data_Science/VqNgEAAAQBAJ?hl=en&gbpv=1&printsec=frontcover

# 	Gather our code in a main() function
def main():
	pentateuch_title_list = ["Genesis", "Exodus", "Leviticus", "Numbers", "Deuteronomy"]
	pentateuch_chapter_list = [50, 40, 27, 36, 34]
	pentateuch_tuple = [(title, chapter) for title, chapter in zip(pentateuch_title_list, pentateuch_chapter_list)]
	print(pentateuch_tuple)
		
# Standard boilerplate to call the main() function to begin
# the program.
if __name__ == '__main__':
    main()
	