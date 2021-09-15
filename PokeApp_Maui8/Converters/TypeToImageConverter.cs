using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
 using Microsoft.Maui;using Microsoft.Maui.Controls;

namespace PokeApp_Maui8.Converters
{
    public class TypeToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string type = (string)value;

            return type + "IC.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
