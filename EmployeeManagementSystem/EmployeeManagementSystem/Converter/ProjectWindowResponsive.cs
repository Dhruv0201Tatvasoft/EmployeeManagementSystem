using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace EmployeeManagementSystem.Converter
{
    class ProjectWindowResponsive : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            if(value is double width)
            {
             
                if(width>1235) return Orientation.Horizontal;
               return Orientation.Vertical;   
            }
            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
