// compile with: /GR /EHsc
/*
	2015-08-09	Created.	http://www.cplusplus.com/doc/tutorial/functions/
*/

#include <iostream>

using namespace std;

void referenceParameter(int& a, int& b, int& c)
{
  a*=2;
  b*=2;
  c*=2;
}

int main ()
{
  int x=1, y=3, z=7;
  referenceParameter(x, y, z);
  cout << "x=" << x << ", y=" << y << ", z=" << z;
  return 0;
}
