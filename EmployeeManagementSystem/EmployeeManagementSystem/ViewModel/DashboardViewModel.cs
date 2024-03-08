using EmployeeManagementSystem.Database;
using EmployeeManagementSystem.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.ViewModel
{
    internal class DashboardViewModel : INotifyPropertyChanged
    {
        private GetData getData;
        public ObservableCollection<DataPoint> JoinedData { get; set; }
        public ObservableCollection<DataPoint> ReleasedData { get; set; }
        public DataTable tb { get; set; }

        private DataTable designationWiseEmployee;

            
        public DataTable DesignationWiseEmpmloyee
        {
            get
            {
                return designationWiseEmployee;
            }
            set
            {
                designationWiseEmployee = value;
                OnPropertyChanged("DesignationWiseEmpmloyee");
            }
        }
        public DashboardViewModel()
        {
            getData = new GetData();
            tb = getData.GetEmployeeCountInTechnology();
            JoinedData = new ObservableCollection<DataPoint>
            {
                new DataPoint("January", 10),
                new DataPoint("February", 15),
                new DataPoint("March", 20),
                new DataPoint("April", 20),
                new DataPoint("May", 20),

            };

            ReleasedData = new ObservableCollection<DataPoint>
            {
                new DataPoint("January", 5),
                new DataPoint("February", 8),
                new DataPoint("March", 12),
                new DataPoint("April", 12),
                new DataPoint("May", 12),
            };
            List<DesignationDataItem> designationData = new List<DesignationDataItem>
            {
                new DesignationDataItem("Developer", 30),
                new DesignationDataItem("Manager", 15),
                new DesignationDataItem("Team Lead", 10)
                // Add more designations as needed
            };

        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class DataPoint
    {
        public string Month { get; set; }
        public int Value { get; set; }

        public DataPoint(string month, int value)
        {
            Month = month;
            Value = value;
        }
    }
    public class DesignationDataItem
    {
        public string Designation { get; set; }
        public int Count { get; set; }

        public DesignationDataItem(string designation, int count)
        {
            Designation = designation;
            Count = count;
        }
    }

    public class ChartViewModel
    {
        public List<DesignationDataItem> DesignationData { get; set; }
    }
}
