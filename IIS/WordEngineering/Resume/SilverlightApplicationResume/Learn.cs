using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

using System.ComponentModel;
using System.Collections.Generic;

namespace SilverlightApplicationResume
{
    public class Learn : INotifyPropertyChanged
    {
        private string school;
        private string programme;
        private string timeLine;

        // implement the required event for the interface
        public event PropertyChangedEventHandler PropertyChanged;

        public string School
        {
            get { return school; }
            set
            {
                school = value;
                NotifyPropertyChanged("School");
            }
        }

        public string Programme
        {
            get { return programme; }
            set
            {
                programme = value;
                NotifyPropertyChanged("Programme");
            }
        }

        public string TimeLine
        {
            get { return timeLine; }
            set
            {
                timeLine = value;
                NotifyPropertyChanged("TimeLine");
            }
        }

        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
