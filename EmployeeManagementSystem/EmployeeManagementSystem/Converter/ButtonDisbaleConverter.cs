using System.Globalization;
using System.Windows.Data;

namespace EmployeeManagementSystem.Converter
{

    /// <summary>
    /// Used to make button enable or disable based on conditions.
    /// </summary>
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
