using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.IO;
using Microsoft.Win32;

using ProCSharp10WithNET6Library;

namespace ProCSharp10WithNET6WPF;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
	
	private void btnOK_Click(object sender, RoutedEventArgs e)
	{
		lblForward.Content = HowITryToBeAsIHaveAssociated.Forward( txtWord.Text );
		lblBackward.Content = HowITryToBeAsIHaveAssociated.Backward( txtWord.Text );
	}
	
	protected void FileExit_Click(object sender, RoutedEventArgs e)
	{
		this.Close(); //Close this window.
	}
	
	protected void ToolsSpellingHints_Click(object sender, RoutedEventArgs e)
	{
		string spellingHints = string.Empty;
		
		//Try to get a spelling error at the current caret location.
		SpellingError error = txtWord.GetSpellingError(txtWord.CaretIndex);
		if (error != null)
		{
			//Build a string of spelling suggestions.
			foreach(string s in error.Suggestions)
			{
				spellingHints += $"{s}\n";
			}	
		}

		//Show suggestion and expand the expander.
		lblSpellingHints.Content = spellingHints;
		expanderSpelling.IsExpanded = true;	
	}
	
	protected void MouseEnterExitArea(object sender, RoutedEventArgs e)
	{
		statBarText.Text = "Exit the Application";
	}

	protected void MouseEnterToolsHintsArea(object sender, RoutedEventArgs e)
	{
		statBarText.Text = "Show spelling suggestions";
	}
	
	protected void MouseLeaveArea(object sender, RoutedEventArgs e)
	{
		statBarText.Text = "Ready";
	}
}
