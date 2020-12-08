#include <cassert>
#include <iostream>
#include <vector>

using namespace std;

/*
	vcvars32.bat
	cl "HowMyLifeWillBeSpentLivingSomeoneElse.cpp"
*/

int main(){
	vector<int> V;	//Defined in the standard header vector, and in the nonstandard backward-compatibility header vector.h.
	V.insert(V.begin(), 3);
	assert(V.size() == 1 && V.capacity() >= 1 && V[0] == 3);	
}
