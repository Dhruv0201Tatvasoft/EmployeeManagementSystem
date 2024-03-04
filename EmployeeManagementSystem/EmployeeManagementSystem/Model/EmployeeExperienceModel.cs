using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Model
{
    internal class EmployeeExperienceModel : INotifyPropertyChanged
    {

        private String organization;

        public String Organization
        {
            get { return organization; }
            set { organization = value; OnPropertyChanged("Organization"); }
        }
        private DateTime fromDate;

        public DateTime FromDate
        {
            get { return fromDate; }
            set { fromDate = value; OnPropertyChanged("FromDate"); }
        }
        private DateTime toDate;

        public DateTime ToDate
        {
            get { return toDate; }
            set { toDate = value; OnPropertyChanged("ToDate"); }
        }
        private int duration;

        public int Duration
        {
            get { return duration; }
            set { duration = value; OnPropertyChanged("Duration"); }
        }
        private string designation;

        public string Designation
        {
            get { return designation; }
            set { designation = value; OnPropertyChanged("Designation"); }
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
