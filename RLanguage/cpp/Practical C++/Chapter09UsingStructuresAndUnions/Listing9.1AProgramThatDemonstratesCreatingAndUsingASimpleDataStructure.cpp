#include <iostream>
#include <string>

using namespace std;
//2016-10-03 cl /clr Listing9.1AProgramThatDemonstratesCreatingAndUsingASimpleDataStructure.cpp

//Create a mailing address data structure
struct MailingAddress {
	string Name;
	string Street;
	string City;
	string State;
	string Zip;
};
 	
void main(int argc, char *argv[])
{
	//Declare a variable of type MailingAddress
	MailingAddress mailingAddress;
	
	//Populate the structure with some data
	mailingAddress.Name = "John Galt";
	
	cout << "Name: " << mailingAddress.Name;

}
