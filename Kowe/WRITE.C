#include <stdio.h>
#include <conio.h>
#include <graph.h>
#include <malloc.h>
#include <string.h>
#include <process.h>
#include <stdlib.h>
#include <share.h>
#include <io.h>
#include <fcntl.h>
#include <bios.h>
#include <dos.h>
#include <sys\types.h>
#include <sys\stat.h>
#include <errno.h>
/*
void far hardhandler(unsigned deverr, unsigned doserr, unsigned far *hdr);
*/
void main (int, char **);
void initialize (void);
void set_screen (void);
void setchars1 (void);
void getchars1 (void);
void setchars2 (void);
void getchars2 (void);
void procedure (void);
void dummy_print (void);
void test_insert (void);
void normal_print (void);
void function_print (void);
void extended_print (void);
void draw_print (void);
void print_header (void);
void confirmation (char *);
void print_error (char *);
int get_word (char *, int, int, int);
void print_location (void);
void cursor (void);
void function (void);
void draw (void);
void erase (void);
void display_line (void);
void display_page (void);
void name_title (void);
void load_file (void);
void save_file (void);
void goto_page (void);
void find_word (void);
void translate (void);
void trans (void);
void search_dico (void);
void help (void);
void dump_screen (void);
/*
void _bios_str (char *);
*/

/* Define Global Constants */

#define MAX_COLUMNS     80
#define MAX_ROWS       800
#define MAX_WORDS     1600
#define MAX_LINES       11

/* Cursor Keys Definitions */

#define BACK_SPACE      8
#define RIGHT_TAB       9
#define CR             13
#define LEFT_TAB       15
#define ESCAPE         27
#define HOME           71
#define CURSOR_UP      72
#define PAGE_UP        73
#define CURSOR_LEFT    75
#define CURSOR_RIGHT   77
#define END            79
#define CURSOR_DOWN    80
#define PAGE_DOWN      81
#define INSERT         82
#define DELETE         83

/*  functions definitions */

#define ERASE          18
#define TRANSLATE      20
#define INSERT_ROW     23
#define OS             24
#define PRINT_REPORT   25
#define SAVE_FILE      31
#define DELETE_ROW     32
#define FIND           33
#define GOTO           34
#define HELP           35
#define KEY            37
#define LOAD_FILE      38
#define SINGLE_DRAW   120
#define DOUBLE_DRAW   121

/*   variables initialization */

FILE *printer_file, *temp_file;
char far *alpha[64];
char far *dummy_screen;
unsigned char far storage[MAX_ROWS / 2][MAX_COLUMNS];
unsigned char far store  [MAX_ROWS / 2][MAX_COLUMNS];
unsigned char search_word[21] = "                    ";
unsigned char dico_word[45];
unsigned char doc_word[200], doc_name[61];
unsigned char tmp_name[61], doc_title[15], tmp_title[15], confirm[2];
unsigned char insert[4] = "Off";
unsigned char lang[7]   = "Yoruba";
unsigned char mode[5]   = "Text";
unsigned char n_char[2] = " ";
unsigned char user_page[4] = "   ";
unsigned char p_code;
unsigned char p_setup;
unsigned char lines[12] = { 179, 196, 218, 191, 192, 217,
			    186, 205, 201, 187, 200, 188 };
unsigned char n1, n2;
int  doc_file;
int  tmp_file;
int  dico_file;
int  last_row, screen_row, current_page, current_row, page, row, column;
int  last_page, flag, current_char, control_char, char_count, k, x, y, z;
int  h, v, lines_page, pixels_page;
int  k_code;
short h1, v1, h2, v2, h3, v3, h4, v4;
long dico_size, dico_offset;

void main(argc, argv)
int argc;
char *argv[];
{
initialize();
if (argc > 1)
{ for ( k = 0; argv[1][k] != 0 && k < 60; ++k)
      {  if ( argv[1][k] >= 'a' && argv[1][k] <= 'z') argv[1][k] -= 32;
	 tmp_name[k] = argv[1][k]; }
  if (access(tmp_name, 0) != - 1)
     { load_file(); name_title(); print_header(); }
  else {confirmation("Document  Does  Not  Exist,  Create  A  New  One : :");
	if (confirm[0] == 'Y')  { memcpy(doc_name, tmp_name, 60);
	      doc_file = sopen(doc_name, O_CREAT, SH_DENYWR);
	      if (doc_file) { name_title(); print_header(); }}
}      }
if (argc > 2)
{ for ( k = 0; argv[2][k] != 0 && k < 60; ++ k)
      {  if ( argv[2][k] >= 'a' && argv[2][k] <= 'z') argv[2][k] -= 32;
	 doc_name[k] = argv[2][k]; }
}
procedure(); close(dico_file); _setvideomode(_DEFAULTMODE);
}

void initialize()
{
  /* _harderr(hardhandler); */
   k = 0;
   _setvideomode(_DEFAULTMODE);
   _setbkcolor( (long) 1); _settextcolor(15); _clearscreen(_GCLEARSCREEN);
   _setbkcolor( (long) 0); _settextcolor(14);
   _settextwindow(16,3,20,24);  _clearscreen(_GWINDOW);
   _settextwindow(16,60,20,76); _clearscreen(_GWINDOW);
   _settextwindow(21,27,23,57); _clearscreen(_GWINDOW);
   _settextwindow(1,1,25,80);
   tmp_file = sopen("Kowe.Frm", O_RDONLY, SH_DENYNO);
   if ( tmp_file == -1 )
   { print_error("Logo.Frm File Not Found, Strike Any Key To Continue");
     close(tmp_file); exit(1); }
   for (y = 0, k = 0; !eof(tmp_file); ++ y)
      { read(tmp_file, storage[y], 79);
	for ( x = 0; x < 79; ++ x) k += storage[y][x];
	read(tmp_file, store[y], 1); }
   if  ( k != 15964) { close(tmp_file); abort(); }
   for (k = 0; k < y; ++ k) printf("%s\n", storage[k]); close(tmp_file);
   _setbkcolor( (long) 1); _settextcolor(15); _settextposition(25,25);
   _outtext("Strike  Any  Key  To  Continue  ...");  getch();
   help(); set_screen();
   for (k = 0; k < 64; ++k)
   alpha[k] = (char far *) malloc ((unsigned int) _imagesize(0,0,h-1,v-1));
   dummy_screen = (char far *) malloc ((unsigned int)
		  _imagesize(0,0,80*h,12*v));
   setchars1(); getchars1(); setchars2(); getchars2();
/*
   _clearscreen(_GCLEARSCREEN);
   for (k = 0; k <= 7; ++k)
     _putimage(72 + k * h * 10, 65, alpha[48 + k], _GPSET);
   for (k = 0; k <= 7; ++k)
     _putimage(72 + k * h * 10, 145, alpha[56 + k], _GPSET);
   getch(); _clearscreen(_GCLEARSCREEN);
*/
   dico_file = sopen("Dico", O_RDONLY | O_TEXT, SH_DENYNO, S_IREAD);
   if (dico_file != -1) dico_size = filelength(dico_file) / 40;
   last_row = row = screen_row = column = 1; _clearscreen(_GCLEARSCREEN);
   memset(storage[0], ' ', 80);
   memset(doc_name, ' ', 60); memset(tmp_name, ' ', 60);
}

