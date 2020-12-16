using System.Windows.Forms;
using System.Drawing;
	
/*
	2018-12-10	https://en.wikibooks.org/wiki/C_Sharp_Programming/The_.NET_Framework/Windows_Forms
	2018-12-10	csc /r:System.Windows.Forms.dll /target:winexe ExampleForm.cs
*/
namespace en.wikibooks.org
{
	public class ExampleFormWithLabelAndTextBox : Form    // inherits from System.Windows.Forms.Form
	{
		public ExampleFormWithLabelAndTextBox()
		{
			this.Text = "I Love Wikibooks";         // specify title of the form
			this.BackColor = Color.White;
			this.Width = 300;                       // width of the window in pixels
			this.Height = 300;                      // height in pixels

			// A Label
			Label TextLabel = new Label();
			TextLabel.Text = "One Label here!";
			TextLabel.Location = new Point(20, 20);
			TextLabel.Size = new Size(150, 30);
			TextLabel.Font = new Font("Arial", 12); // See! we can modify the font of text
			this.Controls.Add(TextLabel);           // adding the control to the form

			// A input text field
			TextBox Box = new TextBox();            // inherits from Control
			Box.Location = new Point(20, 60);       // then, it have Size and Location properties
			Box.Size = new Size(100, 30);
			this.Controls.Add(Box);                 // all class that inherit from Control can be added in a form
		}

		public static void Main()
		{
			Application.EnableVisualStyles();
			Application.Run(new ExampleFormWithLabelAndTextBox());     // display the form
		}
	}
}
