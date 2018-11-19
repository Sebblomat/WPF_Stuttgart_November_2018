using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace HalloMultiBinding
{
    public class DoublesToBrushConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            byte r=0, g=0, b=0;

            r = extractColor(values[0]);
            g = extractColor(values[1]);
            b = extractColor(values[2]);

            return new SolidColorBrush(Color.FromRgb(r, g, b));
        }

        private byte extractColor(object value)
        {
            if (value != null && byte.TryParse(value.ToString(), out byte color))
            {
                return color;
            }
            return (byte)0;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