void set_screen()
{
h = 8; v = 16; p_setup = 4; lines_page=40; pixels_page = 640; n1 = 128; n2=2;
if (_setvideomode(_HRES16COLOR) == 0)
      {  if (_setvideomode(_HRESBW) == 0)
	    {  if (_setvideomode(_HERCMONO)  == 0)
     { print_error ("Computer System Does Not Support Graphics, " \
		  "Strike Any Key To Continue ...");  exit(1); }
      h = 9; v = 28; p_setup = 6; lines_page = 23; pixels_page = 644; n1=208;
      }     }
_setbkcolor(_BLUE); _settextcolor(15); _clearscreen(_GCLEARSCREEN);
}

void setchars1()
{
_settextposition(1,24); _outtext("Extended Characters & Symbols Set");
_setcolor(10); v1 = v + 1; v2 = v1 + v / 2 - 1; v3 = v2 + 2; v4 = v1 + v - 1;
_moveto( 9*h+3,v1); _lineto( 9*h+3, v4);
_moveto(19*h  ,v2); _lineto(20*h-1, v2);
_moveto(29*h+3,v4); _lineto(29*h+3, v2); _lineto(30*h-1,v2);
_moveto(39*h  ,v2); _lineto(39*h+3, v2); _lineto(39*h+3,v4);
_moveto(49*h+3,v1); _lineto(49*h+3, v2); _lineto(50*h-1,v2);
_moveto(59*h  ,v2); _lineto(59*h+3, v2); _lineto(59*h+3,v1);
v1 = (short)(v * 2.5) + 1;
v2 =  v1 + (short)(v * .5) - 1; v3 = v2 + 2; v4 = v1 + v - 1;
_moveto( 9*h+3,v1); _lineto( 9*h+3, v4);
_moveto( 9*h+5,v1); _lineto( 9*h+5, v4);
_moveto(19*h,  v2); _lineto(20*h-1, v2);
_moveto(19*h,  v3); _lineto(20*h-1, v3);
_moveto(29*h+3,v4); _lineto(29*h+3, v2); _lineto(30*h-1, v2);
_moveto(29*h+5,v4); _lineto(29*h+5, v3); _lineto(30*h-1, v3);
_moveto(39*h,  v2); _lineto(39*h+5, v2); _lineto(39*h+5, v4);
_moveto(39*h,  v3); _lineto(39*h+3, v3); _lineto(39*h+3, v4);
_moveto(49*h+3,v1); _lineto(49*h+3, v3); _lineto(50*h-1, v3);
_moveto(49*h+5,v1); _lineto(49*h+5, v2); _lineto(50*h-1, v2);
_moveto(59*h,  v2); _lineto(59*h+3, v2); _lineto(59*h+3, v1);
_moveto(59*h,  v3); _lineto(59*h+5, v3); _lineto(59*h+5, v1);
_setcolor(15);
_settextposition( 9, 10);
_outtext("e         o         s         E         O         S");
_settextposition(12, 10);
_outtext("a         e         e         i         o         o         u");
_settextposition(15, 10);
_outtext("a         e         e         i         o         o         u");
_settextposition(18, 10);
_outtext("A         E         E         I         O         O         U");
_settextposition(21, 10);
_outtext("A         E         E         I         O         O         U");
_moveto(h*69+1,(short) (v*4.5-1)); _lineto(h*69+1, v*4-1);
_lineto(h*70-2,(short) (v*4.5-1)); _lineto(h*70-2,v*4-1);
_moveto(h*69, v*4-1+v/8); _lineto(h*70-1, v*4-1+v/8);
_moveto(h*69,(short)(v*4.5-1-v/8)); _lineto(h*70-1,(short)(v*4.5-1-v/8));
for (h1 = h*9+4, k = 14; k < 20; h1+=h*10, ++k) _setpixel(h1,(short)(v*4.5));
for (v1 = v * 6, k = 0;  k < 4;  v1 += (short)(v * 1.5), ++ k)
  {  _setpixel(h*29+4, v1); _setpixel(h*59+4, v1); }
for (v1 = v*5+4, v2 = 0; v2 < 2; v1 += v * 3, ++ v2)
   { for ( h1 = h*9+1, h2 = 0; h2 < 7; h1 += h*10, ++h2)
     { _setpixel(h1,v1); _setpixel(h1+1,v1+1); _setpixel(h1+2,v1+2); } }
for (v1 = (short)(v*6.5+4), v2 = 0; v2 < 2; v1 += v * 3, ++ v2)
   { for ( h1 = h*9+5, h2 = 0; h2 < 7; h1 += h*10, ++h2)
     { _setpixel(h1,v1); _setpixel(h1-1,v1+1); _setpixel(h1-2,v1+2); } }
_settextposition(3, 73); _outtext("1-Draw");
_settextposition(6, 73); _outtext("2-Draw");
_settextposition(9, 73); _outtext("F8..F10");
_settextposition(12, 2); _outtext("Itself");
_settextposition(15, 2); _outtext("Control");
_settextposition(18, 2); _outtext("Shift");
_settextposition(21, 2); _outtext("Alt");
for ( k = 12; k <= 21; k += 3 )
  { _settextposition(k, 73); _outtext("F1..F7"); }; _settextposition(24,25);
_outtext("Strike  Any  Key  To  Continue ..."); getch();
}

