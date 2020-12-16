#include <iostream>
#include <stdlib.h>
#include <string>
#include <time.h>

using namespace std;
//2016-10-03 cl /clr Listing13.3AProgramThatUsesAnArrayOfFunctionPointers.cpp

enum colors {
	BLACK = 0,
	BLUE = 1,
	GREEN = 2,
	MAGENTA = 3,
	ORANGE = 4,
	RED = 5,
	WHITE = 6,
	YELLOW = 7
};

// Global variables
const int COLOR_ENUM_SIZE = 8;
const int COLOR_STRING_SIZE = 50;
const int DRAWING_TYPE_SIZE = 6;

// Function prototypes
bool DrawCircle(int colorID);
bool DrawHexagon(int colorID);
bool DrawOctagon(int colorID);
bool DrawPentagon(int colorID);
bool DrawSquare(int colorID);
bool DrawTriangle(int colorID);

char* GetColor(int colorID);
int GetRandom(int lower, int upper);

// Function pointer type
typedef bool (*PFN)(int color);

char currentColor[COLOR_STRING_SIZE]; //Global string for colors
 
void main(int argc, char *argv[])
{
	//Initialize the Random number generator
	srand((unsigned)time(NULL));
	
	//Declare and initialize an array of function pointers
	PFN pfnDrawing[DRAWING_TYPE_SIZE] = {
		 DrawCircle,
		 DrawHexagon,
		 DrawOctagon,
		 DrawPentagon,
		 DrawSquare,
		 DrawTriangle,
	};	
	
	//Call the functions via the pointers
	for (int index = 0; index < DRAWING_TYPE_SIZE; ++index) {
		pfnDrawing[index](GetRandom(1, COLOR_ENUM_SIZE));
	}	
}

bool DrawCircle(int colorID)
{
	cout << "Circle with color: " << GetColor(colorID) << std::endl;
	return true;
}

bool DrawHexagon(int colorID)
{
	cout << "Hexagon with color: " << GetColor(colorID) << std::endl;
	return true;
}

bool DrawOctagon(int colorID)
{
	cout << "Octagon with color: " << GetColor(colorID) << std::endl;
	return true;
}

bool DrawPentagon(int colorID)
{
	cout << "Pentagon with color: " << GetColor(colorID) << std::endl;
	return true;
}

bool DrawSquare(int colorID)
{
	cout << "Square with color: " << GetColor(colorID) << std::endl;
	return true;
}

bool DrawTriangle(int colorID)
{
	cout << "Triangle with color: " << GetColor(colorID) << std::endl;
	return true;
}

char* GetColor(int colorID)
{
	char* colorName = currentColor;
	
	switch (colorID)
	{
		case BLACK:
			strcpy(colorName, "Black");
			break;
		case BLUE:
			strcpy(colorName, "Blue");
			break;
		case GREEN:
			strcpy(colorName, "Green");
			break;
		case MAGENTA:
			strcpy(colorName, "Magemta");
			break;
		case ORANGE:
			strcpy(colorName, "Orange");
			break;
		case RED:
			strcpy(colorName, "Red");
			break;
		case WHITE:
			strcpy(colorName, "White");
			break;
		case YELLOW:
			strcpy(colorName, "Yellow");
			break;
	}	
	
	return colorName;
}
	
int GetRandom(int lower, int upper)
{
	return rand() % (upper + 1 - lower) + lower;
}

