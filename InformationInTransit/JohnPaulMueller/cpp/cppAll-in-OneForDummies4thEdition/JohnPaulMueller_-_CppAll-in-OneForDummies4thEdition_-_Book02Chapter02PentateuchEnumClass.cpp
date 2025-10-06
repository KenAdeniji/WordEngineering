/*
	http://www.wiley.com/en-us/C%2B%2B+All-in-One+For+Dummies%2C+4th+Edition-p-9781119601739
	John@JohnMuellerBooks.com
	C++ All-in-One For Dummies, 4th Edition
	John Paul Mueller 
	ISBN: 978-1-119-60173-9
	December 2020
	912 pages	
	2025-09-10T22:05:00 Date created.
*/
#include <iostream>

using namespace std;

class PentateuchEnumClass
{
	public:
		enum PentateuchEnum
		{
			Genesis,
			Exodus,
			Leviticus,
			Numbers,
			Deuteronomy
		};
		PentateuchEnumClass
		(
			PentateuchEnumClass::PentateuchEnum value
		);
		string AsString();
	protected:
		PentateuchEnum value;
};

PentateuchEnumClass::PentateuchEnumClass
(
	PentateuchEnumClass::PentateuchEnum init
)
{
	value = init;
}	

string PentateuchEnumClass::AsString()
{
	switch (value)
	{
		case Genesis: return "Genesis";
		case Exodus: return "Exodus";
		case Leviticus: return "Leviticus";
		case Numbers: return "Numbers";
		case Deuteronomy: return "Deuteronomy";
		default: return "Not found";
	}	
}	

ostream& operator << (ostream& out, PentateuchEnumClass& inst)
{
	out << inst.AsString();
	return out;
}	

int main(int argc, char *argv[])
{
	PentateuchEnumClass levitics = PentateuchEnumClass::Leviticus;
	cout << levitics.AsString() << endl;
	
	cout << levitics << endl;
}
