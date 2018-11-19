using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Binding
{
    public class BooleanToVisibility : IValueConverter
    {
        //Von Source Zu Target
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is bool boolVar)
            {
                if (boolVar)
                {
                    return Visibility.Visible;
                }
                else
                    return Visibility.Collapsed;
            }
            return Visibility.Visible;
        }

        //Von Target Zu Source
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