void setchars2()
{
_settextwindow(2,1,23,80); _clearscreen(_GWINDOW); _settextwindow(1,1,25,80);
_settextposition( 5, 20); _outtext("i         n         o         u");
_settextposition(10, 20); _outtext("I         N         O         U");
_settextposition(15, 20); _outtext("b         d         k         y");
_settextposition(20, 20); _outtext("B         D         K         Y");
_setpixel(155, 40);                           /* i */
_setpixel(235, 31);                           /* n */
_setpixel(315, 40);                           /* o */
_setpixel(395, 40);                           /* u */
_setpixel(155, 69); _setpixel(155, 80);       /* I */
_setpixel(235, 69);                           /* N */
_setpixel(315, 69); _setpixel(315, 80);       /* O */
_setpixel(395, 80);                           /* U */
/*   b    d    k   y  */
_setpixel(153,111);_setpixel(153,110);_setpixel(154,109);_setpixel(155,109);
_setpixel(236,111);_setpixel(236,110);_setpixel(237,109);
_setpixel(313,111);_setpixel(313,110);_setpixel(314,109);_setpixel(315,109);
_setpixel(392,113);_setpixel(393,112);_setpixel(394,111);
/*   B    D    K   Y  */
_setpixel(153,151);_setpixel(153,150);_setpixel(154,149);_setpixel(155,149);
_setpixel(233,151);_setpixel(233,150);_setpixel(234,149);_setpixel(235,149);
_setpixel(313,151);_setpixel(313,150);_setpixel(314,149);_setpixel(315,149);
_setpixel(392,151);_setpixel(393,150);_setpixel(394,149);
_settextposition( 5,  5);  _outtext("Itself");
_settextposition( 5, 65);  _outtext("F1..F4");
_settextposition(10,  5);  _outtext("Itself");
_settextposition(10, 65);  _outtext("F5..F8");
_settextposition(15,  5);  _outtext("Shift");
_settextposition(15, 65);  _outtext("F1..F4");
_settextposition(20,  5);  _outtext("Shift");
_settextposition(20, 65);  _outtext("F5..F8");
getch();
}

void getchars1()
{
   _getimage(0, 0, h - 1, v - 1, alpha[0]);
   _getimage(69*h, (short)(v*3.5+1), 70*h-1, (short)(v*4.5), alpha[1]);
   for (v1 = v+1,  k = 2;  k < 14;  v1 += (short)(v * 1.5))
      { for  (h1 = h*9, h2 = 0; h2 < 6;  h1 += h*10, ++h2, ++k)
	      _getimage(h1, v1, h1 + h - 1,  v1 + v - 1, alpha[k]); }
   for (h1 = h * 9, k = 14; k < 21; h1 += h*10, ++k)
     _getimage(h1, (short)(v*4.5-v+1), h1+h-1, (short)(v*4.5), alpha[k]);
   for (v1 = v * 5 + 1, k = 20; k < 48; v1 += (short)(v * 1.5))
      { for  (h1 = h * 9, h2 = 0; h2 < 7;  h1 += h * 10,  ++k, ++ h2)
     _getimage(h1, v1, h1 + h - 1, v1 + v - 1, alpha[k]); }
}

void getchars2()
{
  for (v1 =  25, h1 = 152, k = 48; k < 52; h1 += 80, ++ k)
      _getimage(h1, v1, h1 + h - 1, v1 + v - 1, alpha[k]);
  for (v1 = 105, h1 = 152, k = 52; k < 56; h1 += 80, ++k)
      _getimage(h1, v1, h1 + h - 1, v1 + v - 1, alpha[k]);
  for (v1 =  65, h1 = 152, k = 56; k < 60; h1 += 80, ++ k)
      _getimage(h1, v1, h1 + h - 1, v1 + v - 1, alpha[k]);
  for (v1 = 145, h1 = 152, k = 60; k < 64; h1 += 80, ++k)
      _getimage(h1, v1, h1 + h - 1, v1 + v - 1, alpha[k]);

}

void procedure()
{
print_header();
for (;;)
{
  if (column > MAX_COLUMNS && row < MAX_ROWS)
     { ++ row; ++ screen_row; column = 1; }
  if (row    > last_row)
     { memset(storage[last_row], ' ', 80); ++ last_row; }
  if (screen_row > MAX_LINES)
   {  _getimage(0, v * 2 + 1, h * 80 - 1, v * (MAX_LINES + 1), dummy_screen);
      _putimage(0, v * 2 + 1, dummy_screen, _GXOR);
      _putimage(0, v + 1, dummy_screen, _GPSET);  -- screen_row; }
  print_location();
  _displaycursor(_GCURSORON); _settextposition(screen_row * 2 + 2, column);
  current_char = getch();     _displaycursor(_GCURSOROFF);
  if (current_char == 0)   control_char = getch(); else control_char = 0;
  if (current_char > 0x1f && current_char < 0x7f)
        { test_insert(); normal_print(); continue; }
  if (current_char == RIGHT_TAB && column < 80)
        { column = (column / 10) * 10 + 10; continue; }
  if (control_char == 49)
     { k = 1; test_insert(); extended_print(); continue; }
  if (( control_char > 65 && control_char < 69) || (control_char > 90
        && control_char < 94  ))
            { test_insert(); dummy_print(); continue; }
  if (( control_char > 58 && control_char < 69) || (control_char > 83
	    && control_char < 114 ))
            { test_insert(); function_print(); continue; }
  if ( (control_char  > 70 && control_char < 84) || current_char == 8 ||
         control_char == LEFT_TAB) { cursor(); print_location();  continue; }
  if ( control_char == 120 || control_char == 121 ) { draw(); continue; }
  if ( current_char == CR) { column = 81; continue; }
  if ( current_char <  ESCAPE) { function(); continue; }
  if ( current_char == ESCAPE)
     { confirmation("Do  You  Want  To  End  Session  : :");
       if (confirm[0] == 'Y') return; print_header();
     }
}
}

void dummy_print()
{
  k = -1;
  if (lang[0] == 'Y') {
  if (control_char < 69) k = control_char - 52; else k = control_char - 74;}
  else {
  if (control_char == 66) k= 55; else if (control_char == 91) k = 63; }
  extended_print();
}

void test_insert()
{
 if (insert[1] == 'n')
 { _getimage (h*(column-1), v * screen_row + 1,
	      79 * h - 1, v * (screen_row + 1), dummy_screen);
   _putimage(h * column, v * screen_row + 1, dummy_screen, _GPSET);
   for ( x = 79; x >= column; -- x)
       storage[row-1][x] = storage[row-1][x - 1];
 }
}

