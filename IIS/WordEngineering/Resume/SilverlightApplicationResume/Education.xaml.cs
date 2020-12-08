using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

using System.Collections.ObjectModel;

namespace SilverlightApplicationResume
{
    public partial class Education : UserControl
    {
        public Education()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(Page_Loaded);
        }

        void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dataGridEducation.ItemsSource = Train;
            //dataGridEducation.FrozenColumnCount = 1;
            /*
                If you are programmatically working with a column and want to know if it is frozen or not, you can check the IsFrozen property on the Column.  This is a readonly property that will let you know if the column you are working with is frozen. 
            */
            //dataGridEducation.HeadersVisibility = DataGridHeadersVisibility.Column;
        }

        public static Collection<Learn> Train = new Collection<Learn>()
        {
            new Learn() { School = "University of Wollongong", Programme = "Doctorate candidate – Internet Commerce", TimeLine = "Commenced 1997"},
            new Learn() { School = "University of Technology, Sydney", Programme = "Masters in Computer Information Science", TimeLine = "Completed 1995"},
            new Learn() { School = "University of North Carolina, Charlotte", Programme = "Bachelors in Electrical Engineering - Computer Emphasis", TimeLine = "Completed 1988"},
            new Learn() { School = "Central Piedmont Community College, Charlotte", Programme = "Associates in Electrical, Computer, and Electronics Engineering", TimeLine = "Completed 1986"}
        };

    }
}
