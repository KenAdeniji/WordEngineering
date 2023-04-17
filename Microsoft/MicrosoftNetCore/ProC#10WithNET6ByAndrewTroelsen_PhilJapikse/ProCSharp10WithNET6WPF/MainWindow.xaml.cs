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

using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;

namespace ProCSharp10WithNET6WPF;

/// <summary>
/// Interaction logic for MainWindow.xaml
///	2023-04-15T20:24:00 http://stackoverflow.com/questions/9343381/wpf-command-line-arguments-a-smart-way
///	2023-04-15T20:24:00	http://stackoverflow.com/questions/728432/how-to-programmatically-click-a-button-in-wpf
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
		string[] argv = Environment.GetCommandLineArgs();
		if (argv.Length > 1)
		{
			txtWord.Text = argv[1];
			
			ButtonAutomationPeer peer = new ButtonAutomationPeer(btnOK);
			IInvokeProvider invokeProv = peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
			invokeProv.Invoke();			
		}		
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