void normal_print()
{
  storage[row-1][column-1] = n_char[0] = (char) current_char;
  _putimage(h*(column-1), v * screen_row + 1, alpha[0], _GPSET);
  _settextposition(screen_row * 2 + 2, column); _outtext(n_char); ++ column;
}

void function_print()
{
  k = - 1;
 if (lang[0] == 'Y')
 {if      (control_char >  58  && control_char <  66) k = control_char - 39;
  else if (control_char >  83  && control_char <  91) k = control_char - 50;
  else if (control_char >  93  && control_char < 101) k = control_char - 67;
  else if (control_char > 103  && control_char < 111) k = control_char - 63;}
 else
 {if      (control_char >  58  && control_char <  67) k = control_char - 11;
  else if (control_char >  83  && control_char <  92) k = control_char - 28;}
  extended_print();
}

void extended_print()
{
  if ( k == - 1) return;
  storage[row-1][column-1] = (char) (128 + k);
  _putimage(h*(column-1), v * screen_row + 1, alpha[k], _GPSET); ++ column;
}

void draw_print()
{
   storage[row-1][column-1] = (char) (128 + k);
   _putimage(h*(column-1), v * screen_row + 1, alpha[k], _GPSET);
}

void print_header()
{
  _getimage(0, 0, h * MAX_COLUMNS - 1, v, dummy_screen);
  _putimage(0, 0, dummy_screen, _GXOR);
  _settextposition(1, 1);  _outtext("File: ");
  _settextposition(1,22);  _outtext("Lang: ");
  _settextposition(1,35);  _outtext("Mode: ");
  _settextposition(1,46);  _outtext("Ins: ");
  _settextposition(1,55);  _outtext("Pg: ");
  _settextposition(1,64);  _outtext("Row: ");
  _settextposition(1,73);  _outtext("Col: ");
  _settextcolor(14);
  _settextposition(1, 7);  _outtext(doc_title);
  _settextposition(1,27);  _outtext(lang);
  _settextposition(1,40);  _outtext(mode);
  _settextposition(1,51);  _outtext(insert);
  print_location();  _settextcolor(14);
  _settextposition(2,2); _outtext( "Del  Erase  Find  Go  Help  Ins  "\
  "Load  Save  Trans  OS  Print  1-Draw  2-Draw" );
  _settextcolor(15);
}

void confirmation(question_string)
char question_string[];
{
  _getimage(0, 0, h * MAX_COLUMNS - 1, v + 1, dummy_screen);
  _putimage(0, 0, dummy_screen, _GXOR);
  for ( x = 0; question_string[x] != '\0';  ++ x);
  k = ( 80 - x ) / 2;  confirm[0] = 'N';
  _settextposition( 1, k); _outtext(question_string);
  if ( get_word(confirm, 0, 1, k + x - 2) == 1) confirm[0] = 'N';
}

void print_error(print_string)
char print_string[];
{
  for ( k = 0; print_string[k] != '\0'; ++ k);
  k = (80 - k ) / 2;
  _settextposition(2,1); for ( x = 0; x < 80; ++x) putchar(32); putchar(7);
  _settextposition(2,k); _settextcolor(4); _outtext(print_string);
  _settextcolor(15); getch(); print_header();
 /*row = row - screen_row + 1; display_page(); row = row + screen_row - 1;*/
}

int get_word(word, maximum, vertical, horizontal)
char word[]; 
int  maximum, vertical, horizontal;
{
  k = 0; _settextcolor(14);
  do
  {
     _displaycursor(_GCURSOROFF);
     _settextposition(vertical, horizontal); _outtext(word);
     _displaycursor(_GCURSORON);
     _settextposition(vertical,horizontal+k);  current_char = getch();
     _displaycursor(_GCURSOROFF);
     if ( current_char == 0 )  control_char = getch(); else control_char = 0;
     if ( control_char == CURSOR_LEFT && k > 0)
          { --k; continue; }
     if ( control_char == CURSOR_RIGHT && k < maximum)
          { ++ k; continue; }
     if ( current_char == BACK_SPACE && k > 0)
          { for ( x = k - 1 ; x < maximum; ++x) word[x] = word[x+1]; 
            --k; continue;  }
     if (control_char ==  DELETE)
          { for ( x = k; x < maximum; ++x) word[x] = word[x+1]; continue;  }
     if ( current_char  >= 'a' && current_char <= 'z') current_char -= 32;
     if ( current_char  > 0x1f && current_char < 0x7f)
	  { word[k] = (char) current_char;   if ( k  < maximum )    ++k; }
   } while ( current_char != CR && current_char != ESCAPE);
   _settextcolor(15); if (current_char == 27) return (1); else return(0);
}

void print_location()
{
  char page_buffer[4], row_buffer[3], column_buffer[3];
  current_page = (row - 1) / lines_page + 1;
  current_row  = (row - 1) % lines_page + 1;
  _settextcolor(14);
  sprintf(page_buffer,   "%3d", current_page);
  sprintf(row_buffer,    "%2d", current_row);
  sprintf(column_buffer, "%2d", column);
  _settextposition(1,59);  _outtext(page_buffer);
  _settextposition(1,69);  _outtext(row_buffer);
  _settextposition(1,78);  _outtext(column_buffer);
  _settextcolor(15);
}

