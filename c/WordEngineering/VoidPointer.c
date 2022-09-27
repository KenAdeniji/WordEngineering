#include <stdio.h>
#include <stdlib.h>
#include <string.h>

/*
	2022-09-22	Created.	DiveIntoSystems.org
*/

void stub(int, char *argv[]);

void main(int argc, char *argv[])
{
	stub(argc, argv);
}

void stub(int argc, char *argv[])
{
	void *gen_ptr;	//Generic type

	gen_ptr = &argc;  // gen_ptr can be assigned the address of an int
	printf("Arguments count: %d", (int*)gen_ptr );
	
	gen_ptr = &argv[0]; // or the address of a char (or the address of any type)
}
