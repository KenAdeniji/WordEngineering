using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace InformationInTransit.ProcessLogic
{
    static class Program
    {

        [STAThread]
        static void Main() {
    
        // Create the main form
        AnonymousMethodFormHelper form = new AnonymousMethodFormHelper();
        // Run the application until the main form is closed
        Application.Run(form);
        }
    }

    public partial class AnonymousMethodFormHelper : Form
    {
        public AnonymousMethodFormHelper()
        {
            Button btnHello = new Button();
            btnHello.Text = "Hello";

            btnHello.Click +=
            delegate
            {
                MessageBox.Show("Hello");
            };

            Button btnGoodBye = new Button();
            btnGoodBye.Text = "Goodbye";
            btnGoodBye.Left = btnHello.Width + 5;

            btnGoodBye.Click +=
            delegate(object sender, EventArgs e)
            {
                string message = (sender as Button).Text;
                MessageBox.Show(message);
            };

            Controls.Add(btnHello);
            Controls.Add(btnGoodBye);
        }
    }
}
