﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
 using Microsoft.Maui;using Microsoft.Maui.Controls;

namespace PokeApp_Maui8.Converters
{
    public class HeightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            float weightConverted = ((int)value) / 10.0f;
            return weightConverted + " cm";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
