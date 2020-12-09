using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Data;
using System.Globalization;

namespace InformationInTransit.ProcessLogic
{
    public class DateTimeConverter : IValueConverter
    {
        public object Convert(object value,
                           Type targetType,
                           object parameter,
                           CultureInfo culture)
        {
            DateTime date = (DateTime)value;
            return date.ToShortDateString();
        }

        public object ConvertBack(object value,
                                  Type targetType,
                                  object parameter,
                                  CultureInfo culture)
        {
            string strValue = value.ToString();
            DateTime resultDateTime;
            if (DateTime.TryParse(strValue, out resultDateTime))
            {
                return resultDateTime;
            }
            return value;
        }
    }
}

/*
If you look at the code, a converter is a class that implements IValueConverter and as part of that provides two methods: Convert and ConvertBack.  These two methods are where you can perform your custom logic, in this case parsing a DateTime to and from a short date string format.

Now that you have your reusable converter class you can use it in data binding.

Back in your Page.xaml add a local xmlns.  To do this add the following in the UserControl tag next to the other xmlns declarations:

xmlns:local="clr-namespace:_____________"

Where the _________ is the name of your Application.  IntelliSense should provide the correct syntax as an option in the dropdown.  Next add the converter to your UserControl as a static resource.

<UserControl.Resources>
    <local:DateTimeConverter x:Key="DateConverter" />
</UserControl.Resources>

Finally use the converter in the TextBox's binding in the DataGridTemplateColumn. 

<TextBlock 
    Text="{Binding Birthday, Converter={StaticResource DateConverter}}" 
    Margin="4"/>

Now when you run the application, the text will be formatted in the manner that the converter specified.
*/