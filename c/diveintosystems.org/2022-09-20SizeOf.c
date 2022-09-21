/*
    The sizeof in C
	https://diveintosystems.org/singlepage/#_getting_started_programming_in_c
 */

/* I/O libraries */
#include <stdio.h>

/* main function definition: */
int main() {
    // statements end in a semicolon (;)
	printf("number of bytes in an int: %lu\n", sizeof(int)); //lu unsigned long
	printf("number of bytes in a short: %lu\n", sizeof(short));
    return 0;  // main returns value 0
}
