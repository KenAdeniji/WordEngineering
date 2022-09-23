#include <stdio.h>
#include <stdlib.h>
#include <string.h>

/*
	2022-09-22	Created.	DiveIntoSystems.org
	2022-09-22	KHouse.org 66/40
	C provides several libraries with functions for manipulating strings and characters.
	The string library (string.h) is particularly useful when writing programs that use C strings.
	The stdlib.h and stdio.h libraries also contain functions for string manipulation, and the ctype.h library contains functions for manipulating individual character values.	
*/

void stub(int, char *argv[]);

void main(int argc, char *argv[])
{
	stub(argc, argv);
}

void stub(int argc, char *argv[])
{
	int *ptrBibleBooksCount, *ptrBibleAuthorsCount, bibleBooksCount, bibleAuthorsCount;

	bibleBooksCount = 66;
	ptrBibleBooksCount = &bibleBooksCount;	// ptrBibleBooksCount is assigned the address of bibleBooksCount
	//ptrBibleBooksCount = NULL;
	
	ptrBibleAuthorsCount = &bibleAuthorsCount;
	*ptrBibleAuthorsCount = 10;
	
	printf
	(
		"Bible books count: %d authors count: %d\n",
		bibleBooksCount,
		bibleAuthorsCount
	);
	
    char *torah;

    torah = malloc(sizeof(char) * 6);  // allocate heap memory for storing the Bible book name in Hebrew

	if (torah == NULL) {
		printf("Bad malloc error\n");
		exit(1);   // exit the program and indicate error
	}

    strcpy(torah, "Torah");   // the heap memory torah points to gets the value Torah
	
	printf
	(
		"Bible in Hebrew: %s\n",
		torah
	);
	
	free(torah);
	torah = NULL;	
}
