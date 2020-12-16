using System.Windows.Forms;

/*
	2018-12-10	https://en.wikibooks.org/wiki/C_Sharp_Programming/The_.NET_Framework/Windows_Forms
	2018-12-10	csc /r:System.Windows.Forms.dll /target:winexe ExampleForm.cs
*/
namespace en.wikibooks.org
{
	public class ExampleForm : Form    // inherits from System.Windows.Forms.Form
	{
		public static void Main()
		{
			ExampleForm wikibooksForm = new ExampleForm();

			wikibooksForm.Text = "I Love Wikibooks";  // specify title of the form
			wikibooksForm.Width = 400;                // width of the window in pixels
			wikibooksForm.Height = 300;               // height in pixels
			Application.Run(wikibooksForm);           // display the form
		}
	}
}