void cursor()
{
if (current_char == 8) control_char = 8;
switch (control_char)
{
 case LEFT_TAB:
	if      (column < 11)       column =   1;
	else if (column % 10 == 0)  column -= 10;
	else                        column = column / 10 * 10;
	break;

 case HOME:
	if      (column != 1)       { column = 1; break; }
	else if ( screen_row != 1)
		{ row = row - screen_row + 1; screen_row = 1; break;}
	if      ( current_row != 1)
		{ row = (current_page - 1) * lines_page + 1;
		  screen_row = column = 1; }
	else    { row = screen_row = column = 1; }
	display_page(); break;

 case CURSOR_UP:
	if (screen_row  >  1 )  { --screen_row; -- row; }
	else if (row > 1)
	{ _getimage(0, v + 1, h * MAX_COLUMNS-1,v * MAX_LINES, dummy_screen);
	  _putimage(0, v * 2 + 1, dummy_screen, _GPSET);
	  -- row; y = row - 1; z = 1; display_line();
	}
	break;

  case PAGE_UP:
	if (row  != screen_row)
	{  if ( row <= MAX_LINES)
	   { row = 1; display_page(); row = screen_row; }
	   else if ( row - MAX_LINES - screen_row < 0)
		   { row = 1; display_page(); row = screen_row; }
	   else
		   { row = row - MAX_LINES - screen_row + 1;
		   display_page(); row = row + screen_row - 1; }
	}
	break;

  case CURSOR_LEFT:
	if (column >  1)            --column;
	break;

  case CURSOR_RIGHT:
	if (column < MAX_COLUMNS)   ++column;
	break;

  case END:
	if (column !=  MAX_COLUMNS) column = MAX_COLUMNS;
	else if ( screen_row != MAX_LINES)
	{  if    (row + MAX_LINES - screen_row <= last_row)
	      { row = row + MAX_LINES - screen_row; screen_row = MAX_LINES; }
	   else { screen_row = screen_row + last_row - row; row = last_row;}}
	else { row = last_row - MAX_LINES + 1; screen_row = column = 1;
	       display_page(); }
	break;

  case CURSOR_DOWN:
	if (row < last_row)
	{ ++ row;
	if (screen_row  < MAX_LINES)  ++ screen_row;
	else {
      _getimage(0, v * 2 + 1, h * 80 - 1, v * (MAX_LINES + 1), dummy_screen);
	      _putimage(0, v + 1, dummy_screen, _GPSET);
	      y = row - 1; z = MAX_LINES; display_line();
	     }
	}
	break;

  case PAGE_DOWN:
	if (last_row <= MAX_LINES) break;
	if (row < last_row - MAX_LINES)
	   { row += MAX_LINES; display_page(); row = row + screen_row - 1; }
	else
	   { row = last_row - MAX_LINES + 1; display_page(); screen_row = 1; }
	break;

  case INSERT:
       if (insert[1] == 'n')  insert[1] = insert[2] = 'f';
       else { insert[1] = 'n'; insert[2] = ' '; }  _settextposition(1,51);
       _settextcolor(14); _outtext(insert); _settextcolor(15);
       break;

  case DELETE:
       y = row - 1;
       for ( x = column - 1; x < MAX_COLUMNS - 1; ++x)
	  storage[y][x] = storage[y][x+1];
       storage[y][MAX_COLUMNS - 1] = ' ';
       h1 = column * h; h2 = h * 80 - 1;
       v1 = (v * screen_row) + 1; v2 = v1 + v - 1;
       _getimage(h1, v1, h2, v2, dummy_screen);
       _putimage(h1 - h, v1, dummy_screen, _GPSET);
       _putimage(h2 - h, v1, alpha[0], _GPSET);
       break;

  case BACK_SPACE:
       if (column > 1)
       { y = row - 1;
	 for ( x = column - 2; x < MAX_COLUMNS - 1; ++x)
	  storage[y][x] = storage[y][x+1];
	 storage[row][79] = ' '; h1 = (column - 1) * h;
	 h2 = h * 80 - 1 ; v1 = (v * screen_row) + 1; v2 = v1 + v - 1;
	 _getimage(h1, v1, h2, v2, dummy_screen);
	 _putimage(h1 - h, v1, dummy_screen, _GPSET);
	 _putimage(h2 - h, v1, alpha[0], _GPSET); --column;
       }
       break;
}
}

void function()
{
h2 = h * MAX_COLUMNS - 1; v1 = v * screen_row + 1; v2 = v * (MAX_LINES + 1);
switch (control_char)
{
 case DELETE_ROW:   /*  Delete a row */
       if ( screen_row != MAX_LINES)
	 _getimage(0, v1 + v, h2, v2, dummy_screen);
	 _putimage(0, v1 + v, dummy_screen, _GXOR);
       if ( screen_row != MAX_LINES ) _putimage(0, v1, dummy_screen, _GPSET);
       x = row - 1; y = row; z = last_row - row;
       memcpy(storage[x], storage[y], z * 80);
       if (last_row == 1) { memset(storage[0], ' ', 160); break; }
       z = MAX_LINES; y = row + MAX_LINES - screen_row;
       if (y == last_row) memset(storage[y-1], ' ',80);
       --y; display_line(); -- last_row; break;

 case ERASE:        /*  Erase Current Work */
      confirmation("Do  You  Want  To  Erase  Current  Work  : :");
      if (confirm[0] == 'Y') erase();
      print_header(); break;

 case INSERT_ROW:   /*  Insert a row */
      _getimage(0, v1, h2, v2 - v, dummy_screen);
      _putimage(0, v1,  dummy_screen, _GXOR);
      if (screen_row != MAX_LINES)
	  _putimage(0, v1 + v, dummy_screen, _GPSET);
      x = row - 1; y = row; ++ last_row; z = last_row - row ;
      memmove(storage[y], storage[x], z * 80);
      memset(storage[x], ' ', MAX_COLUMNS);
      break;

 case KEY:
      if (lang[0] == 'Y') strcpy(lang, "Others");else strcpy(lang, "Yoruba");
      _settextposition(1,27); _settextcolor(14); _outtext(lang);
      _settextcolor(15); break;

 case TRANSLATE:  translate(); print_header(); break;
 
 case SAVE_FILE:  save_file(); name_title(); print_header(); break;
 
 case LOAD_FILE:  _getimage(0, 0, h2, v + 1, dummy_screen);
		  _putimage(0, 0, dummy_screen, _GXOR);
		  _settextposition(1,1); printf("Document Name:");
		  memcpy(tmp_name, doc_name, 60);
		  if (get_word(tmp_name, 60, 1, 18) == 0)
		     { load_file(); name_title(); }
		  print_header(); break;

 case FIND:       find_word(); print_header();  break;

 case GOTO:       goto_page(); break;

 case HELP:       _setvideomode(_DEFAULTMODE); _setbkcolor( (long) 1);
		  _settextcolor(15); help();
		  set_screen(); setchars1(); setchars2();
		  row = row - screen_row + 1;
		  display_page(); row = row + screen_row - 1; break;

 case OS:         confirmation(
		    "Do  You  Want  To  Exit  To  Operating  System  : :");
		  if (confirm[0] == 'Y')
		  { _setvideomode(_DEFAULTMODE); system("Command.Com");
		    set_screen(); print_header(); row = row - screen_row + 1;
		    display_page(); row = row + screen_row - 1;
		  } print_header(); break;

 case PRINT_REPORT:
       v3 = row; v4 = screen_row;
       _getimage(0, 0, h2, v + 1, dummy_screen);
       _putimage(0, 0, dummy_screen, _GXOR); confirm[0] = 'P';
       _settextposition(1,26); printf("Print on Printer or File : :");
       if (get_word(confirm, 1, 1, 52) == 1) { print_header(); return; }
       if (confirm[0] == 'P')
       { printer_file = fopen("PRN", "w");
	 if (printer_file == NULL)     {  print_error(
     "Error Printing, Put Printer On Line, Strike Any Key To Continue ...");
	 fclose(printer_file); return; } }
       else
       { _settextposition(1,1); printf ("Print Document: ");
	 memset(tmp_name, ' ', 60);
	 if (get_word(tmp_name, 60, 0, 18) == 1) { print_header(); return; }
	 printer_file = fopen(tmp_name, "w");
	 if (printer_file == NULL) { print_error(
	  "Error Writting Into Print File, Strike Any Key To Continue ...");
	 fclose(printer_file); return; } }
   /* set line spacing to 8 / 72, for equal line spacing */
   fprintf(printer_file, "%c%c%c", 27, 'A', 8);
   /* redefine graphics mode normal, to represent screen 80 / 90 dots
   fprintf(printer_file, "%c", 27);  fprintf(printer_file, "%c", '?');
   fprintf(printer_file, "%c", 'K'); fprintf(printer_file, "%c", p_setup);*/
   for ( row = 1; row < last_row; row += MAX_LINES)
	  { display_page(); dump_screen(); } v1 = 0;
   /* reset printer setup to default */
   fprintf(printer_file, "%c%c", 27, '@');
   fclose(printer_file);
   row = v3; screen_row = v4;
   row = row - screen_row + 1; display_page(); row = row + screen_row - 1;
   break;
}
}

