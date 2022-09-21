#include <ctype.h>
#include <stdio.h>

/*
	2022-09-21	Created.	DiveIntoSystems.org
	09:22 ... 09:43 prinft() versus printf()
e:\WordEngineering\c\WordEngineering>cl AlphabetSequence.c
Microsoft (R) C/C++ Optimizing Compiler Version 19.00.24231 for x86
Copyright (C) Microsoft Corporation.  All rights reserved.

AlphabetSequence.c
Microsoft (R) Incremental Linker Version 14.00.24231.0
Copyright (C) Microsoft Corporation.  All rights reserved.

/out:AlphabetSequence.exe
AlphabetSequence.obj
AlphabetSequence.obj : error LNK2019: unresolved external symbol _prinft referenced in function _alphabetSequence
AlphabetSequence.exe : fatal error LNK1120: 1 unresolved externals	
*/

void alphabetSequence(int, char *argv[]);

void main(int argc, char *argv[])
{
	alphabetSequence(argc, argv);
}

void alphabetSequence(int argc, char *argv[])
{
	unsigned long sum = 0;
	char concatenate[8000] = "";
	for 
	(
		int index = 1;
		index < argc;
		index++
	)
	{
		unsigned long alphabetSequenceIndex = 0;
		for 
		(
			int position = 0, length = strlen(argv[index]), currentLetter, location;
			position < length;
			position++
		)
		{
			location = 0;
			currentLetter = tolower(argv[index][position]);	
			if (islower(currentLetter))
			{
				location = currentLetter - 'a' + 1;
				alphabetSequenceIndex += location;
			}	
		}
		printf("%s %lu\n", argv[index], alphabetSequenceIndex);
		sum += alphabetSequenceIndex;
		strcat(concatenate, argv[index]); 
	}
	printf("%s %lu\n", concatenate, sum);
}
