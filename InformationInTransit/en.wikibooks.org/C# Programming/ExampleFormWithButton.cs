using System.Windows.Forms;
using System.Drawing;
	
/*
	2018-12-10	https://en.wikibooks.org/wiki/C_Sharp_Programming/The_.NET_Framework/Windows_Forms
	2018-12-10	csc /r:System.Windows.Forms.dll /target:winexe ExampleForm.cs
*/
namespace en.wikibooks.org
{
	public class ExampleFormWithButton : Form    // inherits from System.Windows.Forms.Form
	{
		public ExampleFormWithButton()
		{
			this.Text = "I Love Wikibooks";           // specify title of the form
			this.Width = 300;                         // width of the window in pixels
			this.Height = 300;                        // height in pixels

			Button HelloButton = new Button();
			HelloButton.Location = new Point(20, 20); // the location of button in pixels
			HelloButton.Size = new Size(100, 30);     // the size of button in pixels
			HelloButton.Text = "Click me!";           // the text of button

			// When click in the button, this event fire
			HelloButton.Click += new System.EventHandler(WhenHelloButtonClick);

			this.Controls.Add(HelloButton);
		}

		void WhenHelloButtonClick(object sender, System.EventArgs e)
		{
			MessageBox.Show("You clicked! Press OK to exit of this message");
		}

		public static void Main()
		{
			Application.Run(new ExampleFormWithButton());       // display the form
		}
	}
}
