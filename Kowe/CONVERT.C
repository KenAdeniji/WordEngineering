#include <stdio.h>
#include <string.h>

FILE *source_file, *target_file;
unsigned char storage[45];
char files[4][10] = { "Trans1", "Trans2", "Trans3", "Trans4" };
int counter, l, k;

main()
{
   target_file = fopen("Dico", "w");
   for (counter = 0; counter < 4; ++ counter)
   {  source_file = fopen(files[counter], "r");
      while (!feof(source_file))
      {
	 fgets(storage, 45, source_file);
	 l = strlen(storage) - 1;
	 for (k = 0; k <  l; ++k) fprintf(target_file,"%c", storage[k]);
	 for (     ; k < 40; ++k) fprintf(target_file,"%c", 32);
      }
      fclose(source_file);
   }
fclose(target_file);
}