void draw()
{
int n;
char h_status = ' ', v_status = ' ';
if (control_char == 120) n = 2; else n = 8;
strcpy(mode,"Draw"); _settextposition(1,40); _settextcolor(14);
_outtext(mode); _settextcolor(15);
for ( ; ; )
{
  print_location();
  _displaycursor(_GCURSORON); _settextposition( screen_row * 2 + 2, column);
  current_char = getch();     _displaycursor(_GCURSOROFF);
  if (current_char ==  0)     control_char = getch(); else control_char = 0;
  if (current_char == 27 || (current_char > 0x1f && current_char < 0x7f)) 
     { strcpy(mode, "Text"); _settextposition(1,40); _settextcolor(14);
       _outtext(mode);_settextcolor(15);
       if (current_char != 27) ungetch(current_char);
       return; }
  if (control_char == 120)                    { n = 2;      continue; }
  if (control_char == 121)                    { n = 8;      continue; }
  if (control_char > 17 && control_char < 39) { function(); continue; }
  if (control_char < 71 || control_char > 81) continue;
  switch (control_char)
  {
     case CURSOR_UP:   if      (h_status == ' ')  k = n;
                       else if (h_status == 'L')  k = n + 4;
                       else                       k = n + 5;
		       h_status = ' '; v_status = 'U';
		       if (screen_row > 1 && row > 1)
		       { draw_print(); --screen_row; -- row; }
		       else if (row > 1)
		       { draw_print();
			 _getimage(0, screen_row * v + 1,
			  h * MAX_COLUMNS - 1, v * MAX_LINES, dummy_screen);
			 _putimage(0, screen_row * v * 2 + 1, dummy_screen,
			   _GPSET);
			   -- row; y = row - 1; z = 1; display_line();
		       } break;
                      
    case CURSOR_DOWN:  if      (h_status == ' ')  k = n;
                       else if (h_status == 'L')  k = n + 2;
                       else                       k = n + 3;
		       h_status = ' '; v_status = 'D';
		       if (screen_row < MAX_LINES && row < MAX_ROWS)
		       {  if (row == last_row)
			   {memset(storage[last_row], ' ', 80); ++ last_row;}
			   draw_print(); ++ screen_row; ++ row; }
		       else if (row < MAX_ROWS)
		       {
			 draw_print(); _getimage(0, v * 2 + 1,
		     h * MAX_COLUMNS - 1, v * (MAX_LINES + 1), dummy_screen);
			 _putimage(0, v + 1, dummy_screen, _GPSET);
			 ++ row;
			 if (row > last_row)
			 { memset(storage[last_row], ' ', 80); ++ last_row; }
			   y = row - 1; z = MAX_LINES; display_line();
			}  break;

    case CURSOR_RIGHT: if      (v_status == ' ')  k = n + 1;
                       else if (v_status == 'U')  k = n + 2;
                       else                       k = n + 4;             
                       h_status = 'R'; v_status = ' '; draw_print();
                       if (column < MAX_COLUMNS) ++ column;
                       break;

    case CURSOR_LEFT:
                       if      (v_status == ' ')  k = n + 1;
                       else if (v_status == 'U')  k = n + 3; 
                       else                       k = n + 5;
                       h_status = 'L'; v_status = ' '; draw_print();
                       if (column > 1)           -- column;
                       break;

    case PAGE_UP:
    case PAGE_DOWN:
    case HOME:
    case END:
		       cursor(); h_status = v_status = ' '; break;
}}}

void erase()
{
  last_row = screen_row = row = column = 1;
  memset(doc_name, ' ', 60); name_title();
  memset(storage[row - 1], ' ', 80); _clearscreen(_GCLEARSCREEN);
  print_header();
}

void display_line()
{
   for (x = 0; x < MAX_COLUMNS; ++ x)
       {  if (storage[y][x] < 128)
	     { _putimage(h * x, v * z + 1, alpha[0], _GPSET);
	       _settextposition(z * 2 +  2, x + 1);
	       n_char[0] = storage[y][x]; _outtext(n_char); }
	  else
	     { k = storage[y][x] - 128;
	       _putimage(h * x, v * z + 1, alpha[k], _GPSET); }
       }
}
                          
void display_page()
{
   _clearscreen(_GCLEARSCREEN); print_header();
   for ( z = 1, y = row - 1; z <= MAX_LINES && y < last_row; ++y, ++z)
       display_line();
}

