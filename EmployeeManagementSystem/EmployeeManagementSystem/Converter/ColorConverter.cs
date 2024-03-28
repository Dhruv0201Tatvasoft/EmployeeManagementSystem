using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace EmployeeManagementSystem.Converter
{
    /// <summary>
    /// Gives a color using the id of an object or value of an object
    /// </summary>
    class ColorConverter : IValueConverter
    {
        private readonly SolidColorBrush[] colors = new[]
      {
            new SolidColorBrush(Color.FromRgb(19, 42, 19)),
            new SolidColorBrush(Color.FromRgb(49, 87, 44)),
            new SolidColorBrush(Color.FromRgb(79, 119, 45)),
            new SolidColorBrush(Color.FromRgb(144, 169, 85)),
            new SolidColorBrush(Color.FromRgb(135, 152, 106)),
            new SolidColorBrush(Color.FromRgb(83, 165, 72)),
            new SolidColorBrush(Color.FromRgb(52, 78, 65)),
            new SolidColorBrush(Color.FromRgb(58, 90, 64)),
            new SolidColorBrush(Color.FromRgb(88, 129, 87)),
            new SolidColorBrush(Color.FromRgb(163, 177, 138)),
            new SolidColorBrush(Color.FromRgb(115, 212, 91))
        };



        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int i)
            {
                return colors[i%colors.Length];
            }
            else if(value is string s)
            {
                switch (s)
                {
                    case "Developer":
                        return colors[0];
                    case "Manager":
                        return colors[1];
                    case "Senior Developer":
                        return colors[2];
                    case "Team Lead":
                        return colors[3];
                    default:
                        return colors[new Random().Next(0, colors.Length)];
                }
            }
            return Binding.DoNothing;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
