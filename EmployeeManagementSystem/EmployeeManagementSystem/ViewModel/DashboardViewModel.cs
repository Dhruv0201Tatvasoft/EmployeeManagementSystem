using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.ViewModel
{
    internal class DashboardViewModel
    {
        public ObservableCollection<KeyValuePair<string, int>> YourDataCollection { get; set; }

        public DashboardViewModel()
        {
            YourDataCollection = new ObservableCollection<KeyValuePair<string, int>>
        {
            new KeyValuePair<string, int>("Category 1", 30),
            new KeyValuePair<string, int>("Category 2", 50),
            new KeyValuePair<string, int>("Category 3", 20),
        };
        }
    }
}