void name_title()
{
  char drive, ext, name;
  drive = ext = -1; name = 0; memset(doc_title, ' ', 14);
  for ( y = 0; y < 60 && doc_name[y] != ' '; ++ y)
    { if (doc_name[y] == ':' && drive == -1)
	 { drive = (char) y - 1; name = (char) y + 1; }
      if (doc_name[y] == '\\')                 name  = (char) y + 1;
      if (doc_name[y] == '.' && ext == -1)     ext   = (char) y + 1; } x = 0;
  if ( drive > - 1)
     { doc_title[0] = doc_name[drive]; doc_title[1] = ':'; x = 2;}
  for ( y = 0; y < 8 && doc_name[y+name] != ' ' && doc_name[y+name] != '.';
	     ++ y, ++ x) doc_title[x] = doc_name[y + name];
  if ( ext > -1 ) { doc_title[x] = '.'; doc_title[x+1] = doc_name[ext];
		    doc_title[x+2] = doc_name[ext+1];
		    doc_title[x+3] = doc_name[ext+2]; x = x + 3; }
  doc_title[x+1] = '\0';
}

/*
void far hardhandler(unsigned deverr, unsigned doserr, unsigned far *hdr)
{
  char back[3];
    
  back[0] = back[1] = 8; back[2] = confirm[2] = '\0'; _settextcolor(4);
  _settextwindow(2,1,2,80); _clearscreen(_GWINDOW); _settextwindow(1,1,25,80);
  for (; ;)
  {
    _settextposition(2,13);
    if (deverr <= 0x7FFF)
       _bios_str("Disk  Access  Error,  Do  You  Want  To  Try  Again : :");
    else _bios_str("Printer  Error,  Do  You  Want  To  Try  Again : :");   
    _bios_str(back);
    _settextcolor(15);
    confirm[0] = (char) (_bios_keybrd(_KEYBRD_READ) & 0x00FF);
    _bios_str(confirm);
    if (confirm[0] == 'n' || confirm[0] == 'N') _hardretn(doserr);
    _hardresume(_HARDERR_RETRY);
  }
  print_header();
}

void _bios_str ( char *p)
{
  union REGS inregs, outregs;
  char *start = p; inregs.h.ah = 0x0e;
  for (; *p; p++) { inregs.h.al = *p; int86 (0x10, &inregs, &outregs); }
}
*/

void load_file()
{
   unsigned char temp_string[2], letter;
   if (access(tmp_name, 0) == - 1)
     { print_error("File Does Not Exist, Strike Any Key To Continue ...");
       return; }
   if (doc_file) close(doc_file);
   doc_file = sopen(tmp_name, O_RDONLY, SH_DENYWR);
   if (doc_file == -1)
      { doc_file = sopen(tmp_name, O_RDONLY, SH_DENYNO);
	print_error("File Is Read Only, Strike Any Key To Continue ..."); }
   erase(); memcpy(doc_name, tmp_name, 60);
   for ( row = column = 0; ! eof(doc_file); ++ column)
   {
     if (column == MAX_COLUMNS)
	{ ++ row; memset(storage[row], ' ', 80); column = 0; }
     if (row    == MAX_ROWS)   {
	print_error("File Too Large, Strike Any Key To Continue ...");
	row = MAX_ROWS - 1; break; }
     read(doc_file, temp_string, 1); letter = temp_string[0];
     if (letter > 31 ) storage[row][column] = letter;
     if (letter == 10)
     { if (column == 0) column = -1; else column = MAX_COLUMNS - 1; continue;}
/*
     if (letter > 178 && letter < 219)
     { for (k = 0; k < 12; ++k)
       { if (letter == lines[k]) { storage[row][column] = 130 + k; break; }}}
*/
   }
  last_row = row + 1; row = screen_row = column = 1; display_page();
}

void save_file()
{
 unsigned char letter;
 _getimage(0, 0, MAX_COLUMNS * h - 1, v, dummy_screen);
 _putimage(0, 0, dummy_screen, _GXOR);
 _settextposition(1,1); printf("Document Name:");
 memcpy(tmp_name, doc_name, 60);
 if (get_word(tmp_name, 60, 1, 18) == 1) return;
 if (doc_file) close(doc_file);
 if (access(tmp_name, 2) == - 1 && access(tmp_name, 0) == 0)
    { print_error(
      "File Write Protected, Strike Any Key To Continue ..."); return; }
 doc_file=sopen(tmp_name, O_WRONLY | O_CREAT | O_TRUNC, SH_DENYWR, S_IREAD);
 if (doc_file == -1) {
   print_error("Only Read Action Permitted, Strike Any Key To Continue ...");
   return; } memcpy(doc_name, tmp_name, 14);
   for (y = 0; y < last_row; ++y)
       { for (k = MAX_COLUMNS - 1; storage[y][k] == ' ' && k > 0; --k);
	 for (x = 0; x <= k; ++x)
	 { letter = storage[y][x];
/*      if ( letter > 129 && letter < 142)  letter = lines[letter - 130]; */
	   write(doc_file, &letter, 1); }
	 write(doc_file, "\n", 1);
       }
   close(doc_file); memcpy(doc_name, tmp_name, 60);
}
 
void goto_page()
{
  int  new_page;
  if (get_word(user_page, 2, 1, 59) == 1) return;
  if (user_page[0] > 47 && user_page[0] < 58)
     { new_page = user_page[0] - 48;
       if (user_page[1] > 47 && user_page[1] < 58)
	  { new_page = new_page * 10 + user_page[1] - 48;
	    if (user_page[2] > 47 && user_page[2] < 58)
	       new_page = new_page * 10 + user_page[2] - 48; }}
  if (new_page < 1 ) { print_error(
  "Invalid Page, Strike Any Key To Continue ..."); return; }
  -- new_page; if ( new_page > last_row / lines_page) return;
  row = new_page * lines_page + 1; screen_row = 1; display_page();
}

void find_word()
{
int test_counter;
_getimage(0, 0, MAX_COLUMNS * h - 1, v, dummy_screen);
_putimage(0, 0, dummy_screen, _GXOR);
_settextposition(2, 1); printf("English Word To Translate:");
memset(search_word, 32, 20);
if (get_word(search_word, 19, 2, 30) == 1) { print_header(); return; }
for (test_counter = 0; test_counter < 2; ++test_counter)
{ 
  search_dico(); if (flag == 0) break;
  for (k = 19; k >= 0 && search_word[k] == ' '; -- k);
    if      ( search_word[k] == 'S')  search_word[k] = ' ';
    else if ( search_word[k] == 'D' && search_word[k - 1] == 'E' && k > 1)
	      search_word[k] = search_word[k-1] = ' ';
    else if ( search_word[k] == 'G' && search_word[k - 1] == 'N' &&
	      search_word[k - 2] == 'I' && k > 2)
	      search_word[k] = search_word[k-1] = search_word[k-2] = ' ';
    else      break;
   }
if ( flag == 0)
    {  for ( x = 20; x < 40; ++x)
            {  if (dico_word[x] < 128)
                  { _settextposition(2, x+35);
                    n_char[0] = dico_word[x]; _outtext(n_char); }
		   else { k = dico_word[x] - 128;
			  _putimage( h * (x + 34), 1, alpha[k], _GPSET); }
             } putchar(7); getch();
     }
else {  print_error("Word Not Found, Strike Any Key To Continue ...");
        _putimage(0,0, dummy_screen, _GPSET); 
}    }

