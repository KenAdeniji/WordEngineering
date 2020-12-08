#include <iostream>
#include <memory>

using namespace std;

class nonaddressable 
{
public:
    typedef double useless_type;
private:
    useless_type operator&() const;
};

/*
template <class T>
T * addressof(T & v)
{
  return reinterpret_cast<T *>(& const_cast<char&>(reinterpret_cast<const volatile char &>(v)));
}
*/

int main()
{
  nonaddressable na;
  nonaddressable * naptr = addressof(na); // No more compiler error.
  cout << naptr;
}
