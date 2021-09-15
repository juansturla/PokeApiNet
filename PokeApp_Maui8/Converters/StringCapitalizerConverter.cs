using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
 using Microsoft.Maui;using Microsoft.Maui.Controls;

namespace PokeApp_Maui8.Converters
{
    public class StringCapitalizerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return string.Empty;

            string originalString = value.ToString().ToLower();

            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(originalString);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
