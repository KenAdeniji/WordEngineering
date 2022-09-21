/*
    The printf in C
	https://diveintosystems.org/singlepage/#_getting_started_programming_in_c
	
%g:  placeholder for a float (or double) value
%d:  placeholder for a decimal value (int, short, char)
%s:  placeholder for a string value
%c:  placeholder for a character	
*/

/* C printf example */
#include <stdio.h> // needed for printf

int main() {

    printf("Name: %s,  Info:\n", "Vijay"); //
    printf("\tAge: %d \t Ht: %g\n",20,5.9);
    printf("\tYear: %d \t Dorm: %s\n",
            3,"Alice Paul");

	// Example printing a char value as its decimal representation (%d)
	// and as the ASCII character that its value encodes (%c)

	char ch;

	ch = 'A';
	printf("ch value is %d which is the ASCII value of  %c\n", ch, ch);

	ch = 99;
	printf("ch value is %d which is the ASCII value of  %c\n", ch, ch);
    return 0;
}
