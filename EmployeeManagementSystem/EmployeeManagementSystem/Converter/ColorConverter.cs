﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace EmployeeManagementSystem.Converter
{
    class ColorConverter : IValueConverter
    {
        private readonly SolidColorBrush[] colors = new[]
      {
            new SolidColorBrush(Color.FromRgb(19, 42, 19)),
            new SolidColorBrush(Color.FromRgb(49, 87, 44)),
            new SolidColorBrush(Color.FromRgb(79, 119, 45)),
            new SolidColorBrush(Color.FromRgb(144, 169, 85)),
            new SolidColorBrush(Color.FromRgb(144, 169, 85)),
            new SolidColorBrush(Color.FromRgb(83, 165, 72)),
            new SolidColorBrush(Color.FromRgb(52, 78, 65)),
            new SolidColorBrush(Color.FromRgb(58, 90, 64)),
            new SolidColorBrush(Color.FromRgb(88, 129, 87)),
            new SolidColorBrush(Color.FromRgb(163, 177, 138)),
            new SolidColorBrush(Color.FromRgb(135, 152, 106))
        };



        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int i)
            {
               
                return colors[i%colors.Length];
            }

            return Binding.DoNothing;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
