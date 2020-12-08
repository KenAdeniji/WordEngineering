// compile with: /GR /EHsc
/*
	2015-08-09	Created.	http://www.cplusplus.com/doc/tutorial/functions/
*/

#include <iostream>

using namespace std;

int defaultParameter(int a, int b=2)
{
  int r;
  r=a/b;
  return (r);
}

int main ()
{
  cout << defaultParameter(12) << '\n';
  cout << defaultParameter(20,4) << '\n';
  return 0;
}
