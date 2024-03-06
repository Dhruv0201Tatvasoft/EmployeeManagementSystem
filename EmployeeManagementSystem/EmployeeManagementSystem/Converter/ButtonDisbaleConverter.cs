using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace EmployeeManagementSystem.Converter
{
    internal class ButtonDisbaleConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.LongLength > 0)
            {
                foreach (var value in values)
                {
                    if (value is bool && (bool)value)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            if (value is bool && (bool)value)
            {
                object[] convertedValues = new object[targetTypes.Length];

                for (int i = 0; i < targetTypes.Length; i++)
                {
                    convertedValues[i] = false;
                }

                return convertedValues;
            }

            return new object[targetTypes.Length];
        }

        
    }
}
