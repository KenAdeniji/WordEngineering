// compile with: /GR /EHsc
/*
	2015-03-06	Created. http://stroustrup.com/Programming
*/

#include <fstream>
#include <iostream>
#include <string>

using namespace std;

int main () {
  std::ifstream ifs;

  ifs.open ("test.txt", std::ifstream::in);

  char c = ifs.get();

  while (ifs.good()) {
    std::cout << c;
    c = ifs.get();
  }

  ifs.close();

  return 0;
}
