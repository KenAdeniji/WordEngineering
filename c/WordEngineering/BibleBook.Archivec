#include <ctype.h>
#include <stdio.h>
#include <string.h>

/*
	2022-09-21	Created.	DiveIntoSystems.org
	2022-09-21T18:28:00	https://stackoverflow.com/questions/18921559/initializing-array-of-structures
*/

struct bibleBookT {
    char bookAuthor[20];
    int bookID;
	char bookGroup[20];
	char bookTitle[20];
    int oldTestament; //Old Testament non-zero. Boolean flag.
}
bibleBooks[66] =
	{
		[0].bookID = 1, [0].bookAuthor = "Moses", [0].bookTitle = "Genesis"
	};	
;

void stub(int, char *argv[]);

void main(int argc, char *argv[])
{
	stub(argc, argv);
}

void stub(int argc, char *argv[])
{
	printf
	(
		"ID: %d title: %s\n",
		bibleBooks[0].bookID,
		bibleBooks[0].bookTitle
	);
	
	/* Print the size of the struct bibleBookT type. */
    printf("number of bytes in bibleBook struct: %lu\n", sizeof(struct bibleBookT));
}
