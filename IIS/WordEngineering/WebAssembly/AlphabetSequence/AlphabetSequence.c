#include <stdio.h>
#include <emscripten.h> // note we added the emscripten header

int EMSCRIPTEN_KEEPALIVE alphabetSequence(char* word){
	int result = 0;
	
	for (int i = 0; word[i]!='\0'; i++) {
		if(word[i] >= 'a' && word[i] <= 'z') {
			word[i] = word[i] -32;	//Upper case
		}
		if(word[i] >= 'A' && word[i] <= 'Z') {
			result += word[i] - 64;
		}
	}	
	return result;
}

int main(){
    return 0;
}
