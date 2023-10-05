#include <stdio.h>
int main(void)
{
//  Created: 2018-11-24.
//  gcc nameInteractive.c -o nameInteractive
    char name[80];
    printf("Please enter your name: ");
    scanf("%s", name);
    printf("Name is: %s\n", name);
    return(0);
}