void translate()
{
  unsigned char last_char, new_char;
  _getimage(0, 0, MAX_COLUMNS * h - 1, v, dummy_screen);
  _putimage(0, 0, dummy_screen, _GXOR);
  _settextposition(1,1); printf("Translate File:");
  memset(tmp_name, 32, 60);
  if (get_word(tmp_name, 60, 1, 18) == 1)  return;
  tmp_file = open(tmp_name, O_WRONLY | O_TRUNC | O_CREAT);
  if (tmp_file == -1) {
     print_error("Error Writting File, Strike Any Key To Continue ...");
     return; }
  char_count = 0; new_char = ' ';
  for ( y = 0; y < last_row; ++y)
     { for ( x = 0; x < MAX_COLUMNS; ++x)
       { 
	 last_char = new_char; new_char = storage[y][x];
	 if (new_char == '-' && last_char != ' ')
             {  if ( x != 79)
		    { doc_word[char_count] = '-'; ++char_count; }
	       continue; }
	 if  ( new_char >= 'a' && new_char <= 'z')  new_char -= 32;
	 if  ( new_char >= 'A' && new_char <= 'Z')
	     { doc_word[char_count] = new_char; ++char_count; continue; }
	 if  ( new_char == ' ' && last_char == ' ') continue;
	 for ( k = char_count; k < 20; ++k) doc_word[k] = ' ';
	 if  ( char_count > 0) { trans(); char_count = 0; }
	 if (new_char < 130 || new_char > 141)
	    write(tmp_file, &new_char, 1);
}}
close(tmp_file);
}

void trans()
{
  int test_counter;
  memcpy(search_word, doc_word, 20);
  -- char_count; flag = 1; k = 0;
  for (test_counter = 0; test_counter < 2; ++ test_counter)
  {
    search_dico(); if (flag == 0) break;
    if      (search_word[char_count] == 'S')
	     { search_word[char_count] = ' '; k = 1; }
    else if (search_word[char_count] == 'D' &&
	   search_word[char_count - 1] == 'E' && char_count > 1)
	   search_word[char_count] = search_word[char_count - 1] = ' ';
    else if (search_word[char_count] == 'G' && search_word[char_count - 1]
    == 'N' && search_word[char_count - 2] == 'I' && char_count > 2)
	   search_word[char_count] = search_word[char_count - 1] =
	   search_word[char_count - 2] = ' ';
    else break;
  }
  if (flag == 0 )
  {
  if (k == 1)                                     {
   write(tmp_file, (char *)162, 1); write(tmp_file, (char *)'W', 1);
   write(tmp_file, (char *)146, 1); write(tmp_file, (char *)'N', 1);
   write(tmp_file, (char *)' ', 1);                     }
    for ( k = 20; dico_word[k] != ' ' && dico_word[k] != ',' & k <= 40; ++ k)
	     write(tmp_file, &dico_word[k], 1);
  } else { for (k = 0; k <= char_count; ++ k)
	     write(tmp_file, &doc_word[k], 1); }
}

void search_dico()
{
  long low, high, n;
  if (dico_size == -1) { flag = 1; return; }
  low = 0; high = dico_size; flag = 1;
  while (flag != 0 && low <= high)
  {
    n  =  (long) ((high + low) / 2);   dico_offset = n * 40;
    lseek(dico_file, dico_offset, SEEK_SET);
    read(dico_file, dico_word, 40);
    flag =   memcmp(dico_word, search_word, 20);
    if        (flag == -1)  low  = n + 1;
    else if   (flag ==  1)  high = n - 1;
  }
}

void help()
{
     if (tmp_file) close(tmp_file);
     tmp_file = sopen ("Kowe.Hlp", O_RDONLY, SH_DENYNO);
     if (tmp_file == -1)   print_error
      ("Help File Not Available, Strike Any Key To Continue ..");
     else { _clearscreen(_GCLEARSCREEN);
	    while ( ! eof(tmp_file)) { read(tmp_file, doc_word, 79);
		    printf("%s\n", doc_word); read(tmp_file, doc_word, 1); }
	    _settextposition(25,25);
	    _outtext("Strike  Any  Key  To  Continue ..."); getch();
	    _clearscreen(_GCLEARSCREEN);
          }
     close(tmp_file);
}

void dump_screen()
{
  for ( y = v; y <= v2; y += 8, v1 += 8)
      { 
	 if (v1 >= pixels_page)
	 { fprintf(printer_file, "%c%c%c%c", 12, 27, 'A', 8); v1 = 0; }
	 /* get printer ready for graphics output*/
	 fprintf(printer_file,"%c*%c%c%c", 27, p_setup, n1, n2);
	 for ( x = 0; x <= h2; ++x, p_code = 0)
          {
	  /* p_code = ( 128 * _getpixel(x,y))   + ( 64 * _getpixel(x,y+1)) +
		     (  32 * _getpixel(x,y+2)) + ( 16 * _getpixel(x,y+3)) +
		     (   8 * _getpixel(x,y+4)) + (  4 * _getpixel(x,y+5)) +
		     (   2 * _getpixel(x,y+6)) + (      _getpixel(x,y+7));*/
	   if (_getpixel(x,y)   > 0)          p_code = p_code + 128;
	   if (_getpixel(x,y+1) > 0)          p_code = p_code +  64;
	   if (_getpixel(x,y+2) > 0)          p_code = p_code +  32;
	   if (_getpixel(x,y+3) > 0)          p_code = p_code +  16;
	   if (_getpixel(x,y+4) > 0)          p_code = p_code +   8;
	   if (_getpixel(x,y+5) > 0)          p_code = p_code +   4;
	   if (_getpixel(x,y+6) > 0)          p_code = p_code +   2;
	   if (_getpixel(x,y+7) > 0)          p_code = p_code +   1;
	   fprintf(printer_file, "%c", p_code);
          }
	  fprintf(printer_file, "%c%c%c", 27, 'A', 8);
	  fprintf(printer_file, "\n");
       }
 }


