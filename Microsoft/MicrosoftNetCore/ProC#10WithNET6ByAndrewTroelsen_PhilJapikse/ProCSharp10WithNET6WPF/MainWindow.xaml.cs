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
}
