#include <iostream>

#include <set>
using std::set;

class name {

	std::string i_name;
	
	name(const char* const i_name)
	{
		this->i_name = i_name;
	}
};

class no_copy {
	// ...
	private:
	no_copy(const no_copy&);
	no_copy& operator = (no_copy&);
};

class cmd //: name 
{
	private:
		static std::set<class cmd*> cmd_set;

	public:
		cmd(const char* const i_name) //:name(i_name) 
		{
			do_register();
		}
	
		virtual ~cmd() {
			unregister();
		}
		
		void do_register() {
			cmd_set.insert(this);
		}
		
		void unregister() {
			cmd_set.erase(this);
		}
};

int main()
{
	const char* ptr_a;

	//That means that we can reassign the pointer:
	ptr_a = "A New Value";
	
	//But you can't modify the data pointed to by the pointer:
	*ptr_a = 'x'; // ILLEGAL
	
	//In this case the pointer is affected by the const. The data pointed to is not.
	char* const ptr_b;
	
	//So we can change the data being pointed to:
	*ptr_b = 'x'; // Legal
	
	//But we can not change the pointer:
	ptr_b = "A new string"; // ILLEGAL
	
	//And of course there's the obvious declaration in which both the pointer and the data are constant:
	const char* const ptr_c;
	
	//Now let's go back to our function call. If we are expecting constantdata,
	//then let's specify it in the function parameters:
	
	void display_string(const char* const the_string);
	//Now any attempt to modify the string will result in a compile time error .
	//And compile time errors are much easier to locate and fix than runtime errors.
	
	/*
	The const modifies the element it's nearest. For
	example:
	const char* ptr_s; 
	In this case const is nearer to char than it is to *, so
	the data (char) is constant.
	In the other case:
	char* const ptr_t;
	the const is nearer to the * than it is to the char, so the
	pointer is constant, not the data (char).
	*/
	
	// Define how to draw the rectangle
	struct draw_params {
	int width;
	int line_color;
	int fill_color;
	int fill;
	int stack;
	std::string label_font;
	int label_size;
	std::string label;
	};
	
	struct draw_params my_rect;
	my_rect.width = 1;
	my_rect.line_color = COLOR_BLUE;
	my_rect.fill_color = COLOR_PINK;
	my_rect.fill = SOLID_FILL;
	my_rect.stack = ABOVE_ALL;
	my_rect.label_font = "Times";
	my_rect.label_size = 10;
	my_rect.label = "Start";
	
	memset(&my_rect, '\0', sizeof(my_rect));
	my_rect.line_color = COLOR_RED;
	//draw_rectangle(x1, y1, x2, y2, &my_rect);
	
	// Bad Code
	/*
	const int LOG_FLAG_DU = 0x80; // Disable update
	const int LOG_FLAG_DS = 0x40; // Disable save
	const int LOG_FLAG_TSD = 0x20; // Target save disabled
	const int LOG_FLAG_ETC = 0x10; // Enable thres. comp. 
	*/
	
	// Good code
	const int LOG_FLAG_DU = 1 << 7; // Disable update
	const int LOG_FLAG_DS = 1 << 6; // Disable save
	const int LOG_FLAG_TSD = 1 << 5; // Target save disabled
	const int LOG_FLAG_ETC = 1 << 4; // Enable thres. comp.

	no_copy a_var;
	// This will result in a compile error
	no_copy b_var(a_var);
	
    return 0;
}
