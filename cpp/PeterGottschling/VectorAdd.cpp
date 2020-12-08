// compile with: /GR /EHsc
/*
	2016-01-06	Created.	http://ptgmedia.pearsoncmg.com/images/9780134383583/samplepages/9780134383583.pdf
*/

#include <cassert>
#include <iostream>
#include <vector>

using namespace std;

vector<float> add
(
	const vector<float>& v1, 
	const vector<float>& v2
)	
{
	assert(v1.size() == v2.size());
	vector<float> result(v1.size());
	for (unsigned i = 0; i < v1.size(); ++i)
	{	
		result[i] = v1[i] + v2[i];
		cout << "[" << i << "]: " << v1[i] << " + " 
			<< v2[i] << " = " << result[i] << endl;
	}	
	return (result);
}

int main(int argc, char* argv[])
{
	std::vector<float> 
		v = {1, 2, 3},
		w = {7, 8, 9},
		result = add(v, w);
	return 0;	
}
