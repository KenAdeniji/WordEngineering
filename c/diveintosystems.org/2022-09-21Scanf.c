/*
    input (scanf) example
	https://diveintosystems.org/singlepage/#_getting_started_programming_in_c
	
%g:  placeholder for a float (or double) value
%d:  placeholder for a decimal value (int, short, char)
%s:  placeholder for a string value
%c:  placeholder for a character
%lf: placeholder for a double
*/

#include <stdio.h>

int main() {
    double num1, num2;

    printf("Enter a number: ");
    scanf("%lf", &num1);
    printf("Enter another: ");
    scanf("%lf", &num2);

    printf("%lf + %lf = %lf\n", num1, num2, (num1+num2));

    return 0;
}
