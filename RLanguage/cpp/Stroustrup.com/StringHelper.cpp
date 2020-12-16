// compile with: /GR /EHsc
/*
	2015-03-04	Created. http://stroustrup.com/Programming
	2015-03-04	http://www.informit.com/articles/article.aspx?p=2216986&seqNum=7
	2015-03-04	http://www.cplusplus.com/doc/tutorial/namespaces/
*/

#include <iostream>
#include <string>

using namespace std;

namespace WordEngineering
{
	class StringHelper 
	{
		public:
			bool is_palindrome(const string& s)
			{
				  int first = 0;                        // index of first letter
				  int last = s.length()-1;	//index of last letter
				  while (first < last) {             // we haven’t reached the middle
						if (s[first]!=s[last]) return false;
						++first;                      // move forward
						--last;	//move backward
				  }
				  return true;
			}
		
			bool is_palindrome(const char * first, const char * last)
			{
				if ( first < last ) 
				{
					if (*first != *last)
					{
						return false;
					}
					return is_palindrome(first + 1, last - 1);
				}
				return true;
			}
	
			void stub()
			{
				for (string s; cin>>s; ) {
					cout << s << " is";
					if (!stringHelper.is_palindrome(s)) cout << " not";
						cout << " a palindrome\n";
				}
			}
	} stringHelper;
}

using namespace WordEngineering;

int main()
{
	stringHelper.stub();	
}

