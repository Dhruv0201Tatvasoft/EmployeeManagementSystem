using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace EmployeeManagementSystem.Converter
{
    internal class ConvertButton : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            {
                if ((bool)value)
                {
                    return "C:\\Users\\pca89\\Desktop\\Employee Management System\\EmployeeManagementSystem\\EmployeeManagementSystem\\Icons\\SaveIcon.png"; 
                }
                else
                {

                    return "C:\\Users\\pca89\\Desktop\\Employee Management System\\EmployeeManagementSystem\\EmployeeManagementSystem\\Icons\\EditIcon.png";
                }

            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
