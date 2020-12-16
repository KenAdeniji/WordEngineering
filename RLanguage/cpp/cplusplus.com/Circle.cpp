#include <iostream>
#include <math.h>

using namespace std;

#define PI 3.14159
#define NEWLINE '\n'

int main ()
{
  double radius;
  double circleCircumference, circleArea;

  cout << "Radius: ";
  cin >> radius;
  
  circleCircumference = 2 * PI * radius;
  circleArea = PI * pow(radius, 2);
  
  cout << "Circumference: " << circleCircumference << NEWLINE;
  cout << "Area: " << circleArea << endl;  
}
