using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace EmployeeManagementSystem.Converter
{
    /// <summary>
    /// Checks or Unchecks radio button by checking the value of parameter and value.
    /// </summary>
    class RadioButtonChoiceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (string)parameter == (string)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? parameter : DependencyProperty.UnsetValue;
        }
    }
}
